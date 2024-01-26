using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Numerics;

namespace Graphics
{
    //Stores information necessary to draw an entity
    public class DisplayEntity
    {
        public float Size { get; }
        public Color Color { get; }
        public Microsoft.Xna.Framework.Vector2 Position { get; }
        public DisplayEntity(float size, int color, System.Numerics.Vector2 pos)
        {
            Size = size;
            Color = new(new Microsoft.Xna.Framework.Vector3(color, 1-color, 0));
            Position = new(pos.X, pos.Y);
        }
    }
}
