using Roguelike.EntityBehaviourAction;
using System;

namespace Roguelike.Behaviours
{
    public class Drunk : IBehaviour
    {
        Random random;

        public Drunk()
        {
            random = new Random();
        }

        public void HandleAction(IAction action)
        {
            if (action is MoveAction)
            {
                MoveAction moveAction = action as MoveAction;
                if (random.NextDouble() <= 0.25f)
                {
                    switch (random.Next(0, 4))
                    {
                        case 0:
                            moveAction.Direction = Point.up;
                            break;
                        case 1:
                            moveAction.Direction = Point.down;
                            break;
                        case 2:
                            moveAction.Direction = Point.left;
                            break;
                        case 3:
                            moveAction.Direction = Point.right;
                            break;
                    }
                }
            }
        }
    }
}
