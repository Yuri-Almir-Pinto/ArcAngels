using ArcAngels.ArcAngels.Components;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Entities
{
    public class Entity
    {
        private int _id;
        public HashSet<AbstractComponent> _components;
        
        private static int _nextId = 0;

        public Entity(List<AbstractComponent> components)
        {
            this._id = _nextId++;
            this._components = new HashSet<AbstractComponent>();
            foreach (var component in components) {
                if (!_components.Contains(component))
                {
                    _components.Add(component);
                }         
            }
        }
    }
}
