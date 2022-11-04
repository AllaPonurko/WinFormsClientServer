using System;
using System.Windows.Forms;
using WinFormsServer.MyDbContext;

namespace WinFormsServer
{
    public partial class FormServer : Form
    {
        public FormServer()
        {
            InitializeComponent();
            SocketServer socketServer = new SocketServer("127.0.0.1", Convert.ToInt32(numPort.Text));
            socketServer.StartServer();
        }
        public static DbStreets db = new DbStreets();
        private void Start_Click(object sender, EventArgs e)
        {
            FormIndex form = new FormIndex();
            form.Show();
        }
    }
}
