using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using EFSamurai.Data;
using EFSamurai.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSamurai.App
{
    class Program
    {
        public static void AddOneSamurai()
        {
            var samurai = new Samurai {Name = "Zelda"};
            using var context = new SamuraiContext();
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        public static void AddSomeSamurais()
        {
            IList<Samurai> samuraiList = new List<Samurai>()
            {
                new Samurai() {Name = "Yukio"},
                new Samurai() {Name = "Renzo"},
                new Samurai() {Name = "Morio"},
            };

            using var context = new SamuraiContext();
            context.Samurais.AddRange(samuraiList);
            context.SaveChanges();
        }

        public static void AddSomeBattles()
        {
            IList<Battle> BattleList = new List<Battle>()
            {
                new Battle()
                {
                    Name = "Battle 1",
                    Description = "Game of the Battle 1",
                    IsBrutal = true,
                    StartDate = new DateTime(2020, 08, 01),
                    EndDate = new DateTime(2020, 08, 02),
                    BattleLog = new BattleLog()
                    {
                        Name = "BattleLog for Battle 1",
                        BattleEvents = new List<BattleEvent>()
                        {
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 1",
                                Description = "Description BattleEvent 1",
                                Order = 1
                            },
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 1.2",
                                Description = "Description BattleEvent 1.2",
                                Order = 2
                            },
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 1.3",
                                Description = "Description BattleEvent 1.3",
                                Order = 3
                            }
                        }
                    }

                },
                new Battle()
                {
                    Name = "Battle 2",
                    Description = "Game of the Battle 2",
                    IsBrutal = false,
                    StartDate = new DateTime(2020, 08, 02),
                    EndDate = new DateTime(2020, 08, 03),
                    BattleLog = new BattleLog()
                    {
                        Name = "BattleLog for Battle 2",
                        BattleEvents = new List<BattleEvent>()
                        {
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 2",
                                Description = "Description BattleEvent 2",
                                Order = 1
                            },
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 2.2",
                                Description = "Description BattleEvent 2.2",
                                Order = 2
                            },
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 2.3",
                                Description = "Description BattleEvent 2.3",
                                Order = 3
                            }
                        }

                    }
                },
                new Battle()
                {
                    Name = "Battle 3",
                    Description = "Game of the Battle 3",
                    IsBrutal = true,
                    StartDate = new DateTime(2020, 08, 03),
                    EndDate = new DateTime(2020, 08, 04),
                    BattleLog = new BattleLog()
                    {
                        Name = "BattleLog for Battle 3",
                        BattleEvents = new List<BattleEvent>()
                        {
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 3",
                                Description = "Description BattleEvent 3",
                                Order = 1
                            },
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 3.2",
                                Description = "Description BattleEvent 3.2",
                                Order = 2
                            },
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 3.3",
                                Description = "Description BattleEvent 3.3",
                                Order = 3
                            }
                        }
                    }

                }

            };
            using var context = new SamuraiContext();
            context.Battles.AddRange(BattleList);
            context.SaveChanges();
        }

        public static void AddOneSamuraiWithRelatedData()
        {
            var samuraiGopitha = new Samurai
            {
                Name = "Gopitha",

                HairStyle = HairStyle.Chonmage,

                Quotes = new List<Quote>()
                {
                    new Quote {Text = "Samurai Gopitha Quote", QuoteStyle = QuoteStyle.Lame},
                    new Quote {Text = "Samurai Gopitha Quote 2", QuoteStyle = QuoteStyle.Awesome}
                },

                SecretIdentity = new SecretIdentity() {RealName = "GS"},

                SamuraiBattles = new List<SamuraiBattle>()
                {
                    new SamuraiBattle
                    {
                        Battle = new Battle()
                        {
                            Name = "Battle 4",
                            Description = "Game of the Battle 4",
                            IsBrutal = true,
                            StartDate = new DateTime(2020, 08, 05),
                            EndDate = new DateTime(2020, 08, 06),
                            BattleLog = new BattleLog()
                            {
                                Name = "BattleLog for battle 4",
                                BattleEvents = new List<BattleEvent>()
                                {
                                    new BattleEvent
                                    {
                                        Summary = "Summary BattleEvent 4",
                                        Description = "Description BattleEvent 4",
                                        Order = 1
                                    },
                                    new BattleEvent
                                    {
                                        Summary = "Summary BattleEvent 4.2",
                                        Description = "Description BattleEvent 4.2",
                                        Order = 2
                                    }
                                }
                            }
                        }
                    }
                }
            };

            using var context = new SamuraiContext();
            context.Samurais.Add(samuraiGopitha);
            context.SaveChanges();

        }

        public static void ClearDatabase()
        {
            using (var context = new SamuraiContext())
            {
                context.RemoveRange(context.Samurais);
                context.RemoveRange(context.Battles);
                context.SaveChanges();
            }
        }


        public static void ListAllSamuraiNames()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = from s in context.Samurais
                    orderby s.Name
                    select s.Name;
                foreach (var samurai in samurais)
                {
                    Console.WriteLine(samurai);
                }

            }
        }

        public static void ListAllSamuraiNames_OrderByDecending()
        {
            using (var context = new SamuraiContext())
            {
                var samuraiNameDec = from s in context.Samurais
                    orderby s.Id descending
                    select s;

                foreach (var samurai in samuraiNameDec)
                {
                    Console.WriteLine(samurai.Id + "  " + samurai.Name );
                }
            }

        }

        public static void ListAllSamuraiNames_OrderByIdDescending()
        {
            using (var context = new SamuraiContext())
            {
                var samurais = context.Samurais
                    .OrderByDescending(s => s.Id)
                    .ToList();
                foreach (var item in samurais)
                {
                 Console.WriteLine( item.Id+ "   " +  item.Name );   
                }
            }
        }

        public static void FindSamuraiWithRealName(string name)
        {
            using (var context = new SamuraiContext())
            {
                var matchingNames = context.Samurais
                    .Include(s => s.SecretIdentity)
                    .Where(n => n.Name.Equals(name))
                    .ToList();

                if (!matchingNames.Any())
                {
                    Console.WriteLine("Sorry, try again!");
                }
                else
                {
                    foreach (var item in matchingNames)
                    {
                            Console.WriteLine($"{item.Name}  has a real name and it is {item.SecretIdentity.RealName}");
                    }
                }
            }
        }

        public static void ListAllQuotesOfType(QuoteStyle quoteStyle)
        {
            using (var context = new SamuraiContext())
            {
                var quotes = from s in context.Quotes
                    where s.QuoteStyle == quoteStyle
                    select s;
                foreach (var quote in quotes)
                {
                    Console.WriteLine(quote.Text);
                }
            }

        }





    static void Main(string[] args){
        
        {   // Metoder til del 2 av oppgaven:
            // ListAllSamuraiNames();
            // ListAllSamuraiNames_OrderByDecending();
            //  ListAllSamuraiNames_OrderByIdDescending();
            //FindSamuraiWithRealName("Gopitha");
            ListAllQuotesOfType(QuoteStyle.Awesome);




                // Metoder til del 1 av Oppgaven:

                // AddSomeSamurais();
                // AddSomeBattles();
                // AddOneSamuraiWithRelatedData();
                // ClearDatabase();


            }

        }

    }






}