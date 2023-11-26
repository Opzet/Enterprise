

Install-Package EntityFramework

Install-Package EntityFramework.SqlServer

    C:\>sqllocaldb create DbInstance

    //Connection string is now 
    //Data Source=(localdb)\DbInstance;Initial Catalog=EFLocalDb;Integrated Security=True

    C:\>sqllocaldb info DbInstance
    Name:               DbInstance
    Version:            13.1.4001.0
    Shared name:
    Owner:              DEV\David
    Auto-create:        No
    State:              Stopped
    Last start time:    2/11/2021 1:02:19 PM
    Instance pipe name:  <- Pipe name entry missing, SqlLocalDB not started?  Should auto start

    C:\>SqlLocalDB start v11
    LocalDB instance "v11" started.

    C:\>sqllocaldb info DbInstance
    Name:               DbInstance
    Version:            13.1.4001.0
    Shared name:
    Owner:              DEV\David
    Auto-create:        No
    State:              Running
    Last start time:    2/11/2021 1:04:51 PM
    Instance pipe name: np:\\.\pipe\LOCALDB#385051FC\tsql\query



Add a new class to the project called `Crud_xxx.cs`

Add connection string lookup class to the project.  

This will allow us to switch between the testing and production databases.  

The testing database will be created and destroyed for each test run.  The production database will be used for the application.


Add to app.config, one for testing and one for deployment

  <connectionStrings>
    <add name="ConnectionName"
         connectionString="Data Source=(localdb)\mssqllocaldb;Initial Catalog=Inventory_TestingDb;Integrated Security=True;"
         providerName="System.Data.SqlClient" />
  </connectionStrings>




```c#
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
```