using System;
using System.Data;
using System.Text.Json;
using AutoMapper;
using Basics.Data;
using Basics.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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

            // string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //     Motherboard,
            //     HasWifi,
            //     HasLTE,
            //     ReleaseDate,
            //     Price,
            //     VideoCard
            // ) VALUES ('" + myComputer.Motherboard 
            //         + "','" + myComputer.HasWifi
            //         + "','" + myComputer.HasLTE
            //         + "','" + myComputer.ReleaseDate.ToString("yyyy-MM-dd")
            //         + "','" + myComputer.Price
            //         + "','" + myComputer.VideoCard 
            // + "')";

            // File.WriteAllText("log.txt", "\n" + sql + "\n");

            // using StreamWriter openFile = new("log.txt", append: true);

            // openFile.WriteLine("\n" + sql + "\n");

            // openFile.Close();

            string computersJson = File.ReadAllText("ComputersSnake.json");

            Mapper mapper = new Mapper(new MapperConfiguration((cfg) => {
                cfg.CreateMap<ComputerSnake, Computer>()
                    .ForMember(destination => destination.ComputerId, options => 
                    options.MapFrom(source => source.computer_id))
                    
                    .ForMember(destination => destination.Motherboard, options => 
                    options.MapFrom(source => source.motherboard))
                    
                    .ForMember(destination => destination.CPUCores, options => 
                    options.MapFrom(source => source.cpu_cores))
                    
                    .ForMember(destination => destination.HasLTE, options => 
                    options.MapFrom(source => source.has_lte))
                    
                    .ForMember(destination => destination.HasWifi, options => 
                    options.MapFrom(source => source.has_wifi))
                    
                    .ForMember(destination => destination.Price, options => 
                    options.MapFrom(source => source.price))
                    
                    .ForMember(destination => destination.VideoCard, options => 
                    options.MapFrom(source => source.video_card))
                    
                    .ForMember(destination => destination.ReleaseDate, options => 
                    options.MapFrom(source => source.release_date));
            }));

            IEnumerable<ComputerSnake>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<ComputerSnake>>(computersJson);

            if(computersSystem != null)
            {
                IEnumerable<Computer> computerResult = mapper.Map<IEnumerable<Computer>>(computersSystem);

                Console.WriteLine("AutoMapper Count - " + computerResult.Count());

                // foreach(Computer computer in computerResult)
                // {
                //     Console.WriteLine(computer.Motherboard);
                // }
            }

            IEnumerable<Computer>? computersJsonPropertyMapping = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson);

            if(computersJsonPropertyMapping != null)
            {

                Console.WriteLine("Json Property Count - " + computersJsonPropertyMapping.Count());

                // foreach(Computer computer in computersSystemJsonPropertyMapping)
                // {
                //     Console.WriteLine(computer.Motherboard);
                // }
            }

            // Console.WriteLine(computersJson);

            // JsonSerializerOptions options = new JsonSerializerOptions()
            // {
            //     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            // };
            
            // IEnumerable<Computer>? computersSystem = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Computer>>(computersJson, options);

            // IEnumerable<Computer>? computersNewtonsoft = JsonConvert.DeserializeObject<IEnumerable<Computer>>(computersJson);

            // if(computersNewtonsoft != null)
            // {
            //     foreach(Computer computer in computersNewtonsoft)
            //     {
            //         // Console.WriteLine(computer.Motherboard);
            //          string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //                 Motherboard,
            //                 HasWifi,
            //                 HasLTE,
            //                 ReleaseDate,
            //                 Price,
            //                 VideoCard
            //             ) VALUES ('" + EscapeSingleQuote(computer.Motherboard)
            //                     + "','" + computer.HasWifi
            //                     + "','" + computer.HasLTE
            //                     + "','" + (computer.ReleaseDate.HasValue ? computer.ReleaseDate.Value.ToString("yyyy-MM-dd") : "")
            //                     + "','" + computer.Price
            //                     + "','" + EscapeSingleQuote(computer.VideoCard)
            //             + "')";

            //             dapper.ExecuteSql(sql);
            //     }
            // }

            // JsonSerializerSettings settings = new JsonSerializerSettings()
            // {
            //     ContractResolver = new CamelCasePropertyNamesContractResolver()
            // };

            // string computersCopyNewtonsoft = JsonConvert.SerializeObject(computersNewtonsoft, settings);

            // File.WriteAllText("computersCopyNewtonsoft.txt",computersCopyNewtonsoft);

            // string computersCopySystem = System.Text.Json.JsonSerializer.Serialize(computersSystem, options);

            // File.WriteAllText("computersCopySystem.txt",computersCopySystem);
            
        }

        static string EscapeSingleQuote(string input)
        {
            string output = input.Replace("'", "''");

            return output;
        }

    }
}