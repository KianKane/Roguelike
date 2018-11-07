using Roguelike.Components;
using System.Collections.Generic;

namespace Roguelike
{
    public class TileMapGenerator
    {
        private readonly Dictionary<string, Tile> tiles;

        public TileMapGenerator()
        {
            tiles = new Dictionary<string, Tile>(){
                {"floor", new Tile(true, '.')},
                {"wall", new Tile(true, '#')}
            };
        }

        public TileMapComponent Generate(Point size)
        {
            Tile[,] map = new Tile[size.X, size.Y];

            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    map[x, y] = x % 4 == 0 && y % 4 == 0 ? tiles["wall"] : tiles["floor"];
                }
            }

            return new TileMapComponent(map, size, tiles["wall"]);
        }
    }
}
