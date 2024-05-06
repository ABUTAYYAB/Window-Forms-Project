using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI.WorkerUI
{
    public partial class ViewOrderWorker : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();
        ICart cart = ObjectHandler.GetCartInstance();
        IUser user = ObjectHandler.GetUserInstance();
        ICustomer customer = ObjectHandler.GetCustomerInstance();
        IOrder order = ObjectHandler.GetOrderInstance();
        public ViewOrderWorker()
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



            dataGridView1.DataSource = dt;
            List<Order> orders = order.GetAllOrders();
            foreach (Order order1 in orders)
            {
                if (order1.GetIsDelivered() == "No")
                {
                    Customer customer1 = order1.GetCustomer();
                    dt.Rows.Add(order1.GetOrderID(), customer1.GetUserName(), customer1.GetPhoneNumber(), customer1.GetAddress(), order1.GetCart().GetTotalPriceOfCart(), order1.GetDeliveryType());
                }
            }

            dataGridView1.DataSource = dt;
        }
    }
}
