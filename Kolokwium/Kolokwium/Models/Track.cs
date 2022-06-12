using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Track
    {
        [Key]
        public int IdTrack { get; set; }
        [Required]
        [MaxLength(20)]
        public string TackName { get; set; }
        [Required]
        public float Duration { get; set; }
        public int? IdAlbum { get; set; }
        [ForeignKey("IdAlbum")]
        public virtual Album? Album { get; set; }
    }
}
