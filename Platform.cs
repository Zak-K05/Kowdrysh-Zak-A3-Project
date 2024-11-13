using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    public class Platform
    {
        public Vector2 position = new Vector2();
        public Vector2 size = new Vector2();

        public Platform(Vector2 pos, Vector2 s)
        {
            position = pos;
            size = s;
        }

        public void UpdatePlatform()
        {
            // Draw the platform
            
            Draw.FillColor = Color.Gray;
            Draw.LineSize = 2;
            Draw.LineColor = Color.Black;

            Draw.Rectangle(position, size);

        }
    }
}
