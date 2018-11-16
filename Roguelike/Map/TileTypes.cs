namespace Roguelike.Map
{
    public sealed class TileTypes
    {
        public static readonly TileType floor = new TileType(true, ' ');
        public static readonly TileType wall = new TileType(false, '#');
    }
}
