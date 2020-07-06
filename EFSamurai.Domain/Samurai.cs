﻿using System;
using System.Collections.Generic;
using System.Net.Mime;

namespace EFSamurai.Domain
{
    public class Samurai
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public QuoteStyle Quote { get; set; }
         public ICollection<Quote> Quotes { get; set; }
        public HairStyle ? HairStyle { get; set; }

        public SecretIdentity SecretIdentity { get; set; }

        public ICollection<SamuraiBattle> SamuraiBattles { get; set; }
    }

 

 

  
   

   
   

  
}

