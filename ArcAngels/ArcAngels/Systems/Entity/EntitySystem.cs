using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Systems.World
{
    public class EntitySystem : AbstractSystem
    {
        // Lists containing all entities currently existing
        private List<Entity> _globalEntities = new List<Entity>();
        public List<Entity> GlobalEntities { get { return _globalEntities; } }

        private List<Entity> _renderableEntities = new List<Entity>();
        public List<Entity> RenderableEntities { get { return _renderableEntities; } }

        public Entity SpawnEntity<TEntity>(params AbstractComponent[] components) where TEntity : Entity, new()
        {
            Entity entity = new TEntity
            {
                InitComponents = components
            };

            foreach (var list in GetRelevantEntityList(entity.Components.GetAllComponents()))
            {
                list.Add(entity);
            }

            return entity;
        }

        public Entity DespawnEntity(Entity entity)
        {
            foreach (var list in GetRelevantEntityList(entity.Components.GetAllComponents()))
            {
                list.Remove(entity);
            }

            entity.RemoveEntity();

            return entity;
        }

        private IEnumerable<List<Entity>> GetRelevantEntityList(IEnumerable<Type> types)
        {
            HashSet<List<Entity>> entityLists = new HashSet<List<Entity>>
            {
                _globalEntities
            };

            foreach (var type in types)
            {
                if (type == typeof(DrawableComponent)) entityLists.Add(_renderableEntities);
            }

            return entityLists;
        }
    }
}
