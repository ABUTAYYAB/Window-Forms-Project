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
    public partial class UpdateDeliveredOrders : UserControl
    {
        IOrder order = ObjectHandler.GetOrderInstance();
        IUser user = ObjectHandler.GetUserInstance();
        public UpdateDeliveredOrders()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string id = guna2TextBox1.Text;
            try
            {
                string ActiveUser = user.GetActiveUser();
                if (id != "")
                {
                    if (order.IsOrderIDAlreadyExisted(id))
                    {
                        bool check = order.SetOrderDelivered(id);
                        if (check) 
                        {
                            guna2TextBox1.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Order ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("Enter ID Of Order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            catch
            {
                MessageBox.Show("Error", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
