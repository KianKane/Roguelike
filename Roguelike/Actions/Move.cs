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
            Point newPosition = actor.Position + direction;
            if (game.Map.GetWalkable(newPosition))
            {
                actor.Position = newPosition;
            }
            return true;
        }
    }
}
