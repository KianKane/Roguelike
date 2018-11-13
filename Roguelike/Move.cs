namespace Roguelike
{
    public class Move : IAction
    {
        private Actor actor;
        private Point direction;

        public Move(Actor actor, Point direction)
        {
            this.actor = actor;
            this.direction = direction;
        }

        public bool Execute()
        {
            actor.position += direction;
            return true;
        }
    }
}
