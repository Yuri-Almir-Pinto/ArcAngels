namespace ArcAngels.ArcAngels.Components.Object
{
    // A component that stores data about the location of an entity.
    public class ObjectComponent : AbstractComponent
    {
        public required float XPosition {  get; set; }
        public required float YPosition { get; set; }
    }
}
