using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcAngels.ArcAngels.Systems.World
{
    public class EntitySystem : AbstractSystem
    {
        // Lists containing all entities currently existing
        private Dictionary<Type, List<Entity>> _entities;
        private List<Type> _subclasses = GetSubclasses();
        private Type _abstractComponentType = typeof(AbstractComponent);

        public EntitySystem() 
        {
            _entities = new Dictionary<Type, List<Entity>>();

            _entities[_abstractComponentType] = new List<Entity>();

            foreach (var subclass in _subclasses)
            {
                _entities[subclass] = new List<Entity>();
            }
        }

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

        private IEnumerable<List<Entity>> GetRelevantEntityList(IEnumerable<Type> subclasses)
        {
            HashSet<List<Entity>> entityLists = new HashSet<List<Entity>>
            {
                _entities[_abstractComponentType]
            };

            foreach (var subclass in subclasses)
            {
                entityLists.Add(_entities[subclass]);
            }

            return entityLists;
        }

        public static List<Type> GetSubclasses()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => typeof(AbstractComponent).IsAssignableFrom(type) && type != typeof(AbstractComponent) && type.IsClass)
                .ToList();
        }
    }
}
