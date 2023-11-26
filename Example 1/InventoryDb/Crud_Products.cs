using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts; // Make sure you have this for EntityState

namespace InventoryDb
{
    public static class ConnectionString
    {
        public static bool IsTesting { get; set; } = false;

        public static string Get()
        {
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");

            if (IsTesting)
            {
                return @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Inventory_TestingDb;Integrated Security=True;";
            }
            else
            {
                return @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=InventoryDb;Integrated Security=True;";
            }
        }
    }

    

    public static class Crud_Products
    {
       
        public static void Initialize()
        {
            // Initaliase the DB, create Db if it does not exist
            //See http://go.microsoft.com/fwlink/?LinkId=260882 
            using (var db = new Db(ConnectionString.Get()))
            {
               db.Database.Initialize(true);
            }
           
            // Additional setup can be done here, like applying migrations to the test database
        }

        // Db Create/ Update
        public static void CreateUpdate(Product product)
        {
            using (var db = new Db(ConnectionString.Get()))
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

            using (var db = new Db(ConnectionString.Get()))
            {
                return db.Products.Find(id);
            }
        }

        // Db Read all
        public static IEnumerable<Product> ListProducts()
        {
            using (var db = new Db(ConnectionString.Get()))
            {
                return db.Products.ToList();
            }
        }

        // Db Delete
        public static void DeleteProduct(long id)
        {
            using (var db = new Db(ConnectionString.Get()))
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
