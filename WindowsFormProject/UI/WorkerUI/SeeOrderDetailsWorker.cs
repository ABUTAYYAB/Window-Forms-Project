using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
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
    public partial class SeeOrderDetailsWorker : UserControl
    {
        IOrder order = ObjectHandler.GetOrderInstance();
        IUser user = ObjectHandler.GetUserInstance();
        public SeeOrderDetailsWorker()
        {
            InitializeComponent();
        }
        private void LoadDetailsGrid(string id)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));



            dataGridView1.DataSource = dt;
            List<Product> products = order.GetProductDetailsByOrderId(id);

            foreach (Product p in products)
            {
                dt.Rows.Add(p.GetName(), p.GetPrice(), p.GetQuantity());
            }

            dataGridView1.DataSource = dt;

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string id = guna2TextBox1.Text;
            try
            {
                string ActiveUser = user.GetActiveUser();
                if (id != "")
                {
                    if (order.IsOrderIDAlreadyExisted(id))
                    {
                        LoadDetailsGrid(id);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Order ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("Enter ID Of Order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
