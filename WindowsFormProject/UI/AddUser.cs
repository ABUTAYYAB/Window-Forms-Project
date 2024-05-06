using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using Guna.UI2.WinForms.Suite;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WindowsFormProject.UI
{
    public partial class AddUser : UserControl
    {
        IUser user = ObjectHandler.GetUserInstance();

        public AddUser()
        {
            InitializeComponent();
        }
        private void ClearData()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            comboBox1.Text = "";

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                string UserName = guna2TextBox1.Text;
                string Password = guna2TextBox2.Text;
                string Role = comboBox1.Text;
                if (UserName != "" && Password != "" && Role != "")
                {
                    if (UserValidation.IsStringValid(UserName) && UserValidation.IsStringValid(Password))
                    {
                        if (!(user.CheckIfUserNameAlreadyExist(UserName)))
                        {
                            User user1 = new User(UserName, Password, Role);
                            bool IsSignedUP = user.SignUP(user1);
                            if (IsSignedUP)
                            {
                                MessageBox.Show("Done");
                                ClearData();
                            }
                            else
                            {
                                MessageBox.Show("Not Added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("UserName already Exist ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        }
                    }
                    else
                    {
                        MessageBox.Show("Data Cannot Contain Letter % OR  and |", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            }

        }
    }
}
