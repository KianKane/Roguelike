﻿using Roguelike.Actions;
using Roguelike.DataTypes;

namespace Roguelike.Actors
{
    public class Hero : Actor
    {
        public Hero(Point position) : base(position, '@')
        {
        }

        public override IAction GetAction(Game game)
        {
            return null;
        }
    }
}
