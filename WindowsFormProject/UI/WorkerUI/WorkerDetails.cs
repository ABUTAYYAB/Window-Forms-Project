using DairyDelightsLibrary.BL;
using DairyDelightsLibrary.Interface;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormProject.UI.WorkerUI
{
    public partial class WorkerDetails : UserControl
    {
        IUser user = ObjectHandler.GetUserInstance();
        IWorker worker = ObjectHandler.GetWorkerInstance();
        public WorkerDetails()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            string UserName = user.GetActiveUser();

            string salary = worker.GetSalaryByUserName(UserName);// implement a function to get salary on base of username
            string bonus = worker.GetBonusByUserName(UserName);



            if (salary != "")
            {
                guna2TextBox1.Text = salary;

            }
            else
            {
                guna2TextBox1.Text = "Ask Your Admin To Decide Your salary";
            }
            if (bonus != "")
            {
                guna2TextBox2.Text = bonus;

            }
            else
            {
                guna2TextBox2.Text = "Ask Your Admin To Decide Your Bonus";
            }
        }

        private void WorkerDetails_Load(object sender, System.EventArgs e)
        {

        }
    }
}
