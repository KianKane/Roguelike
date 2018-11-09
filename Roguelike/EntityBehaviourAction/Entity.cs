using System.Collections.Generic;
using System.Linq;

namespace Roguelike.EntityBehaviourAction
{
    public class Entity
    {
        private List<Behaviour> behaviours;

        public Entity(params Behaviour[] startingBehaviours)
        {
            behaviours = new List<Behaviour>();
            foreach (Behaviour behaviour in startingBehaviours)
            {
                AddBehaviour(behaviour);
            }
        }

        public T GetBehaviour<T>() where T : Behaviour
        {
            return behaviours.OfType<T>().FirstOrDefault();
        }

        public void AddBehaviour(Behaviour behaviour)
        {
            behaviours.Add(behaviour);
            behaviour.SetParent(this);
        }

        public void HandleAction(Action action)
        {
            foreach (Behaviour behaviour in behaviours)
            {
                behaviour.HandleAction(action);
            }
        }
    }
}
