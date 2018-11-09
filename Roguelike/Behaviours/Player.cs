using Roguelike.EntityBehaviourAction;
using System;
using Action = Roguelike.EntityBehaviourAction.Action;

namespace Roguelike.Behaviours
{
    public class Player : Behaviour
    {
        public override void HandleAction(Action action)
        {
            if (action.ID == "player_turn")
            {
                // Clear console input
                while (Console.KeyAvailable) { Console.ReadKey(true); }

                // Get direction
                Point direction = Point.zero;
                do
                {
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            direction = Point.up;
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            direction = Point.down;
                            break;
                        case ConsoleKey.D:
                        case ConsoleKey.RightArrow:
                            direction = Point.right;
                            break;
                        case ConsoleKey.A:
                        case ConsoleKey.LeftArrow:
                            direction = Point.left;
                            break;
                    }

                } while (direction == Point.zero);

                Action moveAction = new Action("move");
                moveAction.Parameters.Add("entity", Parent);
                moveAction.Parameters.Add("direction", direction);
                EntityManager.Fire(moveAction);
            }
        }
    }
}
