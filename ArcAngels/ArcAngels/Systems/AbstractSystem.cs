using ArcAngels.ArcAngels.Entities;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Systems
{
    public abstract class AbstractSystem
    {
        protected virtual List<Type> Dependencies { get; }
        public bool HasAllComponents(Entity entity)
        {
            foreach (var type in Dependencies)
            {
                if (!entity.Components.ComponentIsPresent(type)) return false;
            }

            return true;
        }
    }
}
