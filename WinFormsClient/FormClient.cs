﻿using System;
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
            client = new SocketClient(txtIP.Text, Convert.ToInt32(txtPort.Text));
        }
        SocketClient client;
        //Socket s;
        //class State
        //{
        //    public Socket senderSocket;
        //    public int data;
        //    public static int BUFFER_SIZE = 256;
        //    public byte[] buffer = new byte[BUFFER_SIZE];
        //    public StringBuilder sb = new StringBuilder();
        //}
        //void DoReceive(IAsyncResult ar)
        //{
        //    try
        //    {
        //        State state;
        //        if (ar.AsyncState is State)
        //            state = ar.AsyncState as State;
        //        else return;

        //        int read = state.senderSocket.EndReceive(ar);

        //        if (read > 0)
        //        {
        //            state.sb.Append(Encoding.Unicode.GetString(state.buffer, 0, read));
        //            state.senderSocket.BeginReceive(state.buffer, 0, State.BUFFER_SIZE, 0,
        //                                     new AsyncCallback(DoReceive), state);
        //        }
        //        else
        //        {
        //            if (state.sb.Length > 1)
        //            {
        //                string strContent;
        //                strContent = state.sb.ToString();
        //                MessageBox.Show(String.Format("Read {0} byte from socket" +
        //                                 "data = {1} ", strContent.Length, strContent));
        //            }
        //            state.senderSocket.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        //void AfterConnect(IAsyncResult ar)
        //{
        //    State state;
        //    if (ar.AsyncState is State)
        //        state = ar.AsyncState as State;
        //    else
        //    {
        //        //    MessageBox.Show(" ");
        //        //    return;
        //        state = new State();
        //        state.senderSocket = this.s;
        //    }
        //    state.senderSocket.BeginReceive(state.buffer, 0, State.BUFFER_SIZE, 0,
        //                          new AsyncCallback(DoReceive), state);

        //}
        //private void AsyncConnect()
        //{
        //    IPEndPoint ipEndPoint = new IPEndPoint(
        //        IPAddress.Parse(txtIP.Text),
        //        Convert.ToInt32(txtPort.Text));
        //    Socket senderSocket = new Socket(AddressFamily.InterNetwork,
        //        SocketType.Stream, ProtocolType.Tcp);
        //    senderSocket.ReceiveTimeout = 6000;

        //    this.s = senderSocket;

        //    try
        //    {
        //        State state = new State();
        //        state.senderSocket = senderSocket;
        //        state.data = 42;

        //        senderSocket.BeginConnect(
        //            ipEndPoint,
        //            new AsyncCallback(AfterConnect),
        //            state
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //AsyncConnect();
            client.run();
        }
    }
}
