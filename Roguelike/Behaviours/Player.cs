using Roguelike.EntityBehaviourAction;

namespace Roguelike.Behaviours
{
    public class Player : Behaviour
    {
        public override void HandleAction(Action action)
        {
            if (action.ID == "player_turn")
            {
                Action moveAction = new Action("move");
                moveAction.Parameters.Add("entity", Parent);
                moveAction.Parameters.Add("direction", Point.right);
                EntityManager.Fire(moveAction);
            }
        }
    }
}
