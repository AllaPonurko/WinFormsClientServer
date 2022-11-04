using System;
using System.Data;
using System.Windows.Forms;
using WinFormsServer.Entities;
using System.Linq;
namespace WinFormsServer.Views
{
    public partial class FormStreet : Form
    {
        public FormStreet()
        {
            InitializeComponent();
        }
        
        private void btnSaveStreet_Click(object sender, EventArgs e)
        {
            if(txtNameStreet.Text.Length==0)
            {
                MessageBox.Show("Улица не введёна!!!");
                return;
            }
            if (txtNameStreet.Text.Length != 0)
            {
                if(FormServer.db.Streets!=null)
                {
                    foreach(var item in FormServer.db.Streets)
                    {
                        if(item.Name== txtNameStreet.Text)
                        {
                            MessageBox.Show("Такая улица уже существует!!!");
                            return;
                        }
                    }
                }
            }
            Street street = new Street();
            street.Name = txtNameStreet.Text;
            foreach(var item in FormServer.db.Mies)
            {
                if(item.Index==Convert.ToInt32(txtCurrentIndex.Text))
                {
                    item.GetStreets.Add(street);
                }
            }
            lstStreets.Items.Add(street.ToString());
            FormServer.db.Streets.Add(street);
            FormServer.db.SaveChanges();
        }

        private void FormStreet_Load(object sender, EventArgs e)
        {
            txtCurrentIndex.Text = FormIndex.current.cur.ToString();
            lstStreets.Items.Clear();
            try
            {
                        var i = (from index in FormServer.db.Mies
                                 where index.Index == Convert.ToInt32(txtCurrentIndex.Text)
                                 select index).First();
                   
                        var s = (from streets in FormServer.db.Streets
                                 where i.Id == streets.MyIndexId
                                 select streets).ToArray();
                        lstStreets.Items.AddRange(s);
                   
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
