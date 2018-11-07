using System;
using Roguelike.EntityComponentSystem;
using Roguelike.Components;
using System.Collections.Generic;

namespace Roguelike.Systems
{
    public class EntityRenderSystem : EntityComponentSystem.System
    {
        public override Dictionary<string, Type[]> ComponentSets
        {
            get
            {
                return new Dictionary<string, Type[]>()
                {
                    {"entities", new Type[] {typeof(PositionComponent), typeof(VisibleComponent)} }
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
                PositionComponent position = entity.GetComponent<PositionComponent>();
                VisibleComponent visible = entity.GetComponent<VisibleComponent>();
                renderer.Draw(position.point, visible.symbol);
            }
        }
    }
}
