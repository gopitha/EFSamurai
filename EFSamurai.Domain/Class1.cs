using System;
using System.Net.Mime;

namespace EFSamurai.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Quote Quote { get; set; }

        public HairStyle ? HairStyle { get; set; }

        public SecretIdentity SecretIdentity { get; set; }
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

    public class Battele
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsBrutal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

