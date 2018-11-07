using System;
using Roguelike.EntityComponentSystem;
using Roguelike.Components;
using System.Collections.Generic;

namespace Roguelike.Systems
{
    public class EntityRenderSystem : ECSSystem
    {
        public override Dictionary<string, Type[]> ComponentSets
        {
            get
            {
                return new Dictionary<string, Type[]>()
                {
                    {"entities", new Type[] {typeof(Position), typeof(Visible)} }
                };
            }
        }

        private Renderer renderer;

        public EntityRenderSystem(Renderer renderer)
        {
            this.renderer = renderer;
        }

        public override void Run(Dictionary<string, List<Entity>> entitySets)
        {
            foreach (Entity entity in entitySets["entities"])
            {
                Position position = entity.GetComponent<Position>();
                Visible visible = entity.GetComponent<Visible>();
                renderer.Draw(position.position, visible.symbol);
            }
        }
    }
}
