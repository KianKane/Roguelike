namespace Roguelike.Map
{
    public sealed class TileType
    {
        public bool Walkable { get; }
        public char Symbol { get; }

        internal TileType(bool walkable, char symbol)
        {
            Walkable = walkable;
            Symbol = symbol;
        }
    }
}
