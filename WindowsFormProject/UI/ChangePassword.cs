using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormProject.UI
{
    public partial class ChangePassword : UserControl
    {
        IUser user = ObjectHandler.GetUserInstance();

        public ChangePassword()
        {
            InitializeComponent();
        }
        private void ClearData()
        {
            guna2TextBox2.Text = "";
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string password = guna2TextBox2.Text;
                if (password != "")
                {
                    if (UserValidation.IsStringValid(password))
                    {
                        bool check = user.ChangePassword(password);
                        if (check)
                        {
                            MessageBox.Show("Done");
                            ClearData();
                        }
                        else
                        {
                            MessageBox.Show("Not Changed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data Cannot Contain Letter '%' OR ',' And '|'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
