using System;
using System.Collections.Generic;

namespace Roguelike.EntityComponentSystem
{
    public abstract class ECSSystem
    {
        public abstract Type[] ComponentSet { get; }

        public abstract void Run(List<Entity> entities);
    }
}
