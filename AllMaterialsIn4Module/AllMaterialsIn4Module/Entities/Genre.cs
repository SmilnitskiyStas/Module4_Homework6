﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMaterialsIn4Module.Entities
{
    internal class Genre
    {
        public int GenreId { get; set; }

        public string Title { get; set; }

        public virtual List<Song> Songs { get; set; }
    }
}
