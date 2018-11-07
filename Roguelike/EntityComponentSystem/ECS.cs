using System;
using System.Collections.Generic;

namespace Roguelike.EntityComponentSystem
{
    public class ECS
    {
        private List<ECSSystem> systems;
        private List<Entity> entities;

        public ECS()
        {
            systems = new List<ECSSystem>();
            entities = new List<Entity>();
        }

        public void Step()
        {
            foreach (ECSSystem system in systems)
            {
                system.Run(FilterEntities(system.ComponentSet));
            }
        }

        public void AddSystem(ECSSystem system)
        {
            systems.Add(system);
        }

        public void AddEntity(Entity entity)
        {
            entities.Add(entity);
        }

        private List<Entity> FilterEntities(Type[] componentSet)
        {
            List<Entity> filtered = new List<Entity>();
            foreach (Entity entity in entities)
            {
                foreach (Type type in componentSet)
                {
                    if (!entity.Components.ContainsKey(type))
                        goto nextEntity;
                }
                filtered.Add(entity);
                nextEntity:;
            }
            return filtered;
        }
    }
}
