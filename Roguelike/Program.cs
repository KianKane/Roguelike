using System;
using System.Threading;

namespace Roguelike
{
    public class Program
    {
        private const int VIEW_WIDTH = 100;
        private const int VIEW_HEIGHT = 60;

        static void Main(string[] args)
        {
            Renderer renderer = new Renderer(VIEW_WIDTH, VIEW_HEIGHT);
            while (true)
            {
                renderer.Clear('.');
                renderer.Render();
                Thread.Sleep(500);
            }
        }
    }
}