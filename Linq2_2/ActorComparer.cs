using System;
using System.Collections.Generic;

namespace Linq2_2
{
    public class ActorComparer : IEqualityComparer<Actor>
    {
        public bool Equals(Actor x, Actor y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Name == y.Name && x.Birthdate.Equals(y.Birthdate);
        }

        public int GetHashCode(Actor obj)
        {
            return HashCode.Combine(obj.Name, obj.Birthdate);
        }
    }
}
