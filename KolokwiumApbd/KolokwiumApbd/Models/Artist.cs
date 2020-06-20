using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumApbd.Models
{
    public class Artist
    {
        [Column("IdArtist")] 
        public int Id { get; set; }

        [MaxLength(30)]
        public string Nickname { get; set; }

        public ICollection<ArtistEvent> ArtistEvents { get; set; }
    }
}