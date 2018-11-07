namespace Roguelike
{
    public class Tile
    {
        public bool Walkable { get; }
        public char Symbol { get; }

        public Tile(bool walkable, char symbol)
        {
            Walkable = walkable;
            Symbol = symbol;
        }
    }
}
