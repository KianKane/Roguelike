using System.Collections.Generic;

namespace Roguelike.EntityBehaviourAction
{
    public static class EntityManager
    {
        private static List<Entity> entities = new List<Entity>();

        public static void Add(Entity entity)
        {
            entities.Add(entity);
        }

        public static void Fire(Action action)
        {
            string id = action.ID;
            action.ID = "before_" + id;
            entities.ForEach((e) => e.HandleAction(action));
            action.ID = id;
            entities.ForEach((e) => e.HandleAction(action));
            action.ID = "after_" + id;
            entities.ForEach((e) => e.HandleAction(action));
        }
    }
}
