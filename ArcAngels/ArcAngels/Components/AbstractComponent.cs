using ArcAngels.ArcAngels.Entities;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Components
{
    public abstract class AbstractComponent
    {
        public virtual List<AbstractComponent> Dependencies { get
            {
                return new List<AbstractComponent>();
            } 
        }
        public Entity Owner;

        public override bool Equals(object obj)
        {
            if (obj is AbstractComponent other)
            {
                return this.GetType() == other.GetType();
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }
    }
}
