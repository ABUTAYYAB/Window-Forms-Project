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

namespace WindowsFormProject.UI
{
    public partial class AdminMainForm : Form
    {
        IUser user = ObjectHandler.GetUserInstance();
      
        private Button currentBtn;
        public AdminMainForm()
        {
            InitializeComponent();
        }

        public Form ActiveForm;
        private void AddUserControl(UserControl usercontrol)
        {
            usercontrol.Dock = DockStyle.Fill;
            this.childpanel.Controls.Clear();
            this.childpanel.Controls.Add(usercontrol);
            usercontrol.BringToFront();
        }
        private void OpenChildForm(Form ChildForm, object btnSender)
        {
            if(ActiveForm != null) 
            {
                ActiveForm.Close();
                ActivateButton(btnSender);
                ActiveForm = ChildForm;
                ChildForm.TopLevel = false;
                ChildForm.FormBorderStyle = FormBorderStyle.None;
                ChildForm.Dock = DockStyle.Fill;
                this.childpanel.Controls.Add(ChildForm);
                this.childpanel.Tag = ChildForm;
                ChildForm.BringToFront();
                ChildForm.Show();
                
            }
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {

        }
        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (Button)senderBtn;
                currentBtn.BackColor = Color.FromArgb(0, 90, 153);
               
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(0,90,255);

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender);
            //AdminAddUserForm a = new AdminAddUserForm();
            //OpenChildForm(a, sender);
            //AdminAddUserForm form = new AdminAddUserForm();
            //Child1 form = new Child1();
            //AddUserControl(form);


        }

        private void childpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser form = new AddUser();
            AddUserControl(form);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddUser form = new AddUser();
            AddUserControl(form);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveUser form = new RemoveUser();
            AddUserControl(form);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminOrder form = new AdminOrder();
            AddUserControl(form);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveProduct form = new RemoveProduct();
            AddUserControl(form);


        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddProduct form = new AddProduct();
            AddUserControl(form);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            CheckReviewofProducts form = new CheckReviewofProducts();
            AddUserControl(form);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            UpdateProduct form = new UpdateProduct();
            AddUserControl(form);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SeeComplains form =  new SeeComplains();
            AddUserControl(form);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateUser form = new UpdateUser();
            AddUserControl(form);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            UpdateDeliveryBoy form = new UpdateDeliveryBoy();
            AddUserControl(form);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            ChangePassword form = new ChangePassword();
            AddUserControl(form);

        }

        private void button14_Click(object sender, EventArgs e)
        {
            SignIN signIN = new SignIN();
            this.Hide();
            signIN.Show();

        }
    }
}
