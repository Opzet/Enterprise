using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryDb
{
    public static class View_Products
    {

     
        //Create / Read 
        public static void CreateUpdate(long id, string text, decimal value)
        {
            Product product = Crud_Products.GetProduct(id);
            product.Name = text;
            product.Quantity = (int)value;

            Crud_Products.CreateUpdate(product);
            

        }

        //Read
        public static void LoadProductsIntoListView(ListView listView)
        {
            // Assuming you have a method to get your products from the database
            IEnumerable<Product> products = Crud_Products.ListProducts();

            // Clear existing items
            listView.Items.Clear();

            // Iterate over the products and add them to the ListView
            foreach (var product in products)
            {
                // Create a new ListViewItem
                var item = new ListViewItem(product.Name);

                // Add the Quantity as a sub-item
                item.SubItems.Add(product.Quantity.ToString());

                // Add the ListViewItem to the ListView
                listView.Items.Add(item);
            }
        }

        //Delete


    }
}
