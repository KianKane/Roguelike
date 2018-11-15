using Roguelike.Actions;
using Roguelike.Actors;
using Roguelike.DataTypes;
using System.Collections.Generic;

namespace Roguelike
{
    public class Game
    {
        public IAction NextHeroAction { get; set; }
        public Actor Hero { get; private set; }
        public Queue<Actor> Actors { get; private set; }

        public Game()
        {
            NextHeroAction = null;
            Actors = new Queue<Actor>();
            Hero = new Hero(Point.zero);
            Actors.Enqueue(Hero);
            Actors.Enqueue(new Creature(new Point(10, 10)));
            Actors.Enqueue(new Creature(new Point(-10, 10)));
            Actors.Enqueue(new Creature(new Point(10, -10)));
            Actors.Enqueue(new Creature(new Point(-10, -10)));
        }

        public void DoTurn()
        {
            if(Actors.Count > 0)
            {
                Actor current = Actors.Peek();
                IAction action = current.GetAction(this);
                if (action != null && action.Execute())
                {
                    Actors.Dequeue();
                    Actors.Enqueue(current);
                }
            }
        }
    }
}
