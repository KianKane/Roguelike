namespace Roguelike
{
    public class Player : Entity
    {
        public override IAction TakeTurn()
        {
            return new MoveAction(this, Point.right);
        }
    }
}
