using System;
using System.Data;
using Basics.Data;
using Basics.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();

            DataContextDapper dapper = new DataContextDapper(config);

            DataContextEF entityFramework = new DataContextEF(config);

            string sqlCommad = "SELECT GETDATE()";

            DateTime rightNow = dapper.LoadDataSingle<DateTime>(sqlCommad);

            // Console.WriteLine(rightNow);

            Computer myComputer = new Computer() {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 999.99m,
                VideoCard = "RTX 2060"
            };

            entityFramework.Add(myComputer);
            entityFramework.SaveChanges();

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                HasWifi,
                HasLTE,
                ReleaseDate,
                Price,
                VideoCard
            ) VALUES ('" + myComputer.Motherboard 
                    + "','" + myComputer.HasWifi
                    + "','" + myComputer.HasLTE
                    + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
                    + "','" + myComputer.Price
                    + "','" + myComputer.VideoCard 
            + "')";

            // Console.WriteLine(sql);

            bool result = dapper.ExecuteSql(sql);

            // Console.WriteLine(result);

            string sqlSelect = @"SELECT 
                Computer.ComputerId,
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
             FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);

            // IEnumerable<Computer>? computersEF = entityFramework.Computer?.ToList<Computer>();

            Console.WriteLine("'ComputerId', 'Motherboard', 'HasWifi', 'HasLTE', 'ReleaseDate', 'Price', 'VideoCard'");

            foreach(Computer singleComputer in computers)
            {
                Console.WriteLine("'" + singleComputer.ComputerId 
                    + "','" + singleComputer.Motherboard
                    + "','" + singleComputer.HasWifi
                    + "','" + singleComputer.HasLTE
                    + "','" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
                    + "','" + singleComputer.Price
                    + "','" + singleComputer.VideoCard 
                    +"'");
            }

            IEnumerable<Computer>? computersEF = entityFramework.Computer?.ToList<Computer>();

            
            if(computersEF != null)
            {
                Console.WriteLine("'ComputerId', 'Motherboard', 'HasWifi', 'HasLTE', 'ReleaseDate', 'Price', 'VideoCard'");

                foreach(Computer singleComputer in computersEF)
                {
                    Console.WriteLine("'" + singleComputer.ComputerId 
                        + "','" + singleComputer.Motherboard
                        + "','" + singleComputer.HasWifi
                        + "','" + singleComputer.HasLTE
                        + "','" + singleComputer.ReleaseDate.ToString("yyyy-MM-dd")
                        + "','" + singleComputer.Price
                        + "','" + singleComputer.VideoCard 
                        +"'");
                }
            }

            // myComputer.HasWifi = false;

            // Console.WriteLine(myComputer.Motherboard);
            // Console.WriteLine(myComputer.HasLTE);
            // Console.WriteLine(myComputer.HasWifi);
            // Console.WriteLine(myComputer.ReleaseDate);
            // Console.WriteLine(myComputer.VideoCard);
            // Console.WriteLine(myComputer.Price);

            // myComputer.ReleaseDate.ToString("yyyy-MM-dd");
        }
    }
}