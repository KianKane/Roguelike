using System;
using Roguelike.EntityComponentSystem;
using Roguelike.Components;
using System.Collections.Generic;

namespace Roguelike.Systems
{
    public class CameraFollowSystem : EntityComponentSystem.System
    {
        public override Dictionary<string, Type[]> ComponentSets
        {
            get
            {
                return new Dictionary<string, Type[]>()
                {
                    {"players", new Type[] {typeof(PositionComponent), typeof(PlayerComponent)} },
                    {"cameras", new Type[] {typeof(PositionComponent), typeof(CameraComponent)} }
                };
            }
        }

        public override void Run(Dictionary<string, List<Entity>> entitySets)
        {
            Point playerPosition = entitySets["players"][0].GetComponent<PositionComponent>().point;
            entitySets["cameras"][0].SetComponent(new PositionComponent(playerPosition));
        }
    }
}
