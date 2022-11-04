
using Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsClient
{
    internal class SocketClient
    {
        //public Socket incomingClientSocket;

        ///// <summary>
        ///// Для работы с клиентом мне нужно знать его сокет
        ///// </summary>
        ///// <param name="incomingClientSocket">Входящий сокет клиента</param>
        //public SocketClient(Socket incomingClientSocket)
        //{
        //    this.incomingClientSocket = incomingClientSocket;
        //}

        ///// <summary>
        ///// Когда я закончил отсылку
        ///// </summary>
        ///// <param name="ar"></param>
        //private void WhenSending(IAsyncResult ar)
        //{
        //    incomingClientSocket.Shutdown(SocketShutdown.Both);
        //    incomingClientSocket.Close(); // По завершению работы - закрыть
        //}


        ///// <summary>
        ///// Процесс работы с клиентом
        ///// </summary>
        //public void run()
        //{
        //    Thread.Sleep(2000);
        //    // MessageBox.Show("Кто то пришел: \n" + incomingClientSocket.LocalEndPoint);

        //    string send = new DateTime().ToString();
        //    // Вызывает блокировку потока
        //    // incomingClientSocket.Send(Encoding.Unicode.GetBytes(send));

        //    incomingClientSocket.BeginSend(
        //        Encoding.Unicode.GetBytes(send), // Что я отсылаю
        //        0,
        //        send.Length,
        //        0,
        //        new AsyncCallback(WhenSending),
        //        this.incomingClientSocket
        //        );
        //    // Закрытие соединения следует вызывать уже тогда, когда передеча произошла
        //    //incomingClientSocket.Shutdown(SocketShutdown.Both);
        //    //incomingClientSocket.Close(); // По завершению работы - закрыть
        //    public Socket s; 
        //    public SocketClient(Socket s)
        //    {
        //        this.s=s;
        //    }
        //    //IPEndPoint ep ;
        //    //Socket s = new Socket(AddressFamily.InterNetwork,
        //    //SocketType.Stream, ProtocolType.Tcp);
        //    public void run()
        //    {
        //        Thread.Sleep(2000);
        //        try
        //        {
        //            //s.Connect(ep);
        //            //if (s.Connected)
        //            //{
        //                string strSend = "GET\r\n\r\n";
        //                s.BeginSend(Encoding.Unicode.
        //                GetBytes(strSend),0,strSend.Length,0,new AsyncCallback(WhenSending),this.s);
        //                byte[] buffer = new byte[1024];
        //                int l;
        //                StringBuilder builder = new StringBuilder();
        //                do
        //                {
        //                    l = s.Receive(buffer, buffer.Length,0);
        //                    builder.Append(Encoding.Unicode.
        //                    GetString(buffer, 0, l));


        //                } while (l > 0);
        //                MessageBox.Show(builder.ToString());
        //                s.Shutdown(SocketShutdown.Both);
        //                s.Close(); // По завершению работы - закрыть
        //            //}
        //            //else
        //            //    MessageBox.Show("Error");
        //        }
        //        catch (SocketException ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }

        //    }
        //    private void WhenSending(IAsyncResult ar)
        //{
        //    s.Shutdown(SocketShutdown.Both);
        //    s.Close(); // По завершению работы - закрыть
        //}
        public int index { get; set; }
        
        Socket s;
        
        public class State
        {
            public Socket senderSocket;
            public int data;
            public static int BUFFER_SIZE = 256;
            public byte[] buffer = new byte[BUFFER_SIZE];
            public StringBuilder sb = new StringBuilder();
        }
        void DoReceive(IAsyncResult ar)//метод получения данных
        {
            try
            {
                State state;
                if (ar.AsyncState is State)
                    state = ar.AsyncState as State;
                else return;

                int read = state.senderSocket.EndReceive(ar);//метод EndReceivе возвращает
                                                             //количество полученных байт и
                                                             //завершает асинзронное чтение

                if (read > 0)
                {
                    state.sb.Append(Encoding.Unicode.GetString(state.buffer, 0, read));
                    state.senderSocket.BeginReceive(state.buffer, 0, State.BUFFER_SIZE, 0,
                                             new AsyncCallback(DoReceive), state);
                    
                }
                else
                {
                    if (state.sb.Length > 1)
                    {
                        string strContent;
                        strContent = state.sb.ToString();
                        MessageBox.Show(String.Format("Read {0} byte from socket" +
                                         "data = {1} ", strContent.Length, strContent));
                       
                    }
                    state.senderSocket.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void AfterConnect(IAsyncResult ar)//метод, описывающий что делать после соединения
        {
            State state;
            if (ar.AsyncState is State)
                state = ar.AsyncState as State;
            else
            {
                //    MessageBox.Show(" ");
                //    return;
                state = new State();
                state.senderSocket = this.s;
            }
            state.senderSocket.BeginReceive(state.buffer, 0, State.BUFFER_SIZE, 0,
                                  new AsyncCallback(DoReceive), state);

        }
        public void AsyncConnect(string adress, string port, int index)//асинхронное соединение
        {
            this.index=index;
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(adress),
                Convert.ToInt32(port));//инициализируем точку подключения
            Socket senderSocket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);//создаём сокет для соединения
            senderSocket.ReceiveTimeout = 6000;

            this.s = senderSocket;

            try
            {
                State state = new State();//создаём объект, описывающий состояние
                                          //соединения и данные для передачи
                state.senderSocket = senderSocket;
                state.data = 42;

                senderSocket.BeginConnect(ipEndPoint,new AsyncCallback(AfterConnect),state);//начинаем асинхронное
                                                                                            //соединение,передавая
                                                                                            // делегат в созданный
                                                                                            // объект обратного вызова
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void run(int i)
        {
            index = i;
            while (true)
            {
                //int bytes = 0; // количество полученных байтов
                byte[] data = new byte[1024]; // буфер для получаемых данных

                //do
                //{
                //    bytes = s.Receive(data);

                //    // builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                //}
                //while (s.Available > 0);

                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream ms = new MemoryStream(data))
                {
                    try
                    {
                        Request request = (Request)formatter.Deserialize(ms);
                        switch (request.Command)
                        {
                            case Lib.Enum.RequestCommands.Read:
                                Lib.Entities.Index num = (Lib.Entities.Index)request.Body;
                                num.index = index;
                                MessageBox.Show(request.Body.ToString());
                                break;
                            default:
                                MessageBox.Show(" No Command ");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }
    }

}

