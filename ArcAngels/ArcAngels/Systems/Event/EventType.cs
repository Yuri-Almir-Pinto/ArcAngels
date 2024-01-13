using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcAngels.ArcAngels.Systems.Event
{
    public partial class EventType
    {
        public static readonly EventType Event = new("Event");
        public static readonly EventType Event2 = new("Event");

        public string Type;

        public EventType(string eventType)
        {
            Type = eventType;
        }

    }
}
