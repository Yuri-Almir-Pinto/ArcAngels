﻿using ArcAngels.ArcAngels.Components.Object;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Components.Spriting
{
    // A component that stores data relevant to rendering an entity on the screen, such as sprites.
    public class DrawableComponent : AbstractComponent
    {
        private readonly Type[] _dependencies = new Type[1] { typeof(ObjectComponent) };
        public override Type[] Dependencies {  get { return _dependencies; } }
        public required Texture2D Texture { get; set; }

    }
}
