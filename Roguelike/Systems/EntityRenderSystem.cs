using System;
using Roguelike.EntityComponentSystem;
using Roguelike.Components;
using System.Collections.Generic;

namespace Roguelike.Systems
{
    public class EntityRenderSystem : ECSSystem
    {
        public override Type[] ComponentSet
        {
            get
            {
                return new Type[] { typeof(Position), typeof(Visible) };
            }
        }

        private Renderer renderer;

        public EntityRenderSystem(Renderer renderer)
        {
            this.renderer = renderer;
        }

        public override void Run(List<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                Position position = entity.GetComponent<Position>();
                Visible visible = entity.GetComponent<Visible>();
                renderer.Draw(position.position, visible.symbol);
            }
        }
    }
}
