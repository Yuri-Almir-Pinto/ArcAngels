using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Exceptions;
using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Entities
{
    public class ComponentSet
    {
        private HashSet<AbstractComponent> _components;
        private Entity _owner;

        public enum Response {
            ALREADY_EXISTS, DOES_NOT_EXIST, ADDED, REMOVED
        }

        public ComponentSet(List<AbstractComponent> components, Entity owner)
        {
            this._components = new HashSet<AbstractComponent>();
            foreach (var component in components)
            {
                this.AddComponent(component);
            }

            _owner = owner;
        }

        public bool ComponentIsPresent(AbstractComponent component)
        {
            return this._components.Contains(component);
        }

        public Response AddComponent(AbstractComponent component)
        {
            if (this.ComponentIsPresent(component))
                return Response.ALREADY_EXISTS;
            else
            {
                foreach(var dependency in component.GetDependencies())
                {
                    if (!this.ComponentIsPresent(dependency))
                        throw new DependencyNotFound(component);
                }
                _components.Add(component);

                component.Owner = _owner;
                return Response.ADDED;
            }
        }

        public Response RemoveComponent(AbstractComponent component)
        {
            if (!this.ComponentIsPresent(component))
                return Response.DOES_NOT_EXIST;
            else
            {
                _components.Remove(component);
                return Response.REMOVED;
            }
        }
    }
}
