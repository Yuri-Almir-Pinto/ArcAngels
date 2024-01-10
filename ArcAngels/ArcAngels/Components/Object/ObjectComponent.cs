namespace ArcAngels.ArcAngels.Components.Object
{
    // A component that location behavior for an entity.
    public class ObjectComponent : AbstractComponent
    {
        private float _XPosition;
        private float _YPosition;
        public override string _Name
        {
            get { return "Object"; }
        }
    }
}
