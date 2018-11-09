using Roguelike.EntityBehaviourAction;

namespace Roguelike.Behaviours
{
    public class Physical : Behaviour
    {
        public Map Map { get; set; }
        public Point Position { get; set; }
        public char Symbol { get; set; }

        public Physical(Map map, Point position, char symbol)
        {
            Map = map;
            Position = position;
            Symbol = symbol;
        }

        public override void HandleAction(Action action)
        {
            if (action.ID == "move" && action.Parameters["entity"] == Parent)
            {
                Position += (Point)action.Parameters["direction"];
            }
        }
    }
}
