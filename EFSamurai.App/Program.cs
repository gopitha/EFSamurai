using System;
using System.Collections.Generic;
using EFSamurai.Data;
using EFSamurai.Domain;

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
                    StartDate = new DateTime(2020,08,01),
                    EndDate = new DateTime(2020,08,02), 
                    BattleLog = new BattleLog()
                    {
                        Name = "BattleLog for Battle 1",
                        BattleEvents = new List<BattleEvent>()
                        { new BattleEvent
                            {
                        Summary = "Summary BattleEvent 1",
                        Description= "Description BattleEvent 1",
                        Order= 1
                            },
                        new BattleEvent
                        {
                            Summary = "Summary BattleEvent 1.2",
                            Description = "Description BattleEvent 1.2",
                            Order=2
                        },
                        new BattleEvent
                        {
                            Summary  ="Summary BattleEvent 1.3",
                            Description = "Description BattleEvent 1.3",
                            Order =3
                        }
                        }
                    }

                },
                new Battle()
                {
                    Name = "Battle 2",
                    Description = "Game of the Battle 2",
                    IsBrutal = false,
                    StartDate = new DateTime(2020,08,02),
                    EndDate = new DateTime(2020,08,03),
                    BattleLog = new BattleLog()
                    {
                        Name = "BattleLog for Battle 2",
                        BattleEvents = new List<BattleEvent>()
                        { new BattleEvent
                            {
                                Summary = "Summary BattleEvent 2",
                                Description= "Description BattleEvent 2",
                                Order= 1
                            },
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 2.2",
                                Description = "Description BattleEvent 2.2",
                                Order=2
                            },
                            new BattleEvent
                            {
                                Summary  ="Summary BattleEvent 2.3",
                                Description = "Description BattleEvent 2.3",
                                Order =3
                            }
                        }

                    }
                    },
                new Battle()
                {
                    Name = "Battle 3",
                    Description = "Game of the Battle 3",
                    IsBrutal = true,
                    StartDate = new DateTime(2020,08,03),
                    EndDate = new DateTime(2020,08,04),
                    BattleLog = new BattleLog()
                    {
                        Name = "BattleLog for Battle 3",
                        BattleEvents = new List<BattleEvent>()
                        { new BattleEvent
                            {
                                Summary = "Summary BattleEvent 3",
                                Description= "Description BattleEvent 3",
                                Order= 1
                            },
                            new BattleEvent
                            {
                                Summary = "Summary BattleEvent 3.2",
                                Description = "Description BattleEvent 3.2",
                                Order=2
                            },
                            new BattleEvent
                            {
                                Summary  ="Summary BattleEvent 3.3",
                                Description = "Description BattleEvent 3.3",
                                Order =3
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
            var samuraiGopitha = new Samurai { Name = "Gopitha",
                Quote = QuoteStyle.Awesome,
                HairStyle =  HairStyle.Chonmage  ,
                SecretIdentity = {Id = 1, RealName = "GS" }

            };
            using var context = new SamuraiContext();
            context.Samurais.Add(samuraiGopitha);
            context.SaveChanges();

        }

        static void Main(string[] args) 
        {
        //{Console.WriteLine("Hello World!");
        }
    }
}

    

