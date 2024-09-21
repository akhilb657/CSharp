using System;
using System.Data;
using Basics.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

            IDbConnection dbConnection = new SqlConnection(connectionString);

            string sqlCommad = "SELECT GETDATE()";

            DateTime rightNow = dbConnection.QuerySingle<DateTime>(sqlCommad);

            // Console.WriteLine(rightNow);

            Computer myComputer = new Computer() {
                Motherboard = "Z690",
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = DateTime.Now,
                Price = 999.99m,
                VideoCard = "RTX 2060"
            };

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

            int result = dbConnection.Execute(sql);

            // Console.WriteLine(result);

            string sqlSelect = @"SELECT 
                Computer.Motherboard,
                Computer.HasWifi,
                Computer.HasLTE,
                Computer.ReleaseDate,
                Computer.Price,
                Computer.VideoCard
             FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dbConnection.Query<Computer>(sqlSelect);

            Console.WriteLine("'Motherboard', 'HasWifi', 'HasLTE', 'ReleaseDate', 'Price', 'VideoCard'");

            foreach(Computer singleComputer in computers)
            {
                Console.WriteLine("'" + myComputer.Motherboard 
                    + "','" + myComputer.HasWifi
                    + "','" + myComputer.HasLTE
                    + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
                    + "','" + myComputer.Price
                    + "','" + myComputer.VideoCard 
                    +"'");
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