using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Exceptions;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace ArcAngels.ArcAngels.Entities
{
    public class ComponentSet : IEnumerable
    {
        private HashSet<AbstractComponent> _components;
        private Entity _owner;

        public enum Response {
            ALREADY_EXISTS, DOES_NOT_EXIST, ADDED, REMOVED
        }

        public ComponentSet (Entity owner)
        {
            _owner = owner;
            this._components = new HashSet<AbstractComponent>();
        }

        public ComponentSet(Entity owner, params AbstractComponent[] components)
        {
            _owner = owner;
            this._components = new HashSet<AbstractComponent>();

            foreach (var component in components)
            {
                this.AddComponent(component);
            }

            
        }

        public bool ComponentIsPresent(Type componentType)
        {
            foreach (var component in _components)
            {
                if (component.GetType() == componentType) return true;
            }

            return false;
        }

        public Response AddComponent(AbstractComponent component)
        {
            if (this.ComponentIsPresent(component.GetType()))
                return Response.ALREADY_EXISTS;
            else
            {
                component.Owner = _owner;

                foreach (var dependency in component.Dependencies)
                {
                    if (!this.ComponentIsPresent(dependency))
                        throw new DependencyNotFound(component);
                }

                _components.Add(component);
                
                return Response.ADDED;
            }
        }

        public Response RemoveComponent(AbstractComponent component)
        {
            if (!this.ComponentIsPresent(component.GetType()))
                return Response.DOES_NOT_EXIST;
            else
            {
                _components.Remove(component);
                return Response.REMOVED;
            }
        }

        public IEnumerable<Type> GetAllComponents()
        {
            List<Type> types = new List<Type>();
            foreach (var component in _components)
            {
                types.Add(component.GetType());
            }

            return types;
        }

        public AbstractComponent GetComponent(Type type)
        {
            return _components.First(x => x.GetType() == type);
        }

        public IEnumerator GetEnumerator() => GetEnumerator();
    }
}
