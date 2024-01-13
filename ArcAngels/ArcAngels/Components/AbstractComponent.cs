using ArcAngels.ArcAngels.Entities;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Components
{
    public abstract class AbstractComponent
    {
        private readonly Type[] _dependencies = Array.Empty<Type>();
        public virtual Type[] Dependencies { get
            {
                return _dependencies;
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
