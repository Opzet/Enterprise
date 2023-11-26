using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryDb;

namespace WinformApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitListView();
        }

        void InitListView()
        {  
            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Display check boxes.
            listView1.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;

            // Create two columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listView1.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Quantity", -2, HorizontalAlignment.Left);
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            long id = -1;
            if (listView1.SelectedItems.Count > 0)
                id = (long)listView1.SelectedItems[0].Tag;

            View_Products.CreateUpdate(id, txtName.Text, numQty.Value);
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            View_Products.LoadProductsIntoListView(listView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Crud_Products.Initialize();
        }
    }
}
