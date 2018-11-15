﻿using Roguelike.Actions;
using Roguelike.Actors;
using Roguelike.DataTypes;
using System.Collections.Generic;

namespace Roguelike
{
    public class Game
    {
        public Actor hero;
        public IAction nextAction;
        public Queue<Actor> actors;

        public Game()
        {
            nextAction = null;
            actors = new Queue<Actor>();
            hero = new Hero(Point.zero);
            actors.Enqueue(hero);
            actors.Enqueue(new Creature(new Point(10, 10)));
            actors.Enqueue(new Creature(new Point(-10, 10)));
            actors.Enqueue(new Creature(new Point(10, -10)));
            actors.Enqueue(new Creature(new Point(-10, -10)));
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
                    action = current.GetAction(this);
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
