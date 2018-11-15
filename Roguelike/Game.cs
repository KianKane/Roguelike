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
        public Queue<Actor> ActorTurnQueue { get; private set; }

        public Game()
        {
            NextHeroAction = null;
            ActorTurnQueue = new Queue<Actor>();
            Hero = new Hero(Point.zero);
            ActorTurnQueue.Enqueue(Hero);
            ActorTurnQueue.Enqueue(new Creature(new Point(10, 10)));
            ActorTurnQueue.Enqueue(new Creature(new Point(-10, 10)));
            ActorTurnQueue.Enqueue(new Creature(new Point(10, -10)));
            ActorTurnQueue.Enqueue(new Creature(new Point(-10, -10)));
        }

        public void DoTurn()
        {
            if(ActorTurnQueue.Count > 0)
            {
                Actor current = ActorTurnQueue.Peek();
                IAction action = current.GetAction(this);
                if (action != null && action.Execute(this, current))
                {
                    ActorTurnQueue.Dequeue();
                    ActorTurnQueue.Enqueue(current);
                }
            }
        }
    }
}
