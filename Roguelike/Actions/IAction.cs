using Roguelike.Actors;

namespace Roguelike.Actions
{
    public interface IAction
    {
        bool Execute(Game game, Actor actor);
    }
}
