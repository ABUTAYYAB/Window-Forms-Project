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
    public partial class CustomerMainForm : Form
    {
        public CustomerMainForm()
        {
            InitializeComponent();
        }
        private void AddUserControl(UserControl usercontrol)
        {
            usercontrol.Dock = DockStyle.Fill;
            this.childpanel.Controls.Clear();
            this.childpanel.Controls.Add(usercontrol);
            usercontrol.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewProducts form = new ViewProducts();
            AddUserControl(form);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewReviewsOfProducts form = new ViewReviewsOfProducts();
            AddUserControl(form);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewDetailsOfProducts form = new ViewDetailsOfProducts();
            AddUserControl(form);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            GiveReview form = new GiveReview();
            AddUserControl(form);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SignIN signIN = new SignIN();
            this.Hide();
            signIN.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword();
            AddUserControl(form);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UpdateCustomer form = new UpdateCustomer();
            AddUserControl(form);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewCart form = new ViewCart();
            AddUserControl(form);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            AddProductInCart form = new AddProductInCart();
            AddUserControl(form);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            EditUserCart from = new EditUserCart();
            AddUserControl(from);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BuyCart form = new BuyCart();
            AddUserControl(form);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ViewUndeliveredOrders form = new ViewUndeliveredOrders();
            AddUserControl(form);
        }
    }
}
