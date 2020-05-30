using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Player : GameEntity
    {
        public int windowWidth = 800; //TODO: remove
        public int windowHeight = 480;//TODO: remove
        public float dx;
        public float dy;
        public int bombCount = 3;
        public int portalcooldown = 30;
        static public Texture2D texBall;

        public override void initialize()
        {
            x = Game1.global.rand.Next(1, windowWidth / 2);
            y = Game1.global.rand.Next(1, windowHeight / 2);
            dx = 5;
            dy = 5;
            height = 50;
            width = 50;
        }
        
        public void loadResources()
        {
            texBall = Game1.global.Content.Load<Texture2D>("ball");
        }


        public void updateSummonEnemies()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && Game1.global.summonCooldown <= 0)
            {
                Enemy MyEnemy = new Enemy();
                Game1.global.ListOfEnemies.Add(MyEnemy);
                Game1.global.summonCooldown = 20;
            }
            Game1.global.summonCooldown--;
        }

        // BUG: Portals broken
        public void updateBombing() {
            if (GamePad.GetState(PlayerIndex.One).Triggers.Right >= 0.7 && bombCount > 0 && Game1.global.bombcooldown < 0)
            {
                bombCount--;
                for (int i = 0; i < Game1.global.ListOfEnemies.Count; i++)
                {
                    Game1.global.ListOfEnemies[i].state = GameEntity.State.Dead;
                }
                Console.Beep(200, 600);
                Game1.global.bombcooldown = 10;
            }
                Game1.global.bombcooldown--;
        }

        public void updateMovement ()
        {
            int speed = 5;
            float UD = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;
            float LR = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            
            if (LR >= 0.3)
            {
                dx = speed * LR;
                x = x + dx;
            }
            if (LR <= -0.3)
            {
                dx = -speed * LR;
                x = x - dx;
            }
            if (UD >= 0.3)
            {
                dy = speed * UD;
                y = y - dy;
            }
            if (UD <= -0.3)
            {
                dy = -speed * UD;
                y = y + dy;
            }
        }
        public void updateShooting ()
        {
            float shooterX = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X;
            float shooterY = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y;

            if (shooterX >= 0.3 || shooterX <= -0.3 || shooterY >= 0.3 || shooterY <= -0.3)
            {
                if (Game1.global.cooldown == 0)
                {
                    Bullet MyBullet = new Bullet();
                    MyBullet.dx = shooterX;
                    MyBullet.dy = -shooterY;
                    MyBullet.x = x;
                    MyBullet.y = y;
                    Game1.global.ListOfBullets.Add(MyBullet);
                    Game1.global.cooldown = 5;
                }
                Game1.global.cooldown--;
            }
        }
        
        public void updatePortal ()
        {
            //TODO: use game windowheight
            if (x <= 1 && portalcooldown <= 0)
            {
                x = width - height - 2;
                portalcooldown = 400;
            }
            if (x >= width - height - 1 && portalcooldown <= 0)
            {
                x = 2;
                portalcooldown = 400;
            }
            if (y <= 1 && portalcooldown <= 0)
            {
                y = height - height - 2;
                portalcooldown = 400;
            }
            if (y >= height - height - 1 && portalcooldown <= 0)
            {
                y = 2;
                portalcooldown = 400;
            }
        }

        public void updateBorder ()
        {
            if (x <= dx)
            {
                x = 1;
            }
            if (x >= windowWidth - width)
            {
                x = windowWidth - width;
            }
            if (y <= dy)
            {
                y = 1;
            }
            if (y >= windowHeight - height)
            {
                y = windowHeight - height;
            }
        }

        override public void update()
        {
            if (state == State.Dead)
            {
                return;
            }
            updateBombing();
            updateSummonEnemies();
            updateMovement();
            updateShooting();
            updatePortal();
            updateBorder();
        }
        public override void draw()
        {
            if (state == State.Dead)
            {
                return;
            }
            Game1.global.spriteBatch.Draw(texBall, new Rectangle((int)x, (int)y, (int)width, (int)height), Color.White);
        }
    }
}