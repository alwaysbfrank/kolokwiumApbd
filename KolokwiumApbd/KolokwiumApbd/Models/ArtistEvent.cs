using System;

namespace KolokwiumApbd.Models
{
    public class ArtistEvent
    {
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public DateTime PerformanceDate { get; set; }
    }
}