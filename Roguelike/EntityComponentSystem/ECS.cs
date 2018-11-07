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
                system.Run(FilterEntities(system.ComponentSets));
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

        private Dictionary<string, List<Entity>> FilterEntities(Dictionary<string, Type[]> componentSets)
        {
            Dictionary<string, List<Entity>> filtered = new Dictionary<string, List<Entity>>();
            foreach (string key in componentSets.Keys)
            {
                filtered.Add(key, new List<Entity>());
                foreach (Entity entity in entities)
                {
                    foreach (Type type in componentSets[key])
                    {
                        if (!entity.HasComponent(type))
                            goto nextEntity;
                    }
                    filtered[key].Add(entity);
                    nextEntity:;
                }
            }
            return filtered;
        }
    }
}
