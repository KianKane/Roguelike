using System;
using System.Collections.Generic;

namespace Roguelike.EntityComponentSystem
{
    public sealed class Entity
    {
        public Dictionary<Type, IComponent> Components { get; }

        public Entity(List<IComponent> startingComponents)
        {
            Components = new Dictionary<Type, IComponent>();
            foreach (IComponent c in startingComponents)
            {
                Components.Add(c.GetType(), c);
            }
        }
    }
}
