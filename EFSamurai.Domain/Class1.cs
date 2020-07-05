﻿using System;
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
        public Samurai SamuraiId { get; set; }

        public Samurai Samurai { get; set; }
    }
}

