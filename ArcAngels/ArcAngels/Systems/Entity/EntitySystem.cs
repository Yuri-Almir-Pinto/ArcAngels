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

        public List<Entity> GetEntityByComponent(params Type[] componentType)
        {
            if (componentType.Length == 0) return _entities[_abstractComponentType];
            if (componentType.Length == 1) return _entities[componentType[0]];
            else return new List<Entity>();
            // Only implement search based on multiple components when absolutely necessary.
            // Because it will probably eat a LOT of resources. Too complex for now.

            // Note for future selves: If systems with more than one dependency start do become common, implement a system that
            // checks for all child classes of "AbstractSystem" with more than one dependencies, puts every unique combination in a list
            // and uses this list as a key in a dictionary which accepts Type[] types, also integrating with the Spawn and Despawn methods
            // to check for these specific combinations, and organize them upon spawning and despawning entities.
        }
    }
}
