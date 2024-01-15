using ArcAngels.ArcAngels.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcAngels.ArcAngels.Entities
{
    public class Entity
    {
        private int _id;
        private static int _nextId = 0;
        private static List<int> _idsToFill = new List<int>();
        protected ComponentSet _components;

        public int Id { get { return _id; } }
        public AbstractComponent[] InitComponents
        {
            init
            {
                if (_components == null)
                {
                    _components = new ComponentSet(this, value);
                }
                else
                {
                    foreach (var component in value)
                    {
                        _components.AddComponent(component);
                    }
                }
            } 
        }

        public ComponentSet Components
        {
            get { return _components; }
        }

        public Entity()
        {
            this._id = _NewId();
            if (_components == null)
            {
                _components = new ComponentSet(this);
            }
        }

        public Entity(params AbstractComponent[] components)
        {
            this._id = _NewId();
            if (_components == null)
            {
                _components = new ComponentSet(this, components);
            }
            else
            {
                foreach (var component in components)
                {
                    _components.AddComponent(component);
                }
            }
        }

        private int _NewId() 
        {
            if (_idsToFill.Count == 0) return _nextId++;
            else
            {
                int id = _idsToFill[_idsToFill.Count - 1];
                _idsToFill.RemoveAt(_idsToFill.Count -1);
                return id;
            }
        }

        public Entity RemoveEntity()
        {
            _idsToFill.Add(_id);
            _id = -1;

            return this;
            
        }

        public bool IsEntity(int id)
        {
            if (_id == id) return true;

            return false;
        }
    }
}
