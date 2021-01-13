using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq2_2
{
    class Film : ArtObject
    {
        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }

}
