using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    public class Coin
    {
        public bool active = true;
        public Vector2 position;
        public int size = 5;

        public Coin(Vector2 pos)
        {
            position = pos;
        }

        public void UpdateCoin()
        {
            // Draw the coin
            
            Draw.FillColor = Color.Yellow;
            Draw.LineSize = 0;

            if (active == true)
            {
                Draw.Circle(position, size);
            }
        }
    }
}
