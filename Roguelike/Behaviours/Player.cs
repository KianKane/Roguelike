using Roguelike.EntityBehaviourAction;

namespace Roguelike.Behaviours
{
    public class Player : Behaviour
    {
        public override void HandleAction(Action action)
        {
            if (action.ID == "turn" && action.Parameters["entity"] == Parent)
            {
                Action moveAction = new Action("before_move");
                moveAction.Parameters.Add("entity", Parent);
                moveAction.Parameters.Add("direction", Point.right);
                Parent.HandleAction(moveAction);
                moveAction.ID = "move";
                Parent.HandleAction(moveAction);
                moveAction.ID = "after_move";
                Parent.HandleAction(moveAction);
            }
        }
    }
}
