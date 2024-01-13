using ArcAngels.ArcAngels.Components.Object;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Components.Spriting
{
    // A component that stores data relevant to rendering an entity on the screen, such as sprites.
    public class DrawableComponent : AbstractComponent
    {
        public override Type[] Dependencies 
        { 
            get 
            {
                return new Type[1]
                {
                    typeof(ObjectComponent)
                }; 
            } 
        }
        public required Texture2D Texture { get; set; }

    }
}
