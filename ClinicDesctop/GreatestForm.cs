using CSClientNamespace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicDesctop
{
    public partial class GreatestForm : Form
    {
        public GreatestForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            CSClient clientCS = new CSClient("http://localhost:5091/", new System.Net.Http.HttpClient());

            ICollection<Client> clients = clientCS.ClientGetAllAsync().Result;

            listView1Clients.Items.Clear();
            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.ClientId.ToString();
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.SurName
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.FirstName
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.Patronymic
                });

                listView1Clients.Items.Add(item);
            }   
        }
    }
}
