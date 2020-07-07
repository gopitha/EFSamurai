using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFSamurai.Data
{
    public class EfMethods
    {
        public static int AddOneSamurai(string name)
        {
            var samurai = new Samurai()
            {
                Name = name
            };
            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
                return samurai.Id;
            }

        }

        public static string[] GetAllSamuraiNames()
        {
            string[] arrayOfSamuraiNames;
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais
                    .Select(s => s.Name)
                    .ToArray();
                arrayOfSamuraiNames = samurais;
            }

            return arrayOfSamuraiNames;
        }


        public static int AddOneSamurai(Samurai samurai)
        {
            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
                return samurai.Id;
            }

        }

        public static Samurai GetSamurai(int samuraiId)
        {
            using (var context = new SamuraiContext())
            {
                return  context.Samurais
                    .Include(s=>s.SecretIdentity)
                    .First(s => s.Id == samuraiId);
            }

        }

        public static void UpdateSamuraiSetSecretIdentity(int samuraiId, string name)
        {
            using (var context = new SamuraiContext())
            {
                var samurai = context.Samurais
                    .Include(s => s.SecretIdentity)
                    .Where(s => s.Id == samuraiId)
                    .ToList();
                foreach (var item in samurai)
                {
                    item.SecretIdentity = new SecretIdentity();
                    item.SecretIdentity.RealName = name;

                    context.Samurais.Update(item);
                    context.SaveChanges();
                }
            }




        }


    }
}
