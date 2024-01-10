﻿using ArcAngels.ArcAngels.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcAngels.ArcAngels.Entities
{
    public class Entity
    {
        private int _id;
        public int Id { get { return _id; } }
        public ComponentSet Components { get; protected set; }
        private static int _nextId = 0;
        private static LinkedList<int> _idsToFill = new LinkedList<int>();

        public Entity(params AbstractComponent[] components)
        {
            this._id = _NewId();
            this.Components = new ComponentSet(this, components);
        }

        private int _NewId() 
        {
            if (_idsToFill.Count == 0) return _nextId++;
            else
            {
                int id = _idsToFill.Last.Value;
                _idsToFill.RemoveLast();
                return id;
            }
        }

        public Entity RemoveEntity()
        {
            _idsToFill.AddLast(_id);
            _idsToFill = new LinkedList<int>(_idsToFill.OrderByDescending(x => x));
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
