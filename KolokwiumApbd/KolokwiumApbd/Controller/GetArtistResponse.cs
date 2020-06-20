using System.Collections.Generic;
using KolokwiumApbd.Models;

namespace KolokwiumApbd.Controller
{
    public class GetArtistResponse
    {
        public int Id { get; set; }

        public string Nickname { get; set; }

        public IList<Event> Events { get; set; }
    }
}