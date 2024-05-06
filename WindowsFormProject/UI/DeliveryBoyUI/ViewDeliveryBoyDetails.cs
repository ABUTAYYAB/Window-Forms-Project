using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormProject.UI.DeliveryBoyUI
{
    public partial class ViewDeliveryBoyDetails : UserControl
    {
        IUser user = ObjectHandler.GetUserInstance();
        IWorker worker = ObjectHandler.GetWorkerInstance();
        iDeliveryBoy deliveryBoy = ObjectHandler.GetDeliveryBoyInstance();
        public ViewDeliveryBoyDetails()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            string UserName = user.GetActiveUser();

            string salary = deliveryBoy.GetSalaryByUserName(UserName);// implement a function to get salary on base of username
            string bike =deliveryBoy.GetBikeNumberByUserName(UserName) ;
            string phoneno = deliveryBoy.GetPhoneNumberByUserName(UserName);




            if (salary != "")
            {
                guna2TextBox1.Text = salary;

            }
            else
            {
                guna2TextBox1.Text = "Ask Your Admin To Decide Your salary";
            }
            if (bike != "")
            {
                guna2TextBox2.Text = bike;

            }
            else
            {
                guna2TextBox2.Text = "Ask Your Admin to Add your bike No";
            }
            if (phoneno != "")
            {
                guna2TextBox3.Text = phoneno;

            }
            else
            {
                guna2TextBox3.Text = "Ask Your Admin to Add your Phone No";
            }
        }

        private void ViewDeliveryBoyDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
