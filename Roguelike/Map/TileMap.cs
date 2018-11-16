using Roguelike.DataTypes;

namespace Roguelike.Map
{
    public sealed class TileMap
    {
        private Point size;
        private TileType outOfBounds;
        private TileType[,] tiles;

        public TileMap(Game game, Point size)
        {
            this.size = size;
            outOfBounds = TileTypes.wall;
            tiles = new TileType[size.X, size.Y];
            for (int x = 0; x < size.X; x++)
            {
                for (int y = 0; y < size.Y; y++)
                {
                    tiles[x, y] = game.RNG.NextDouble() >= 0.9f ? TileTypes.wall : TileTypes.floor;
                }
            }
        }

        public char GetSymbol(Point point)
        {
            if (PointOutOfBounds(point))
                return outOfBounds.Symbol;
            else
                return tiles[point.X, point.Y].Symbol;
        }

        public bool GetWalkable(Point point)
        {
            if (PointOutOfBounds(point))
                return outOfBounds.Walkable;
            else
                return tiles[point.X, point.Y].Walkable;
        }

        private bool PointOutOfBounds(Point point)
        {
            return point.X < 0 || point.X >= size.X || point.Y < 0 || point.Y >= size.Y;
        }
    }
}
