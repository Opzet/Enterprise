using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    public static class CRUDWebApiDb
    {
        public static void init()
        {

            // If you don’t set a default connection factory,
            // Code First uses the SqlConnectionFactory,
            // pointing to .\SQLEXPRESS


            //(localdb)\mssqllocaldb
            /*
             
            sqllocaldb stop mssqllocaldb
            sqllocaldb delete mssqllocaldb
            sqllocaldb start "MSSQLLocalDB"
            or sqllocaldb create MSSQLLocalDB -s
            */
            using (var db = new WebApiDb())
            {
                db.Database.CreateIfNotExists();
            }

        }

        public static void Create(string Message)
        {
            using (var db = new WebApiDb())
            { 
                var msg = db.Messages.Create();
                msg.Text = Message;
                msg.DateTime = DateTime.Now;
                db.SaveChanges();
            }
        }

    }
}
