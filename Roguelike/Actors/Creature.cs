using Roguelike.Actions;
using Roguelike.DataTypes;

namespace Roguelike.Actors
{
    public class Creature : Actor
    {
        public Creature(Point position) : base(position, '!')
        {
        }

        public override IAction GetAction(Game game)
        {
            switch (game.RNG.Next(0, 4))
            {
                case 0:
                    return new Move(Point.up);
                case 1:
                    return new Move(Point.down);
                case 2:
                    return new Move(Point.left);
                default:
                    return new Move(Point.right);
            }
        }
    }
}
