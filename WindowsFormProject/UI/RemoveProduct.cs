using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI
{
    public partial class RemoveProduct : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();
        ICart cart = ObjectHandler.GetCartInstance();


        public RemoveProduct()
        {
            InitializeComponent();
            LoadGridBox();
        }
        private void LoadGridBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Discount", typeof(string));
            dt.Columns.Add("final Price", typeof(string));

            dataGridView1.DataSource = dt;
            List<Product> List = product.GetProductsList();
            foreach (Product product1 in List)
            {
                dt.Rows.Add(product1.GetName(), product1.GetPrice(), product1.GetQuantity(), product1.GetDescription(), product1.GetDiscount(), product1.GetFinalPrice());
            }
            dataGridView1.DataSource = dt;
        }
        private void ClearData()
        {
            guna2TextBox1.Text = "";
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            //try
            //{
                string Name = guna2TextBox1.Text;


                if (Name != "")
                {
                    if (UserValidation.IsStringValid(Name))
                    {
                        bool check = product.CheckIfProductAlreadyExist(Name);

                        if (check)
                        {
                            bool check1 = product.Removeproduct(Name);
                            if (check1)
                            {
                                bool RemoveFromCartsAlso = cart.RemoveProductFromCartForAdmin(Name);
                                if (RemoveFromCartsAlso)
                                {
                                    MessageBox.Show("Done");
                                    ClearData();
                                    LoadGridBox();
                                }

                            }
                            else
                            {
                                MessageBox.Show("Not Changed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("UserName Not Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data Cannot Contain Letter '%' OR ','.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Please enter complete data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            //}
            //catch
            //{
            //    MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    ClearData();
            //}

        }
    }
}
