using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI.CustomerUI
{
    public partial class AddProductInCart : UserControl
    {
        ICart cart = ObjectHandler.GetCartInstance();
        IUser user = ObjectHandler.GetUserInstance();
        IProduct product = ObjectHandler.GetProductInstance();
        public AddProductInCart()
        {
            InitializeComponent();
            LoadGridBox();
        }
        private void LoadGridBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(string));

            dataGridView1.DataSource = dt;
            List<Product> List = product.GetProductsList();
            foreach (Product product1 in List)
            {
                dt.Rows.Add(product1.GetName(), product1.GetPrice());
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
            string UserName = user.GetActiveUser();
            string name = guna2TextBox1.Text;
            string QuantityString = guna2TextBox2.Text;

            //try
            //{
                if (name != "" && QuantityString != "")
                {
                    if (product.CheckIfProductAlreadyExist(name))
                    {

                        if (UserValidation.IsConvertibleToDouble(QuantityString))
                        {
                            double Quantity = UserValidation.ConvertStringIntoDouble(QuantityString);

                            double buyingQuantity, QuantityAvailable, Price;


                            buyingQuantity = Quantity + cart.GetProductQuantiytPresentInCart(UserName, name);


                            QuantityAvailable = product.GetQuantityOfProductAvailable(name);
                            Price = product.GetFinalPriceOfProductAvailable(name);

                            Product ProductForCartAddition = new Product(name, Price, buyingQuantity);

                            if (buyingQuantity <= QuantityAvailable)
                            {
                                if (cart.IsProductAlreadyExistInCart(UserName, name))
                                {
                                    bool check = cart.UpdateQuantityInCart(UserName, name, buyingQuantity);
                                    if (check)
                                    {
                                        LoadGridBox();
                                        MessageBox.Show("Done");
                                    }
                                }
                                else
                                {
                                    bool check = cart.AddProductInCart(UserName, ProductForCartAddition);//here put the cart itmes into the dat base
                                    if (check)
                                    {
                                        LoadGridBox();
                                        MessageBox.Show("Done");
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sorry This Much quantity is not Available", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Quantity Must be valid Integer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Product Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter All Data ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}

        }
    }
}
