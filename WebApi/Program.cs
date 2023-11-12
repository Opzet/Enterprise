using Db;
using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi
{

    class Program
    {
        static void Main(string[] args)
        {
            //Init Db
            CRUDWebApiDb.init();


            string baseAddress = "http://localhost:9000/"; // You can change the port number

            // Start OWIN host
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine($"Web API started at {baseAddress}");
                Console.WriteLine("Press <ENTER> to stop the server and close the app...");
                Console.ReadLine();
            }
        }
    }
}
