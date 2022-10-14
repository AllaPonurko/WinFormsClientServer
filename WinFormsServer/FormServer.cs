using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsServer
{
    public partial class FormServer : Form
    {
        public FormServer()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            SocketServer socketServer = new SocketServer(Convert.ToInt32(numPort.Text));
            socketServer.Start();
        }
    }
}
