using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace EFSamurai.Domain
{
    public class Samurai
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public Quote Quote { get; set; }

        public HairStyle ? HairStyle { get; set; }

        public SecretIdentity SecretIdentity { get; set; }

        public ICollection<SamuraiBattle> SamuraiBattles { get; set; }
    }

    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public QuoteStyle ? QuoteStyle   {get; set;}

      
    }

    public class SecretIdentity
    {
        public int Id { get; set; }
        public string RealName { get; set; }
        public int SamuraiId { get; set; }

        public Samurai Samurai { get; set; }
    }

    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBrutal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<SamuraiBattle> SamuraiBattles { get; set; }

        public BattleLog BattleLog { get; set; }
    }

    public class SamuraiBattle
    {
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }
        public int BattleId { get; set; }
        public Battle Battle { get; set; }
    }

    public class BattleLog
    {
        public int Id { get; set;}
        public string Name { get; set; }

        public int BattleId { get; set;}
        public Battle Battle { get; set; }

        public ICollection<BattleEvent> BattleEvents { get; set; }
    }

    public class BattleEvent
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }

        public int BattleLogId { get; set; }
        public BattleLog BattleLog { get; set; }
    }
}

