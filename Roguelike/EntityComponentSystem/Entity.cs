using System;
using System.Collections.Generic;

namespace Roguelike.EntityComponentSystem
{
    public sealed class Entity
    {
        private Dictionary<Type, IComponent> components;

        public Entity(List<IComponent> startingComponents)
        {
            components = new Dictionary<Type, IComponent>();
            foreach (IComponent component in startingComponents)
            {
                components.Add(component.GetType(), component);
            }
        }

        public bool HasComponent<T>() where T : IComponent
        {
            return components.ContainsKey(typeof(T));
        }

        public bool HasComponent(Type type)
        {
            return components.ContainsKey(type);
        }

        public T GetComponent<T>() where T : IComponent
        {
            return (T)components[typeof(T)];
        }

        public void SetComponent<T>(T component) where T : IComponent
        {
            components[typeof(T)] = component;
        }

        public void AddComponent<T>(T component) where T : IComponent
        {
            components.Add(component.GetType(), component);
        }
    }
}
