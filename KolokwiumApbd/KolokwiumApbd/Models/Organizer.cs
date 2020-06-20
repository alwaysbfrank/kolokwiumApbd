using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KolokwiumApbd.Models
{
    public class Organizer
    {
        [Column("IdOrganizer")]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}