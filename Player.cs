using Game10003;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    public class Player
    {
        public Vector2 position = new Vector2(0, 0);
        public int radius = 20;
        public int speed = 5;

        public void UpdatePlayer()
        {
            // Get the input for the player

            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                position.X -= speed;
            }
            else if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                position.X += speed;
            }

            // Draw the player

            Draw.FillColor = Color.White;
            Draw.LineSize = 1;

            Draw.Circle(position, radius);
        }
    }
}
