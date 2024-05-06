using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using Guna.UI2.WinForms;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI
{
    public partial class RemoveUser : UserControl
    {
        IUser user = ObjectHandler.GetUserInstance();

        public RemoveUser()
        {
            InitializeComponent();
            LoadGridBox();
        }
        private void LoadGridBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Role", typeof(string));
            dataGridView1.DataSource = dt;
            List<User> List = user.GetUsersList();
            foreach (User user1 in List)
            {
                if (user1.GetRole() != "Admin")
                {
                    dt.Rows.Add(user1.GetUserName(), user1.GetRole());

                }
            }
            dataGridView1.DataSource = dt;
        }
        private void ClearData()
        {
            guna2TextBox1.Text = "";
        }

        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            
            try
            {
                string UserName = guna2TextBox1.Text;

                if (UserName != "")
                {
                    if (UserValidation.IsStringValid(UserName))
                    {
                        if(user.CheckIfUserNameAlreadyExist(UserName)) 
                        {
                            string role = user.FindRoleByUserName(UserName);
                            if(role != "Admin") 
                            {
                                bool check = user.RemoveUser(UserName);
                                if (check)
                                {
                                    MessageBox.Show("Done");
                                    ClearData();
                                    LoadGridBox();
                                }
                                else
                                {
                                    MessageBox.Show("User not Removed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("You cannot Remove Admin.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("UserName Not Found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data Cannot Contain Letter '%' OR ',' And '|'.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
