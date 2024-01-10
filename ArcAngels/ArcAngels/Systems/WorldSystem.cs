using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Systems
{
    public class WorldSystem : AbstractSystem
    {
        // Lists containing all entities currently existing
        private List<Entity> _globalEntities = new List<Entity>();
        public List<Entity> GlobalEntities { get { return _globalEntities; } }

        private List<Entity> _renderableEntities = new List<Entity>();
        public List<Entity> RenderableEntities { get { return _renderableEntities; } }

        public Entity SpawnEntity(Type entityType = null, params AbstractComponent[] components)
        {
            entityType ??= typeof(Entity);

            if (!entityType.IsAssignableFrom(typeof(Entity))) throw new ArgumentException("Given type is not an 'Entity' type, nor is it a Type derived from the 'Entity' type.");

            Entity entity = (Entity) Activator.CreateInstance(entityType, components);

            OrganizeNewEntity(entity);

            return entity;
        }

        public Entity DespawnEntity(Entity entity)
        {
            foreach(var list in GetRelevantEntityList(entity.Components.GetAllComponents()))
            {
                list.Remove(entity);
            }

            entity.RemoveEntity();

            return entity;
        }

        private void OrganizeNewEntity(Entity entity)
        {
            foreach (var list in GetRelevantEntityList(entity.Components.GetAllComponents()))
            {
                list.Add(entity);
            }
        }

        private IEnumerable<List<Entity>> GetRelevantEntityList(params AbstractComponent[] components)
        {
            HashSet<List<Entity>> entityLists = new HashSet<List<Entity>>
            {
                _globalEntities
            };

            foreach (var component in components)
            {
                if (component.GetType() == typeof(SpriteComponent)) entityLists.Add(_renderableEntities);
            }

            return entityLists;
        }
    }
}
