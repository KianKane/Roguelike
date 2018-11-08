using System;
using System.Collections.Generic;

namespace Roguelike
{
    public class Map
    {
        private Dictionary<ushort, Tile> tiles;
        private ushort outOfBounds;

        private Point size;
        private ushort[,] grid;

        public Map(Point size)
        {
            tiles = new Dictionary<ushort, Tile>
            {
                {0, new Tile(true, ' ')},
                {1, new Tile(false, '#')}
            };
            outOfBounds = 1;
            this.size = size;
            grid = new ushort[size.X, size.Y];
            GenerateMap();
        }

        public Tile GetTile(Point point)
        {
            if (point.X >= 0 && point.X < size.X && point.Y >= 0 && point.Y < size.Y)
                return tiles[grid[point.X, point.Y]];
            else
                return tiles[outOfBounds];
        }

        public void DrawMap(Camera camera)
        {
            // Set up buffer
            char[,] buffer = new char[camera.Size.X, camera.Size.Y];
            for (int x = 0; x < camera.Size.X; x++)
            {
                for (int y = 0; y < camera.Size.Y; y++)
                {
                    Point point = camera.ToWorldSpace(new Point(x, y));
                    if (point.X >= 0 && point.X < size.X && point.Y >= 0 && point.Y < size.Y)
                        buffer[x, y] = tiles[grid[point.X, point.Y]].Symbol;
                    else
                        buffer[x, y] = tiles[outOfBounds].Symbol;
                }
            }

            // Output buffer
            string output = "";
            for (int y = camera.Size.Y - 1; y >= 0; y--)
            {
                for (int x = 0; x < camera.Size.X; x++)
                {
                    output += buffer[x, y];
                }
                output += '\n';
            }
            Console.SetCursorPosition(0, 0);
            Console.Write(output);
        }

        private void GenerateMap()
        {
            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    grid[x, y] = x % 4 == 0 && y % 4 == 0 ? (ushort)1 : (ushort)0;
                }
            }
        }
    }
}
