namespace ArcAngels.ArcAngels.Components.Object
{
    // A component that location behavior for an entity.
    public class ObjectComponent : AbstractComponent
    {
        public float XPosition;
        public float YPosition;
        public override string Name
        {
            get { return "Object"; }
        }
    }
}
