using System.Collections.Generic;
using System.Linq;

namespace Roguelike.EntityBehaviourAction
{
    public class Entity
    {
        private List<IBehaviour> behaviours;

        public Entity(params IBehaviour[] startingBehaviours)
        {
            behaviours = new List<IBehaviour>();
            foreach (IBehaviour behaviour in startingBehaviours)
            {
                AddBehaviour(behaviour);
            }
        }

        public T GetBehaviour<T>() where T : IBehaviour
        {
            return behaviours.OfType<T>().FirstOrDefault();
        }

        public void AddBehaviour(IBehaviour behaviour)
        {
            behaviours.Add(behaviour);
        }

        public void HandleAction(IAction action)
        {
            foreach (IBehaviour behaviour in behaviours)
            {
                behaviour.HandleAction(action);
            }
        }
    }
}
