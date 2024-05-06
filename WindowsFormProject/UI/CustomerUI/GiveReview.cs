using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormProject.UI.CustomerUI
{
    public partial class GiveReview : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();

        public GiveReview()
        {
            InitializeComponent();
            LoadProductNames();
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
        private void ClearData()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = guna2TextBox1.Text;
                string Review = guna2TextBox2.Text;
                if (name != "" && Review != "")
                {
                    if (product.CheckIfProductAlreadyExist(name))
                    {
                        if (UserValidation.IsStringValid(Review))
                        {
                            bool check =product.AddReview(name, Review);
                            if (check) 
                            {
                                ClearData();
                                MessageBox.Show("Done");

                            }
                        }
                        else
                        {
                            MessageBox.Show("data cannot Contain '%',',','|'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Product not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("Enter All Data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
