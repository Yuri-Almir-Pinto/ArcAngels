using ArcAngels.ArcAngels.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ArcAngels.ArcAngels.Systems.Event
{
    public class SystemsArgs : EventArgs
    {
        public List<AbstractComponent> data;
        public SystemsArgs(params AbstractComponent[] eventData)
        {
            data = eventData.ToList();
        }
    }
}
