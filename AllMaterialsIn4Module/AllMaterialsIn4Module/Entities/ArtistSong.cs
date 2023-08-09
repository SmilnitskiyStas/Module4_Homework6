using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMaterialsIn4Module.Entities
{
    internal class ArtistSong
    {
        public int ArtistSongId { get; set; }

        public int ArtistId { get; set; }

        public int SongId { get; set; }

        public virtual Artist Artist { get; set; }

        public virtual Song Song { get; set; }
    }
}
