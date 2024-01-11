using ArcAngels.ArcAngels.Entities;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Components
{
    public abstract class AbstractComponent
    {
        public virtual Type[] Dependencies { get
            {
                return Array.Empty<Type>();
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
