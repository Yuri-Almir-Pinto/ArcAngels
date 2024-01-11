namespace ArcAngels.ArcAngels.Components.Object
{
    // A component that stores data about the location of an entity.
    public class ObjectComponent : AbstractComponent
    {
        public float XPosition {  get; set; }
        public float YPosition { get; set; }

        public ObjectComponent(float Xpos, float Ypos)
        {
            XPosition = Xpos;
            YPosition = Ypos;
        }
    }
}
