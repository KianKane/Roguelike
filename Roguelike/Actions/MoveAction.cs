namespace Roguelike
{
    public class MoveAction : IAction
    {
        private Entity entity;
        private Point direction;

        public MoveAction(Entity entity, Point direction)
        {
            this.entity = entity;
            this.direction = direction;
        }

        public void Execute()
        {
            entity.Position = new Point(entity.Position.X + direction.X, entity.Position.Y + direction.Y);
        }
    }
}
