using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System;
using System.Windows.Forms;

namespace WindowsFormProject.UI.CustomerUI
{
    public partial class UpdateCustomer : UserControl
    {
        ICustomer customer = ObjectHandler.GetCustomerInstance();
        IUser user = ObjectHandler.GetUserInstance();

        public UpdateCustomer()
        {
            InitializeComponent();
            LoadDataInTextBox();
        }
        private void LoadDataInTextBox()
        {
            string activeuser = user.GetActiveUser();
            string phoneno = customer.GetPhonenNumberByUserName(activeuser);
            string address = customer.GetAddressByUserName(activeuser);
            if (phoneno == "")
            {
                phoneno = "You Havn't Added Phone Number";
            }
            if (address == "")
            {
                address = "You Havn't Added Address";
            }
            guna2TextBox1.Text = address;
            guna2TextBox2.Text = phoneno;

            // Make the text boxes read-only
            guna2TextBox1.ReadOnly = true;
            guna2TextBox2.ReadOnly = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


            try
            {
                string NewPhoneNumber = guna2TextBox3.Text;
                string NewAddress = guna2TextBox4.Text;
                string activeuser = user.GetActiveUser();
                if (UserValidation.IsStringValid(NewAddress) && UserValidation.IsStringValid(NewPhoneNumber))
                {
                    if (NewAddress != "")
                    {
                        bool check = customer.ChangeAddressByUserName(activeuser, NewAddress);
                    }
                    if (NewPhoneNumber != "")
                    {
                        if (UserValidation.IsPhoneNumberValid(NewPhoneNumber))
                        {
                            bool check = customer.ChangePhonenNumberByUserName(activeuser, NewPhoneNumber);

                        }
                        else
                        {
                            MessageBox.Show("Enter Valid Phone Number ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    ClearData();
                    LoadDataInTextBox();
                }
                else
                {
                    MessageBox.Show("Data Cannot Contain Letter '%' OR ',','|'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
        private void ClearData()
        {
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
        }
    }
}
