// Include code libraries you need below (use the namespace).
using Platformer;
using System;
using System.Numerics;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Player player = new Player();

        int coinsCollected = 0;

        Platform[] platforms = [
            new Platform(new Vector2(-10, 60), new Vector2(130, 40)),
            new Platform(new Vector2(160, 120), new Vector2(120, 40)),
            new Platform(new Vector2(320, 160), new Vector2(80, 60)),
            new Platform(new Vector2(240, 220), new Vector2(60, 40)),
            new Platform(new Vector2(140, 260), new Vector2(80, 20)),
            new Platform(new Vector2(20, 360), new Vector2(180, 60)),
            new Platform(new Vector2(240, 380), new Vector2(50, 60)),
        ];

        Coin[] coins = [
            new Coin(new Vector2(170, 110)),
            new Coin(new Vector2(190, 110)),
            new Coin(new Vector2(210, 110)),
            new Coin(new Vector2(230, 110)),
            new Coin(new Vector2(250, 110)),
            new Coin(new Vector2(270, 110)),

            new Coin(new Vector2(370, 150)),
            new Coin(new Vector2(390, 150)),

            new Coin(new Vector2(250, 210)),
            new Coin(new Vector2(270, 210)),
            new Coin(new Vector2(290, 210)),

            new Coin(new Vector2(50, 350)),
            new Coin(new Vector2(70, 350)),
            new Coin(new Vector2(90, 350)),
            new Coin(new Vector2(110, 350)),
        ];

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetSize(400, 400);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            UpdatePlatforms();
            UpdateCoins();
            player.UpdatePlayer();

            PlatformCollisions();
            WindowCollision();
            CoinCollision();
        }

        public void UpdatePlatforms()
        {
            for (int i = 0; i < platforms.Length; i++)
            {
                platforms[i].UpdatePlatform();
            }
        }

        public void UpdateCoins()
        {
            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].UpdateCoin();
            }
        }

        public void PlatformCollisions()
        {
            bool onAPlatform = false;

            for (int i = 0; i < platforms.Length; i++)
            {
                Platform platform = platforms[i];

                // Check if the player's bottom is above the platform's top
                if (player.position.Y + player.radius <= platform.position.Y &&
                    player.position.X + player.radius > platform.position.X &&
                    player.position.X - player.radius < platform.position.X + platform.size.X)
                {
                    // Check if the player is close enough to platform
                    float distanceToPlatform = platform.position.Y - (player.position.Y + player.radius);
                    if (distanceToPlatform <= 1f)
                    {
                        onAPlatform = true;

                        // Stop the player from falling through the platform
                        player.position.Y = platform.position.Y - player.radius;
                        break;
                    }
                }
            }

            // If the player is not standing on any platform, gravity applies
            if (!onAPlatform)
            {
                // Add gravity
                player.position.Y += 10;
            }
        }

        public void CoinCollision()
        {
            for (int i = 0; i < coins.Length; i++)
            {
                Coin coin = coins[i];

                if (Vector2.Distance(player.position, coin.position) < player.radius)
                {
                    coin.active = false;
                    coinsCollected++;
                }
            }
        }

        public void WindowCollision()
        {
            if (player.position.X - player.radius < 0)
            {
                player.position.X = 0 + player.radius;
            }

            if (player.position.X + player.radius > Window.Width)
            {
                player.position.X = Window.Width - player.radius;
            }
        }
    }
}
