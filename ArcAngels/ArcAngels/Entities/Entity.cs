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
        private ComponentSet _components;

        public int Id { get { return _id; } }
        public AbstractComponent[] InitComponents
        {
            init => _components = new ComponentSet(this, value);
        }

        public ComponentSet Components
        {
            get { return _components; }
        }

        public Entity()
        {
            this._id = _NewId();
            this._components = new ComponentSet(this);
        }

        public Entity(AbstractComponent[] components)
        {
            this._id = _NewId();
            this._components = new ComponentSet(this, components);
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
