using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
         static string adress;
         static int port;
        public SocketClient(string adress, int port)
        {
            SocketClient.adress = adress;
            SocketClient.port = port;
        }
        static IPAddress ip = IPAddress.Parse(adress);
        IPEndPoint ep = new IPEndPoint(ip,port);
        Socket s = new Socket(AddressFamily.InterNetwork,
        SocketType.Stream, ProtocolType.Tcp);
        public void run()
        {
            try
            {
                s.Connect(ep);
                if (s.Connected)
                {
                    string strSend = "GET\r\n\r\n";
                    s.Send(Encoding.UTF8.
                    GetBytes(strSend));
                    byte[] buffer = new byte[1024];
                    int l;
                    do
                    {
                        l = s.Receive(buffer);
                        MessageBox.Show(Encoding.UTF8.
                        GetString(buffer, 0, l));
                        
                    } while (l > 0);
                }
                else
                    MessageBox.Show("Error");
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }

finally
            {
                s.Shutdown(SocketShutdown.Both);
                s.Close();
            }
        }

        }



}

