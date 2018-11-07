using System;
using System.Collections.Generic;

namespace Roguelike.EntityComponentSystem
{
    public abstract class System
    {
        public abstract Dictionary<string, Type[]> ComponentSets { get; }

        public abstract void Run(Dictionary<string, List<Entity>> entitySets);
    }
}
