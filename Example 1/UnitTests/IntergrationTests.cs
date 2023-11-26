using System;
using System.Linq;
using InventoryDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;


//Install-Package Effort.EF6

// Effort(Entity Framework Fake ObjectContext Realization Tool) is a third - party library
// Creates a fake, in-memory context and can be used with EF 6 to provide in-memory testing capabilities.
// Effort works by creating a transient, in-memory database that can mimic database operations without a physical database.

namespace UnitTests
{
    [TestClass]
    public class Crud_ProductsTests
    {
        private InventoryDb.Db context;

        [TestInitialize]
        public void Initialize()
        {
            // Create a new Effort connection for each test to ensure isolation
            Effort.Provider.EffortConnection connection = Effort.DbConnectionFactory.CreateTransient();
            context = new InventoryDb.Db(connection);
        }

        [TestMethod]
        public void CreateUpdate_ProductDoesNotExist_AddsProduct()
        {
            // Arrange
            var product = new InventoryDb.Product { Id = 0, Name = "New Product", Quantity = 5 };

            // Act
            Crud_Products.CreateUpdate(product, context);

            // Assert
            var addedProduct = context.Products.FirstOrDefault(p => p.Name == "New Product");
            Assert.IsNotNull(addedProduct);
            Assert.AreEqual(5, addedProduct.Quantity);
        }

        // Add other tests here...

        [TestCleanup]
        public void CleanUp()
        {
            context.Dispose();
        }
    }

}
