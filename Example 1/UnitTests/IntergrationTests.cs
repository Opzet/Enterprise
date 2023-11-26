using System;
using System.Linq;
using InventoryDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;


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

            SetupLocalDb("mssqllocaldb", "Inventory_TestingDb");

            // System.InvalidOperationException: 'No Entity Framework provider found for the ADO.NET provider with invariant name 'System.Data.SqlClient
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);
            if (type == null)
                throw new Exception("Do not remove, ensures static reference to System.Data.Entity.SqlServer");

            using (var db = new Db())
            {
                
                // Perform data access using the context
                db.Database.Log = Console.Write;
                //                db.Database.Delete();
                //                Debug.Print("Deleted DB");

                db.Database.Initialize(true);

                db.Database.CreateIfNotExists();
                Debug.Print("Created DB");
            }
            // Additional setup can be done here, like applying migrations to the test database
        }

        static void SetupLocalDb(string InstanceName = "mssqllocaldb", string DatabaseName = "xxx_TestingDb") 
        {
            //Step 1: Islocaldb installed?
            if (!CreateLocalDBInstance(InstanceName))
            {

                //MessageBox.Show("CRITICAL ERROR: SqlLocalDb software is not installed!");

                //Download SQL Server Express   - LocalDB
                // https://www.sqlshack.com/install-microsoft-sql-server-express-localdb/
                // https://www.microsoft.com/en-au/download/confirmation.aspx?id=101064
                // Microsoft SQL Server Express LocalDB supports silent installation. A user should download SqlLocalDB.msi and run the Command Prompt window as an administrator. Then, they should paste the following command:
                // msiexec /i SqlLocalDB.msi /qn IACCEPTSQLLOCALDBLICENSETERMS = YES
                string url = @"https://www.microsoft.com/en-au/download/confirmation.aspx?id=101064";
                Process.Start(url);

            }
        }

        static bool CreateLocalDBInstance(string InstanceName)
        {
            // Lists all instances
            // >sqllocaldb info

            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = $"/C sqllocaldb c {InstanceName}";  //Create Local Db Instance
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            p.Start();
            string sOutput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            //If LocalDb is not installed then it will return that 'sqllocaldb' is not recognized as an internal or external command operable program or batch file.
            if (sOutput == null || sOutput.Trim().Length == 0 || sOutput.Contains("not recognized"))
                return false;
            if (sOutput.ToLower().Contains(InstanceName))
                return true;
            return false;
        }


        [TestMethod]
        public void CreateProduct_Should_AddProductToDatabase()
        {
            // Arrange
            var newProduct = new Product { /* set properties with test data */ };

            // Act
            Crud_Products.CreateUpdate(newProduct);

            // Assert
            using (var db = new Db())
            {
                var addedProduct = db.Products.FirstOrDefault(p => p.Id == newProduct.Id);
                Assert.IsNotNull(addedProduct, "Product should not be null.");
                // Further assertions to verify the properties of the added product
            }
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
