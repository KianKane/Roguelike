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

        public bool HasComponent<T>() where T : IComponent
        {
            return Components.ContainsKey(typeof(T));
        }

        public T GetComponent<T>() where T : IComponent
        {
            return (T)Components[typeof(T)];
        }

        public void SetComponent<T>(T value) where T : IComponent
        {
            Components[typeof(T)] = value;
        }
    }
}
