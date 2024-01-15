using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcAngels.ArcAngels.Systems.Event
{
    public partial class EventType
    {
        // Fired on every game update in the main 'Update()' method.
        public static readonly EventType Update = new("Update");

        public string Type;

        private EventType(string eventType)
        {
            Type = eventType;
        }

    }
}
