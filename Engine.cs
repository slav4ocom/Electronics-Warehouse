using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

            CultureInfo.CurrentCulture = new CultureInfo("en-EN");
            Console.WriteLine("slav4o.com Electronics Warehouse Manager");

            while (true)
            {
                var line = Console.ReadLine();

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

                case "add":
                    Console.WriteLine("Add new part: name, part type, price ");
                    var arguments = Console.ReadLine()
                        .Split(",", StringSplitOptions.RemoveEmptyEntries)
                        .Select(a => a.Trim())
                        .ToArray();

                    db.Add(new Article()
                    {
                        Name = arguments[0],
                        PartType = arguments[1],
                        Price = decimal.Parse(arguments[2])
                    });
                    db.SaveChanges();
                    break;

                case "list":
                    db.Articles.ToList().ForEach(a => Console.WriteLine($"{a.Id}. {a.Name} {a.PartType} {a.Price} BGN"));
                    break;

                case "remove":
                    Console.WriteLine("Enter Id to remove:");
                    var id = int.Parse(Console.ReadLine());
                    db.Remove(db.Articles.FirstOrDefault(a => a.Id == id));
                    db.SaveChanges();
                    break;

                case "edit":
                    Console.WriteLine("Enter Id to edit:");
                    var idToEdit = int.Parse(Console.ReadLine());
                    var part = db.Articles.FirstOrDefault(p => p.Id == idToEdit);
                    if (part != null)
                    {
                        Console.WriteLine($"{part.Id}. {part.Name} {part.PartType} {part.Price} BGN");
                        Console.WriteLine("Enter new data: name, part type, price ");
                        var editArgs = Console.ReadLine()
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(a => a.Trim())
                            .ToArray();

                        part.Name = editArgs[0];
                        part.PartType = editArgs[1];
                        part.Price = decimal.Parse(editArgs[2]);
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Invalid part.");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }

    }
}
