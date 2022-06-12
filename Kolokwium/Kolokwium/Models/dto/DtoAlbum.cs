using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium.Models.dto
{
    public class DtoAlbum
    {
        public int IdAlbum { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
        public String Label { get; set; }
        public ICollection<DtoTrack> Tracks { get; set; }
    }
}
