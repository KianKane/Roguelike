using Roguelike.EntityComponentSystem;

namespace Roguelike.Components
{
    public class TileMapComponent : IComponent
    {
        public Tile[,] map;
        public Point size;
        public Tile outOfBounds;

        public TileMapComponent(Tile[,] map, Point size, Tile outOfBounds)
        {
            this.map = map;
            this.size = size;
            this.outOfBounds = outOfBounds;
        }
    }
}
