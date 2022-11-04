using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
            
        }
        SocketClient client;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //AsyncConnect();
            if(lstIndex.Items==null)
            {
                MessageBox.Show("Список индексов пуст!!!");
            }
            if(lstIndex.SelectedItem == null)
            {
                MessageBox.Show("Не выбран индекс!!!");
            }
            if(lstIndex.Items != null&& lstIndex.SelectedItem != null)
            {
                client = new SocketClient(); 
                client.AsyncConnect(txtIP.Text, txtPort.Text,
                    Convert.ToInt32(lstIndex.SelectedItem.ToString()));

            }


        }

        private void FormClient_Load(object sender, EventArgs e)
        {

        }
    }
}
