using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System;
using System.Windows.Forms;

namespace WindowsFormProject.UI.WorkerUI
{
    public partial class AddComplain : UserControl
    {
        IWorker worker = ObjectHandler.GetWorkerInstance();
        IUser user = ObjectHandler.GetUserInstance();
        public AddComplain()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                string complains = guna2TextBox1.Text;
                string ActiveUser = user.GetActiveUser();
                if (complains != "")
                {
                    if (UserValidation.IsStringValid(complains))
                    {
                        bool check = worker.AddComplain(ActiveUser, complains);
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
                        MessageBox.Show("Data Cannot Contain Letter '%' OR ','.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter complete data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            //}
            //catch
            //{
            //    MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //}
        }
        private void ClearData()
        {
            guna2TextBox1.Text = "";
        }
    }
}
