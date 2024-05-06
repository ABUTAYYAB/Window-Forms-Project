using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.DL.DataBase;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI.CustomerUI
{
    public partial class BuyCart : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();
        ICart cart = ObjectHandler.GetCartInstance();
        IUser user = ObjectHandler.GetUserInstance();
        ICustomer customer = ObjectHandler.GetCustomerInstance();
        IOrder order = ObjectHandler.GetOrderInstance();

        public BuyCart()
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
                guna2TextBox1.Text = "Your Cart Is Empty";
            }
            else
            {
                guna2TextBox1.Text = Price.ToString();
            }

        }

        private string GetUniqueOrderID()
        {
            string id;
            id = HelpingFunctions.GenerateRandomOrderID();
            bool Notunique = true;
            while (Notunique)
            {
                id = HelpingFunctions.GenerateRandomOrderID();
                bool check = order.IsOrderIDAlreadyExisted(id);
                if (check)
                {
                    continue;
                }
                else
                {
                    Notunique = false;
                }
            }
            return id;
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string Username = user.GetActiveUser();
            string Deliverytype = comboBox1.Text;

            List<Product> List = cart.GetProductsListFromCart(Username);
            Cart UserCart = new Cart(List);

            double CartPrice = UserCart.GetTotalPriceOfCart();

            try
            {
                if (CartPrice != 0)
                {
                    if (Deliverytype != "")
                    {
                        string activeuser = user.GetActiveUser();
                        string phoneno = customer.GetPhonenNumberByUserName(activeuser);
                        string address = customer.GetAddressByUserName(activeuser);
                        if (phoneno != "" && address != "")
                        {
                            string id = GetUniqueOrderID();
                            Customer customer1 = new Customer(activeuser, phoneno, address);
                            Order order1 = new Order(id, UserCart, customer1, Deliverytype, CartPrice.ToString());
                            bool check = order.AddOrder(order1);
                            if (check)
                            {
                                bool Check = cart.DeleteCart(Username);
                                if (Check)
                                {
                                    check = UpdateQuantityInDataBase(List);
                                    {
                                        ClearData();
                                        LoadGridBox();
                                    }
                                    
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Your Details Before Buying anything", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Select Delivery Methhod ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Cart Empty ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void ClearData()
        {
            comboBox1.Text = "";
        }
        private bool UpdateQuantityInDataBase(List<Product> products)
        {
            foreach (Product i in products) 
            {
                double quantityinCart = i.GetQuantity();
                double quantityinstock = product.GetQuantityOfProductAvailable(i.GetName());
                double newquantity = quantityinstock - quantityinCart;
                if(newquantity >= 0) 
                {
                    bool check = product.ChangeQuantityByName(i.GetName(), newquantity.ToString());
                }
                else
                {
                    newquantity = 0;
                    bool check = product.ChangeQuantityByName(i.GetName(), newquantity.ToString());
                }
            }
            return true;
        }
    }
}
