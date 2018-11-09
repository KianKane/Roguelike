using System;
using Roguelike.EntityBehaviourAction;
using Action = Roguelike.EntityBehaviourAction.Action;

namespace Roguelike.Behaviours
{
    public class Drunk : Behaviour
    {
        Random random;

        public Drunk()
        {
            random = new Random();
        }

        public override void HandleAction(Action action)
        {
            if (action.ID == "before_move" && action.Parameters["entity"] == Parent)
            {
                if (random.NextDouble() <= 0.25f)
                {
                    switch (random.Next(0, 4))
                    {
                        case 0:
                            action.Parameters["direction"] = Point.up;
                            break;
                        case 1:
                            action.Parameters["direction"] = Point.down;
                            break;
                        case 2:
                            action.Parameters["direction"] = Point.left;
                            break;
                        case 3:
                            action.Parameters["direction"] = Point.right;
                            break;
                    }
                }
            }
        }
    }
}
