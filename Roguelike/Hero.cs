using System;

namespace Roguelike
{
    public class Hero : Actor
    {
        public Hero(Point position) : base(position, '@')
        {
        }

        public override IAction GetAction()
        {
            return null;
        }
    }
}
