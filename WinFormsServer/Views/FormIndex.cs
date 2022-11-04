
using System;
using System.Windows.Forms;
using WinFormsServer.Entities;
using WinFormsServer.Views;
using System.Linq;

namespace WinFormsServer
{
    public struct CurrentIndex
    {
      public int cur ;
    }
    public partial class FormIndex : Form
    {
        public FormIndex()
        {
            InitializeComponent();
        }
        public static CurrentIndex current;
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtIndex.Text.Length==0)
            {
                MessageBox.Show("Индекс не введён!!!");
                return;
            }
            
            if(txtIndex.Text.Length != 0)
            {
                if(FormServer.db.Mies != null)
                {foreach(var item in FormServer.db.Mies)
                    {
                        if (item.Index == Convert.ToInt32(txtIndex.Text))
                        {
                            MessageBox.Show("Индекс уже существует!!!");
                            return;
                        }
                    }
                   
                }
                MyIndex index = new MyIndex();
                index.Index = Convert.ToInt32(txtIndex.Text);
                lstIndexs.Items.Add(index);
                FormServer.db.Mies.Add(index);
                FormServer.db.SaveChanges();
            }
        }

        private void FormIndex_Load(object sender, EventArgs e)
        {
            lstIndexs.Items.Clear();
            if(FormServer.db.Mies!=null)
            {
                foreach(var item in FormServer.db.Mies)
                {
                    lstIndexs.Items.Add(item.ToString());
                }
            }
        }

        private void btnAddStreet_Click(object sender, EventArgs e)
        {
            if(lstIndexs.Items==null)
            {
                MessageBox.Show("Список индексов пуст!!!");
                return;
            }
            if(lstIndexs.Items != null & lstIndexs.SelectedItem==null)
            {
                MessageBox.Show("Индекс не выбран!!!");
                return;
            }
            current.cur = Convert.ToInt32(lstIndexs.SelectedItem);
            if (lstIndexs.Items != null & lstIndexs.SelectedItem != null)
            {
                FormStreet formStreet = new FormStreet();
                formStreet.Show();
            }
           
        }

        private void lstIndexs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //current.cur = Convert.ToInt32(lstIndexs.SelectedItem);
            //FormStreet formStreet = new FormStreet();
            //formStreet.Show();

        }
    }
}
