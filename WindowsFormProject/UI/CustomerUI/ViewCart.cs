using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI.CustomerUI
{
    public partial class ViewCart : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();
        ICart cart = ObjectHandler.GetCartInstance();
        IUser user = ObjectHandler.GetUserInstance();
        public ViewCart()
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

        private void guna2Button2_Click(object sender, System.EventArgs e)
        {
            string Username = user.GetActiveUser();

            bool Check = cart.DeleteCart(Username);
            if (Check) 
            {
                LoadGridBox();
            }
        }
    }
}
