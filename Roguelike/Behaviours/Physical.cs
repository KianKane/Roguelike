using Roguelike.EntityBehaviourAction;

namespace Roguelike.Behaviours
{
    public class Physical : IBehaviour
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

        public void HandleAction(IAction action)
        {
        }
    }
}
