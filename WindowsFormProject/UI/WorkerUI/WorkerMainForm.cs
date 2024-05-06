using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormProject.UI.CustomerUI;

namespace WindowsFormProject.UI.WorkerUI
{
    public partial class WorkerMainForm : Form
    {
        public WorkerMainForm()
        {
            InitializeComponent();
        }
        public Form ActiveForm;
        private void AddUserControl(UserControl usercontrol)
        {
            usercontrol.Dock = DockStyle.Fill;
            this.childpanel.Controls.Clear();
            this.childpanel.Controls.Add(usercontrol);
            usercontrol.BringToFront();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            AddProduct form = new AddProduct();
            AddUserControl(form);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveProduct form = new RemoveProduct();
            AddUserControl(form);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            UpdateProduct form = new UpdateProduct();
            AddUserControl(form);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CheckReviewofProducts form = new CheckReviewofProducts();
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

        private void button3_Click(object sender, EventArgs e)
        {
            ViewOrderWorker form = new ViewOrderWorker();
            AddUserControl(form);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SeeOrderDetailsWorker form = new SeeOrderDetailsWorker();
            AddUserControl(form);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AddComplain form = new AddComplain();
            AddUserControl(form);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearComplains form = new ClearComplains();
            AddUserControl(form);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateCustomerByWorker form = new UpdateCustomerByWorker();
            AddUserControl(form);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            WorkerDetails form = new WorkerDetails();
            AddUserControl(form);
        }
    }
}
