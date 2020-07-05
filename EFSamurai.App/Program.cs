using System;
using EFSamurai.Data;
using EFSamurai.Domain;

namespace EFSamurai.App
{
    class Program
    {
        private static void AddOneSamurai()
        {
            var samurai = new Samurai {Name = "Zelda"};
            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
