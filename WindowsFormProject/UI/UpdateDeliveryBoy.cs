using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using DairyDelightsLibrary.Validation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormProject.UI
{
    public partial class UpdateDeliveryBoy : UserControl
    {
        iDeliveryBoy deliveryboy = ObjectHandler.GetDeliveryBoyInstance();
        IUser user = ObjectHandler.GetUserInstance();
        public UpdateDeliveryBoy()
        {
            InitializeComponent();
            LoadGridBox();
        }
        private void LoadGridBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("BikeNumber", typeof(string));
            dt.Columns.Add("PhoneNumber", typeof(string));
            dt.Columns.Add("salary", typeof(string));

            dataGridView1.DataSource = dt;
            List<DeliveryBoy> List = deliveryboy.GetDeliveryBoyList();
            foreach (DeliveryBoy boy in List)
            {

                dt.Rows.Add(boy.GetUserName(), boy.GetPassword(), boy.GetBikeNumber(), boy.GetPhoneNumber(), boy.GetSalary());


            }
            dataGridView1.DataSource = dt;
        }

        private void UpdateDeliveryBoy_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string username = guna2TextBox1.Text;
                string password = guna2TextBox2.Text;
                string PhoneNo = guna2TextBox3.Text;
                string BikeNo = guna2TextBox4.Text;
                string Salary = guna2TextBox5.Text;
                if (username != "")
                {
                    if (UserValidation.IsStringValid(username) && UserValidation.IsStringValid(password) && UserValidation.IsStringValid(PhoneNo) && UserValidation.IsStringValid(BikeNo) && UserValidation.IsStringValid(Salary))
                    {
                        bool check = user.CheckIfUserNameAlreadyExist(username);
                        if (check)
                        {
                            if (password != "")
                            {
                                bool Ispasschanged = deliveryboy.ChangePasswordByUserName(username, password);
                            }
                            if (PhoneNo != "")
                            {
                                if(UserValidation.IsPhoneNumberValid(PhoneNo))
                                {
                                bool IsBonusChanged = deliveryboy.ChangePhoneNumByUserName(username, PhoneNo);

                                }
                                else
                                {
                                    MessageBox.Show("Incorrect Phone Number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }
                            }
                            if (BikeNo != "")
                            {
                                bool IsBonusChanged = deliveryboy.ChangeBikeNumByUserName(username, BikeNo);
                            }
                            if (Salary != "")
                            {
                                if (UserValidation.IsConvertibleToDouble(Salary))
                                {
                                    bool IsSalaryCHanged = deliveryboy.ChangeSalaryByUserName(username, Salary);

                                }
                                else
                                {
                                    MessageBox.Show("Enter valid salary.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("Enter Username of Deliveryboy.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ClearData()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox5.Text = "";

        }
    }
}
