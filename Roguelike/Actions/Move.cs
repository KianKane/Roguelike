using Roguelike.Actors;
using Roguelike.DataTypes;

namespace Roguelike.Actions
{
    public class Move : IAction
    {
        private Point direction;

        public Move(Point direction)
        {
            this.direction = direction;
        }

        public bool Execute(Game game, Actor actor)
        {
            actor.position += direction;
            return true;
        }
    }
}
