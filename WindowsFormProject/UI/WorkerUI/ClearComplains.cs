using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormProject.UI.WorkerUI
{
    public partial class ClearComplains : UserControl
    {
        IUser user = ObjectHandler.GetUserInstance();
        IWorker worker = ObjectHandler.GetWorkerInstance();

        public ClearComplains()
        {
            InitializeComponent();
            LoadGridBox();
        }
        private void LoadGridBox()
        {
            string Username = user.GetActiveUser();

            DataTable dt = new DataTable();
            dt.Columns.Add("Complains", typeof(string));

            dataGridView1.DataSource = dt;
            List<string> List = worker.GetComplainsList(Username);
            foreach (string complain in List)
            {
                if(complain != "")
                {
                    dt.Rows.Add(complain);

                }
            }
            dataGridView1.DataSource = dt;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string Username = user.GetActiveUser();
            bool check = worker.ClearComplainsByUserName(Username);
            if (check) 
            {
                MessageBox.Show("Done");
                LoadGridBox();
            }
        }
    }
}
