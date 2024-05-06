using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI
{
    public partial class AdminOrder : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();
        ICart cart = ObjectHandler.GetCartInstance();
        IUser user = ObjectHandler.GetUserInstance();
        ICustomer customer = ObjectHandler.GetCustomerInstance();
        IOrder order = ObjectHandler.GetOrderInstance();
        public AdminOrder()
        {
            InitializeComponent();
            LoadGridBox();
        }
        private void LoadGridBox()
        {
            string ActiveUser = user.GetActiveUser();

            DataTable dt = new DataTable();
            dt.Columns.Add("OrderID", typeof(string));
            dt.Columns.Add("Customer", typeof(string));
            dt.Columns.Add("Phone Number", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
            dt.Columns.Add("DeliveryType", typeof(string));
            dt.Columns.Add("DeliverdYet", typeof(string));



            dataGridView1.DataSource = dt;
            List<Order> orders = order.GetAllOrders();
            foreach (Order order1 in orders)
            {

                Customer customer1 = order1.GetCustomer();
                dt.Rows.Add(order1.GetOrderID(),customer1.GetUserName(),customer1.GetPhoneNumber(),customer1.GetAddress(), order1.GetCart().GetTotalPriceOfCart(), order1.GetDeliveryType(),order1.GetIsDelivered());


            }

            dataGridView1.DataSource = dt;

            double Sale = order.GetSales();
            if(Sale > 0)
            {
                guna2TextBox2.Text = Sale.ToString();
            }
            else
            {
                guna2TextBox2.Text = "No Sales Yet";
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

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
                        LoadGridBox();
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
        private void LoadDetailsGrid(string id)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));

            dataGridView2.DataSource = dt;
            List<Product> products = order.GetProductDetailsByOrderId(id);

            foreach (Product p in products)
            {
                dt.Rows.Add(p.GetName(), p.GetPrice(), p.GetQuantity());
            }

            dataGridView2.DataSource = dt;

        }
    }
}
