using System.Collections.Generic;

namespace Roguelike.EntityBehaviourAction
{
    public class Action
    {
        public string ID { get; set; }
        public Dictionary<string, object> Parameters { get; }

        public Action(string id)
        {
            ID = id;
            Parameters = new Dictionary<string, object>();
        }
    }
}
