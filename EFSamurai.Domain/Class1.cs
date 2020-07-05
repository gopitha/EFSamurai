using System;
using System.Net.Mime;

namespace EFSamurai.Domain
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
