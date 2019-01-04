using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;
using Engine.Core.Component;

namespace Engine.Graphics
{
    public class Rectangle2D : Component
    {
        protected Texture2D texture;

        protected float[] vertices;

        public Rectangle2D(GameObject gob) : base(gob)
        {
        }
    }
}
