using Roguelike;
using Roguelike.Actions;
using Roguelike.Actors;
using Roguelike.DataTypes;
using System;

namespace RoguelikeView
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game();
            Camera camera = new Camera(new Point(0, 0), new Point(100, 60));
            while (true)
            {
                if (game.ActorTurnQueue.TryPeek(out Actor nextActor) && nextActor == game.Hero)
                {
                    // Draw actors
                    camera.ConfigureConsole();
                    foreach (Actor actor in game.ActorTurnQueue)
                    {
                        Point pointOnScreen = camera.ToScreenSpace(actor.position);
                        if (camera.ScreenPointWithinBounds(pointOnScreen))
                        {
                            Console.SetCursorPosition(pointOnScreen.X, pointOnScreen.Y);
                            Console.Write(actor.symbol);
                        }
                    }

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

                    game.NextHeroAction = new Move(game.Hero, direction);
                }
                game.DoTurn();
            }
        }
    }
}