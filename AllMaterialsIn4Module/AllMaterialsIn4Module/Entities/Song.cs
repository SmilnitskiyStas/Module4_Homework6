using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMaterialsIn4Module.Entities
{
    internal class Song
    {
        public int SongId { get; set; }

        public string Title { get; set; }

        public decimal Duration { get; set; }

        public DateTime ReleasedDate { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual List<ArtistSong> ArtistSongs { get; set; }
    }
}
