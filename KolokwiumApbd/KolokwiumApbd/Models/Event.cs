using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumApbd.Models
{
    public class Event
    {
        [Column("IdEvent")] 
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndTime { get; set; }

        public ICollection<Organizer> Organizer { get; set; }
        
        public ICollection<ArtistEvent> ArtistEvents { get; set; }
    }
}