using System;

namespace Roguelike
{
    public class Renderer
    {
        public int ViewWidth { get; }
        public int ViewHeight { get; }

        private readonly char[,] toDraw;

        public Renderer(int viewWidth, int viewHeight)
        {
            ViewWidth = viewWidth;
            ViewHeight = viewHeight;

            Console.SetWindowSize(ViewWidth + 1, ViewHeight + 1);
            Console.SetBufferSize(ViewWidth + 1, ViewHeight + 1);
            toDraw = new char[ViewWidth, ViewHeight];
        }

        public void Render()
        {
            string output = "";
            for (int y = 0; y < ViewHeight; y++)
            {
                for (int x = 0; x < ViewWidth; x++)
                {
                    output += toDraw[x, y];
                }
                output += '\n';
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(output);
        }

        public void Clear(char c)
        {
            for (int y = 0; y < ViewHeight; y++)
            {
                for (int x = 0; x < ViewWidth; x++)
                {
                    toDraw[x, y] = c;
                }
            }
        }

        public void DrawChar(int x, int y, char c)
        {
            toDraw[x, y] = c;
        }
    }
}
