using ArcAngels.ArcAngels.Entities;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Components
{
    public abstract class AbstractComponent
    {
        public abstract string Name { get; }
        public Entity Owner;

        public virtual List<AbstractComponent> GetDependencies()
        {
            return new List<AbstractComponent>();
        }

        public override bool Equals(object obj)
        {
            if (obj is AbstractComponent other)
            {
                return this.Name == other.Name;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
