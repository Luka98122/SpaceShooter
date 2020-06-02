using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Player : GameEntity
    {

        public float dx;
        public float dy;
        public int portalcooldown = 30;
        static public Texture2D texBall;
        public int summonCooldown = 20;     
        public int bombCount = 3;           
        public int bombcooldown = 20;       

        public override void initialize()
        {
            x = Game1.global.rand.Next(1, Game1.global.windowWidth / 2);
            y = Game1.global.rand.Next(1, Game1.global.windowHeight / 2);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && summonCooldown <= 0)
            {
                Enemy MyEnemy = new Enemy();
                Game1.global.ListOfEnemies.Add(MyEnemy);
                summonCooldown = 20;
            }
            summonCooldown--;
        }

        public void updateBombing() {
            if (GamePad.GetState(PlayerIndex.One).Triggers.Right >= 0.7 && bombCount > 0 && bombcooldown < 0)
            {
                bombCount--;
                for (int i = 0; i < Game1.global.ListOfEnemies.Count; i++)
                {
                    Game1.global.ListOfEnemies[i].state = GameEntity.State.Dead;
                }
                Console.Beep(200, 600);
                bombcooldown = 10;
            }
                bombcooldown--;
        }

        public void updateMovement ()
        {
            int speed = 4;
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
                    Game1.global.cooldown = 4;
                }
                Game1.global.cooldown--;
            }
        }
        
        public void updatePortal ()
        {
            
            if (x - width/2 <= 2 && portalcooldown <= 0)
            {
                x = Game1.global.windowWidth - width + 2;
                portalcooldown = 100;
            }
            if (x >= Game1.global.windowWidth - width/2 + 2 && portalcooldown <= 0)
            {
                x = 2;
                portalcooldown = 100;
            }
            if (y - height/2 <= 2 && portalcooldown <= 0)
            {
                y = Game1.global.windowHeight - height - 2;
                portalcooldown = 100;
            }
            if (y >= Game1.global.windowHeight - height/2 + 2 && portalcooldown <= 0)
            {
                y = 3;
                portalcooldown = 100;
            }
            portalcooldown--;
        }

        public void updateBorder ()
        {
            if (x - width/2<= dx)
            {
                x = width/2+1;
            }
            if (x >= Game1.global.windowWidth - width/2)
            {
                x = Game1.global.windowWidth - width/2+1;
            }
            if (y - height/2<= dy)
            {
                y = height/2+1;
            }
            if (y >= Game1.global.windowHeight - height/2)
            {
                y = Game1.global.windowHeight - height/2+1;
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
            drawSprite(texBall);
        }
    }
}