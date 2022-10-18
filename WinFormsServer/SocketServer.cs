using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsServer
{
    internal class SocketServer
    {
        IPEndPoint IPEnd;
        Socket socket;
        public SocketServer(string address,int port)
        {
            IPEnd = new IPEndPoint(IPAddress.Parse( address), port);
        }
        void MyAcceptCallbackFunction(IAsyncResult ia)
        {
            //получаем ссылку на слушающий сокет
            Socket socket = (Socket)ia.AsyncState;
            //получаем сокет для обмена данными с клиентом
            Socket ns = socket.EndAccept(ia);
            //выводим  информацию о подключении
            MessageBox.Show(ns.RemoteEndPoint.ToString());
            //отправляем клиенту текущщее время асинхронно,
            //по завершении операции отправки будет
            //вызван метод MySendCallbackFunction
            byte[] sendBufer = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
            ns.BeginSend(sendBufer, 0, sendBufer.Length,
            SocketFlags.None,new AsyncCallback(MySendCallbackFunction),ns);
            //возобновляем асинхронный Accept
            socket.BeginAccept(new AsyncCallback(MyAcceptCallbackFunction),socket);
        }
        void MySendCallbackFunction(IAsyncResult ia)
        {
            //по завершению отправки данных на клиента
            //закрываем сокет 
            Socket ns = (Socket)ia.AsyncState;
            _ = ((Socket)ia.AsyncState).EndSend(ia);
            ns.Shutdown(SocketShutdown.Send);
            ns.Close();
        }
        public void StartServer()
        {
            if (socket != null)
                return;
            try
            {
                socket = new Socket(AddressFamily.InterNetwork,
                            SocketType.Stream,
                            ProtocolType.Tcp);
                socket.Bind(IPEnd);
                socket.Listen(10);
                //начинаем асинхронный Accept
                socket.BeginAccept(new AsyncCallback(MyAcceptCallbackFunction), socket);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        // Task task;
        // /// <summary>
        // /// запускает задачу на прослушивание порта
        // /// </summary>
        //public void Start()
        // {
        //     if(task!=null)
        //     {
        //         MessageBox.Show("Server is Running");
        //     }

        //     this.task = new Task(this.run);
        //     task.Start();
        // }
        // /// <summary>
        // /// задачa слушать порт
        // /// </summary>
        // public void run()
        // {
        //     IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, this.port);
        //     Socket listensocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //     try
        //     {
        //       listensocket.Bind(iPEndPoint);//порт
        //       listensocket.Listen(10);//начинаем ждать гостей
        //         while(true)
        //         {
        //           Socket inComingListenSocket = listensocket.Accept();//дождались входящее соединение
        //             MessageBox.Show("Кто-то пришёл");
        //             inComingListenSocket.Close();//закрываем соединение по завершении
        //         }

        //     }
        //     catch(Exception ex)
        //     {
        //         MessageBox.Show(ex.Message);
        //     }

        // }
    }
}
