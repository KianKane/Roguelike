﻿using Roguelike.Actions;
using Roguelike.DataTypes;

namespace Roguelike.Actors
{
    public abstract class Actor
    {
        public Point position;
        public char symbol;

        public Actor(Point position, char symbol)
        {
            this.position = position;
            this.symbol = symbol;
        }

        public abstract IAction GetAction(Game game);
    }
}
