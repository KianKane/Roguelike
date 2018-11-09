using Roguelike.Behaviours;
using Roguelike.EntityBehaviourAction;

namespace Roguelike
{
    public class MoveAction : IAction
    {
        public Entity Entity { get; set; }
        public Point Direction { get; set; }

        public MoveAction(Entity entity, Point direction)
        {
            Entity = entity;
            Direction = direction;
        }

        public void Execute()
        {
            Physical physical = Entity.GetBehaviour<Physical>();

            if (physical == null)
                return;

            physical.Position += Direction;
        }
    }
}
