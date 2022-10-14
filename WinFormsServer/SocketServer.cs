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
        private int port;
        public SocketServer(int port)
        {
            this.port = port;
        }
        Task task;
        /// <summary>
        /// запускает задачу на прослушивание порта
        /// </summary>
       public void Start()
        {
            if(task!=null)
            {
                MessageBox.Show("Server is Running");
            }
            
            this.task = new Task(this.run);
            task.Start();
        }
        /// <summary>
        /// задачa слушать порт
        /// </summary>
        public void run()
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Any, this.port);
            Socket listensocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
              listensocket.Bind(iPEndPoint);//порт
              listensocket.Listen(10);//начинаем ждать гостей
                while(true)
                {
                  Socket inComingListenSocket = listensocket.Accept();//дождались гостей
                    MessageBox.Show("Кто-то пришёл");
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
