using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcAngels.ArcAngels.Components
{
    public abstract class AbstractComponent
    {
        protected abstract string _Name { get; }

        public override bool Equals(object obj)
        {
            if (obj is AbstractComponent other)
            {
                return this._Name == other._Name;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return _Name.GetHashCode();
        }
    }
}
