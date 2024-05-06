using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI.CustomerUI
{
    public partial class ViewUndeliveredOrders : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();
        ICart cart = ObjectHandler.GetCartInstance();
        IUser user = ObjectHandler.GetUserInstance();
        ICustomer customer = ObjectHandler.GetCustomerInstance();
        IOrder order = ObjectHandler.GetOrderInstance();
        public ViewUndeliveredOrders()
        {
            InitializeComponent();
            LoadGridBox();
        }
        private void LoadGridBox()
        {
            string ActiveUser = user.GetActiveUser();

            DataTable dt = new DataTable();
            dt.Columns.Add("OrderID", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
            dt.Columns.Add("DeliveryType", typeof(string));


            dataGridView1.DataSource = dt;
            List<Order> orders = order.GetOrderListbyUserName(ActiveUser);
            foreach (Order order1 in orders)
            {
                if (order1.GetIsDelivered() == "No")
                {
                    Customer customer1 = order1.GetCustomer();
                    dt.Rows.Add(order1.GetOrderID(), order1.GetCart().GetTotalPriceOfCart(), order1.GetDeliveryType());
                }

            }

            dataGridView1.DataSource = dt;
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
                dt.Rows.Add(p.GetName(),p.GetPrice(),p.GetQuantity());
            }

            dataGridView2.DataSource = dt;

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
