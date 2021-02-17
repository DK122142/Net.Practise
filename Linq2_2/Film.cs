using System.Collections.Generic;

namespace Linq2_2
{
    class Film : ArtObject
    {
        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }

}
