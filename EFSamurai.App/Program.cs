using System;
using System.Collections.Generic;
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

        public static void AddSomeSamurais()
        {
            IList<Samurai> SamuraiList = new List<Samurai>()
            {
                new Samurai() {Name = "Yukio"}, 
                new Samurai() {Name = "Renzo"},
                new Samurai() {Name = "Morio"},
            };

            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(new List<Samurai>());
                context.SaveChanges();
            }

        }



        static void Main(string[] args) 
        {
        //{Console.WriteLine("Hello World!");
        }
    }
}

    

