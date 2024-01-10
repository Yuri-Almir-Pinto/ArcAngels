using ArcAngels.ArcAngels.Components;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Entities
{
    public class ComponentSet
    {
        private HashSet<AbstractComponent> _components;

        public enum Response {
            ALREADY_EXISTS, DOES_NOT_EXIST, ADDED, REMOVED
        }

        public ComponentSet(List<AbstractComponent> components) {
            this._components = new HashSet<AbstractComponent>();
            foreach (var component in components)
            {
                _components.Add(component);
            }
        }

        public bool ComponentExists(AbstractComponent component)
        {
            if (_components.Contains(component)) return true;
            else return false;
        }

        public Response AddComponent(AbstractComponent component)
        {
            if (_components.Contains(component))
                return Response.ALREADY_EXISTS;
            else
            {
                _components.Add(component);
                return Response.ADDED;
            }
        }

        public Response RemoveComponent(AbstractComponent component)
        {
            if (!_components.Contains(component))
                return Response.DOES_NOT_EXIST;
            else
            {
                _components.Add(component);
                return Response.REMOVED;
            }
        }
    }
}
