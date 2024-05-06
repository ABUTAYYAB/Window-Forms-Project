using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI
{
    public partial class UpdateUser : UserControl
    {
        IUser user = ObjectHandler.GetUserInstance();
        IWorker worker = ObjectHandler.GetWorkerInstance();

        public UpdateUser()
        {
            InitializeComponent();
            LoadGridBox();
        }
        private void LoadGridBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("salary", typeof(string));
            dt.Columns.Add("Bonus", typeof(string));

            dataGridView1.DataSource = dt;
            List<Worker> List = worker.GetWorkerList();
            foreach (Worker worker in List)
            {

                dt.Rows.Add(worker.GetUserName(), worker.GetPassword(), worker.GetSalary(), worker.GetBonus());


            }
            dataGridView1.DataSource = dt;
        }
        private void ClearData()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
        }

        private void guna2Button1_Click(object sender, System.EventArgs e)
        {
            try
            {

                string username = guna2TextBox1.Text;
                string password = guna2TextBox2.Text;
                string Salary = guna2TextBox3.Text;
                string Bonus = guna2TextBox4.Text;


                if (username != "")
                {
                    if (UserValidation.IsStringValid(Salary) && UserValidation.IsStringValid(Bonus) && UserValidation.IsStringValid(password))
                    {

                        bool check = user.CheckIfUserNameAlreadyExist(username);
                        if (check)
                        {
                            if (password != "")
                            {
                                bool Ispasschanged = user.ChangePasswordByUserName(username, password);
                            }
                            if (Salary != "")
                            {
                                if (UserValidation.IsConvertibleToDouble(Salary))
                                {
                                    bool IsSalaryCHanged = worker.ChangeSalaryByUserName(username, Salary);
                                }
                                else
                                {
                                    MessageBox.Show("Salary Not changed Enter Valid integer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            if (Bonus != "")
                            {
                                if (UserValidation.IsConvertibleToDouble(Bonus))
                                {
                                    bool IsBonusChanged = worker.ChangeBonusByUserName(username, Bonus);
                                }
                                else
                                {
                                    MessageBox.Show("Bonus Not changed Enter Valid integer.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            ClearData();
                            LoadGridBox();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect Username.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Data Cannot Contain Letter '%' OR ','.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Enter Username of Worker.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
