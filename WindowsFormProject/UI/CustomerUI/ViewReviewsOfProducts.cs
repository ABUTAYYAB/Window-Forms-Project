using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI.CustomerUI
{
    public partial class ViewReviewsOfProducts : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();

        public ViewReviewsOfProducts()
        {
            InitializeComponent();
            LoadProductNames();
        }
        private void ViewReviewsOfScpecificProduct(string name)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Reviews", typeof(string));

            List<Product> products = product.GetProductsList();

            foreach (Product product in products)
            {
                List<string> list = product.GetReviews();
                for (int i = 0; i < list.Count; i++)
                {
                    if (product.GetName() == name)
                    {
                        if (list[i] != "")
                        {
                            dt.Rows.Add(list[i]);

                        }

                    }
                }
            }

            dataGridView2.DataSource = dt;


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = guna2TextBox1.Text;
                if (name != "")
                {
                    ViewReviewsOfScpecificProduct(name);
                    LoadProductNames();
                }
                else
                {
                    MessageBox.Show("Please valid Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
        private void LoadProductNames()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));

            dataGridView1.DataSource = dt;
            List<Product> List = product.GetProductsList();
            foreach (Product product1 in List)
            {
                dt.Rows.Add(product1.GetName());
            }
            dataGridView1.DataSource = dt;
        }
    }
}
