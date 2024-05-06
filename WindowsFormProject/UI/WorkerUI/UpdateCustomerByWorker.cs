using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormProject.UI.WorkerUI
{
    public partial class UpdateCustomerByWorker : UserControl
    {
        IUser user = ObjectHandler.GetUserInstance();

        public UpdateCustomerByWorker()
        {
            InitializeComponent();
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
                string password = guna2TextBox2.Text;
                if (UserName != "" && password != "")
                {
                    if (UserValidation.IsStringValid(UserName) && UserValidation.IsStringValid(password))
                    {
                        if (user.CheckIfUserNameAlreadyExist(UserName))
                        {
                            bool check = user.ChangePasswordByUserName(UserName, password);
                            if (check)
                            {
                                ClearData();
                                MessageBox.Show("Done");
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Data Cannot Contain Letter '%' OR ','.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
