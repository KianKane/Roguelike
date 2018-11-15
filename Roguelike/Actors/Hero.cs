using Roguelike.Actions;
using Roguelike.DataTypes;

namespace Roguelike.Actors
{
    public sealed class Hero : Actor
    {
        internal Hero(Point position) : base(position, '@')
        {
        }

        internal override IAction GetAction(Game game)
        {
            IAction action = game.NextHeroAction;
            game.NextHeroAction = null;
            return action;
        }
    }
}
