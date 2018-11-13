using System.Collections;
using System.Collections.Generic;

namespace Roguelike
{
    public class GameLoop
    {
        public Actor hero;
        public IAction nextAction;
        public Queue<Actor> actors;

        public GameLoop()
        {
            nextAction = null;
            actors = new Queue<Actor>();
            hero = new Hero(Point.zero);
            actors.Enqueue(hero);
        }

        public void DoTurn()
        {
            if(actors.Count > 0)
            {
                Actor current = actors.Peek();

                IAction action;
                if (current == hero)
                {
                    action = nextAction;
                    nextAction = null;
                }
                else
                {
                    action = current.GetAction();
                }

                if (action != null && action.Execute())
                {
                    actors.Dequeue();
                    actors.Enqueue(current);
                }
            }
        }
    }
}
