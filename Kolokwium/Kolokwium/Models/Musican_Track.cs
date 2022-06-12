using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models
{
    public class Musican_Track
    {
        [Required]
        public int IdTrack { get; set; }
        [Required]
        public int IdMusican { get; set; }
        [ForeignKey("IdTrack")]
        public virtual Track Track { get; set; }
        [ForeignKey("IdMusican")]
        public virtual Musician Musician { get; set; }
    }
}
