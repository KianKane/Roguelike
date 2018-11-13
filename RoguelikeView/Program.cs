using Roguelike;
using System;

namespace RoguelikeView
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameLoop game = new GameLoop();
            Camera camera = new Camera(new Point(0, 0), new Point(100, 60));
            while (true)
            {
                // Draw actors
                camera.ConfigureConsole();
                foreach (Actor actor in game.actors)
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

                game.nextAction = new Move(game.hero, direction);

                game.DoTurn();
            }
        }
    }
}