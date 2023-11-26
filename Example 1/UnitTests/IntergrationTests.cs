using System;
using System.Linq;
using InventoryDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Migrations;


namespace IntergrationTests
{
    // Switch between a production and testing environment using a static property IsTesting within a ConnectionStrings class.
    // Depending on the value of IsTesting, the CRUD operations in the Crud_Products class will connect to either the production database or the testing database.
    /*
     *  Add to Db.cs 
     *
        public static class ConnectionStrings
        {
            public static  bool IsTesting { get; set; } = false;
            public static string Deploy { get; set; } = @"Name=InventoryDb";
            public static string Testing { get; set; } = @"Name=Inventory_TestingDb";
        }

    */

    [TestClass]
    public class ProductCrudIntegrationTests
    {
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            // Set to use the testing database
            ConnectionString.IsTesting = true;
            
            using (var db = new Db(ConnectionString.Get()))
            {
                db.Database.Initialize(true);
            }
            
            // Additional setup can be done here, like applying migrations to the test database
        }

        [TestMethod]
        public void CreateUpdate_Should_AddOrUpdateProduct()
        {
            // Arrange
            var newProduct = new Product { /* initialize with test data */
};

            // Act
            Crud_Products.CreateUpdate(newProduct);

            // Assert
            var product = Crud_Products.GetProduct(newProduct.Id);
            Assert.IsNotNull(product);
            // Other assertions to verify the product was created or updated correctly
        }

        //[TestMethod]
        //public void GetProduct_Should_ReturnProduct()
        //{
        //    // Arrange
        //    long existingProductId = /* an ID known to exist in the test database */;

        //    // Act
        //    var product = Crud_Products.GetProduct(existingProductId);

        //    // Assert
        //    Assert.IsNotNull(product);
        //    Assert.AreEqual(existingProductId, product.Id);
        //    // Other assertions as necessary
        //}

        // Additional test methods for ListProducts and DeleteProduct

        [ClassCleanup]
        public static void Cleanup()
        {
            // Cleanup test data from the testing database if necessary
            // Potentially drop the test database or apply other cleanup operations
        }
    }


}
