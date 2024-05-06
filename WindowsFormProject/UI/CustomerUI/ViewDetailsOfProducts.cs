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

namespace WindowsFormProject.UI.CustomerUI
{
    public partial class ViewDetailsOfProducts : UserControl
    {
        IProduct product = ObjectHandler.GetProductInstance();

        public ViewDetailsOfProducts()
        {
            InitializeComponent();
            LoadGridBox();
        }
        private void LoadGridBox()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Discount", typeof(string));
            dt.Columns.Add("final Price", typeof(string));

            dataGridView1.DataSource = dt;
            List<Product> List = product.GetProductsList();
            foreach (Product product1 in List)
            {
                dt.Rows.Add(product1.GetName(), product1.GetPrice(), product1.GetQuantity(), product1.GetDescription(), product1.GetDiscount(), product1.GetFinalPrice());
            }
            dataGridView1.DataSource = dt;
        }
    }
}
