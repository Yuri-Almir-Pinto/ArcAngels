namespace ArcAngels.ArcAngels.Components
{
    public abstract class AbstractComponent
    {
        public abstract string _Name { get; }

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
