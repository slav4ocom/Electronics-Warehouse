using Console_Manager.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Console_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new ElectronicsWarehouseContext();

            db.Database.Migrate();

            Console.WriteLine("Database created...");
        }
    }
}
