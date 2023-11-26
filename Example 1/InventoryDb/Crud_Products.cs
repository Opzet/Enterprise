using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts; // Make sure you have this for EntityState

namespace InventoryDb
{
    public static class Crud_Products
    {
        // Db Create/ Update
        public static void CreateUpdate(Product product)
        {
            using (var db = new Db())
            {
                if (product.Id == -1) // Assuming -1 is an unsaved product
                {
                    db.Products.Add(product);
                }
                else
                {
                    db.Entry(product).State = EntityState.Modified;
                }

                db.SaveChanges();
            }
        }

        // Db Read one
        public static Product GetProduct(long id)
        {
            if (id == -1)
                return new Product();

            using (var db = new Db())
            {
                return db.Products.Find(id);
            }
        }

        // Db Read all
        public static IEnumerable<Product> ListProducts()
        {
            using (var db = new Db())
            {
                return db.Products.ToList();
            }
        }

        // Db Delete
        public static void DeleteProduct(long id)
        {
            using (var db = new Db())
            {
                var product = db.Products.Find(id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
            }
        }
    }
}
