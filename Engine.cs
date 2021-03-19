using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Console_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace Console_Manager
{
    public static class Engine
    {
        static ElectronicsWarehouseContext db;
        public static void Run()
        {
            db = new ElectronicsWarehouseContext();
            db.Database.Migrate();
            
            while (true)
            {
                var line = Console.ReadLine();

                Console.WriteLine(line);

                if (line.ToLower().Trim() == "exit")
                {
                    break;
                }
                else
                {
                    Parse(line.ToLower().Trim());
                }
            }

            db.Dispose();
        }

        public static void Parse(string command)
        {
            switch (command)
            {
                case "cls":
                    Console.Clear();
                    break;
                                              
                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }

    }
}
