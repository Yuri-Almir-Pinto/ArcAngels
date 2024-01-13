using ArcAngels.ArcAngels.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace ArcAngels.ArcAngels.Systems
{
    public abstract class AbstractSystem
    {
        private readonly Type[] _dependencies = Array.Empty<Type>();
        public virtual Type[] Dependencies {  get { return _dependencies; } }

        public bool HasDependencies(Entity entity)
        {
            foreach (var type in Dependencies)
            {
                if (!entity.Components.ComponentIsPresent(type)) return false;
            }

            return true;
        }
    }
}
