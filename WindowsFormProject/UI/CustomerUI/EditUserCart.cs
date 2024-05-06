using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI.CustomerUI
{
    public partial class EditUserCart : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();
        ICart cart = ObjectHandler.GetCartInstance();
        IUser user = ObjectHandler.GetUserInstance();

        public EditUserCart()
        {
            InitializeComponent();
            LoadGridBox();
        }
        private void LoadGridBox()
        {
            string Username = user.GetActiveUser();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Quantity In KG", typeof(string));


            dataGridView1.DataSource = dt;
            List<Product> List = cart.GetProductsListFromCart(Username);
            foreach (Product product1 in List)
            {
                dt.Rows.Add(product1.GetName(), product1.GetPrice(), product1.GetQuantity());
            }
            dataGridView1.DataSource = dt;

            Cart UserCart = new Cart(List);
            double Price = UserCart.GetTotalPriceOfCart();
            if (Price == 0)
            {
                guna2TextBox3.Text = "Your Cart Is Empty";
            }
            else
            {
                guna2TextBox3.Text = Price.ToString();
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string UserName = user.GetActiveUser();
            string name = guna2TextBox1.Text;
            string QuantityString = guna2TextBox2.Text;

            try
            {
                if (name != "" && QuantityString != "")
                {
                    if (cart.IsProductAlreadyExistInCart(UserName, name))
                    {

                        if (UserValidation.IsConvertibleToDouble(QuantityString))
                        {
                            double Quantity = UserValidation.ConvertStringIntoDouble(QuantityString);

                            double buyingQuantity, QuantityAvailable;

                            buyingQuantity = Quantity + cart.GetProductQuantiytPresentInCart(UserName, name);


                            QuantityAvailable = product.GetQuantityOfProductAvailable(name);

                            if (buyingQuantity <= QuantityAvailable)
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
                        MessageBox.Show("Enter Valid Product Which is Available in Cart", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter All Data ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string UserName = user.GetActiveUser();
            string name = guna2TextBox1.Text;
            string QuantityString = guna2TextBox2.Text;

            try
            {
                if (name != "" && QuantityString != "")
                {
                    if (cart.IsProductAlreadyExistInCart(UserName, name))
                    {

                        if (UserValidation.IsConvertibleToDouble(QuantityString))
                        {
                            double Quantity = UserValidation.ConvertStringIntoDouble(QuantityString);

                            double buyingQuantity;
                            buyingQuantity = cart.GetProductQuantiytPresentInCart(UserName, name) - Quantity;

                            if (buyingQuantity >= 0)
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
                                MessageBox.Show("Sorry This Much quantity is not Available in Your Cart", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Quantity Must be valid Integer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Product Which is Available in Cart", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter All Data ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            string UserName = user.GetActiveUser();
            string name = guna2TextBox1.Text;

            try
            {
                if (name != "")
                {
                    if (cart.IsProductAlreadyExistInCart(UserName, name))
                    {

                        bool check = cart.RemoveProductFromCart(UserName,name);
                        if (check)
                        {
                            LoadGridBox();
                            MessageBox.Show("Done");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Enter Valid Product Which is Available in Cart", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please Product Name You want to Remove ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
    }
}
