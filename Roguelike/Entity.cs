namespace Roguelike
{
    public abstract class Entity
    {
        public Point Position { get; set; }

        public abstract IAction TakeTurn();
    }
}
