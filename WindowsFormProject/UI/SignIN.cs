using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.DL.DataBase;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using Guna.UI2.WinForms;
using System;
using System.Windows.Forms;

namespace WindowsFormProject.UI
{
    public partial class SignIN : Form
    {
        IUser user = ObjectHandler.GetUserInstance();

        public SignIN()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUP signUP = new SignUP();
            this.Hide();
            signUP.Show();
        }
        private void ClearData()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string UserName = guna2TextBox1.Text;
                string Password = guna2TextBox2.Text;

                if (UserName != "" && Password != "")
                {
                    string Role = user.SignIN(UserName, Password);
                    if (Role == "UserNotFound")
                    {
                        MessageBox.Show("Username or Password is Incorrect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ClearData();
                    }
                    else if (Role == "Customer")
                    {
                        //Call The user Form of Customer
                        CustomerUI.CustomerMainForm form = new CustomerUI.CustomerMainForm();
                        this.Hide();  
                        form.Show();
                    }
                    else if (Role == "Worker")
                    {
                        //Call The user Form of Worker 
                        WorkerUI.WorkerMainForm form = new WorkerUI.WorkerMainForm();
                        this.Hide();
                        form.Show();
                    }
                    else if (Role == "DeliveryBoy")
                    {
                        //Call The user Form of Delivery Boy
                        DeliveryBoyUI.DeliveryBoyMainForm form = new DeliveryBoyUI.DeliveryBoyMainForm();
                        this.Hide();
                        form.Show();
                    }
                    else if (Role == "Admin")
                    {
                        //Call The user Form of  Admin
                        AdminMainForm form = new AdminMainForm();
                        this.Hide();
                        form.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter complete data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearData();
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            guna2TextBox2.PasswordChar = guna2TextBox2.PasswordChar == '\0' ? '*' : '\0';
        }
    }
}
