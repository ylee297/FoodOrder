using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Program
    {
        private static string _connStr = @"
          Server=127.0.0.1,1433;
          Database=Master;
          User Id=SA;
          Password=4wnr8dmadbs
       ";

        public static void Main(string[] args)
        {
            using (var conn =
         new SqlConnection(_connStr))
            {
                conn.Open();

                var cmd = new SqlCommand(@"
            SELECT *
            FROM master..sysdatabases;
         ", conn);

                var reader =
                   cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(
                       reader["Name"]
                    );
                }
            }

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
