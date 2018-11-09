namespace Roguelike.EntityBehaviourAction
{
    public abstract class Behaviour
    {
        public Entity Parent { get; private set; }

        public void SetParent(Entity parent)
        {
            Parent = parent;
        }

        public virtual void HandleAction(Action action)
        {
        }
    }
}
