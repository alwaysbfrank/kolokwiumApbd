using System;

namespace KolokwiumApbd.Controller
{
    public class UpdatePerformanceTimeRequest
    {
        public int ArtistId { get; set; }
        public int EventId { get; set; }
        public DateTime PerformanceDate { get; set; }

        public bool CheckIfIdsMatch(int artistId, int eventId)
        {
            return ArtistId == artistId && EventId == eventId;
        }
    }
}