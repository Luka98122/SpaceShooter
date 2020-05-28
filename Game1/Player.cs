using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Game1
{
    public class Player
    {
        //   static Random rand = new Random();
        public int WindowWidth = 800;
        public int WindowHeight = 480;
        public float x;
        public float y;
        public float dx;
        public float dy;
        public int SpriteWidth = 50;
        public int SpriteHeight = 50;
        public int ballAlive = 1;
        public int bombCount = 3;


        public Player()
        {
            x = Game1.global.rand.Next(1, WindowWidth / 2);
            y = Game1.global.rand.Next(1, WindowHeight / 2);
            dx = 5;
            dy = 5;
        }

        
        public void SummonEnemies()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && Game1.global.summonCooldown <= 0)
            {
                Enemy MyEnemy = new Enemy();
                Game1.global.ListOfEnemies.Add(MyEnemy);
                Game1.global.summonCooldown = 20;
            }
            Game1.global.summonCooldown--;
        }
        public void bombing() {
            if (GamePad.GetState(PlayerIndex.One).Triggers.Right >= 0.7 && bombCount > 0 && Game1.global.bombcooldown < 0)
            {
                bombCount--;
                for (int i = 0; i < Game1.global.ListOfEnemies.Count; i++)
                {
                    Game1.global.ListOfEnemies[i].enemyAlive = 0;
                }
                Console.Beep(200, 600);
                Game1.global.bombcooldown = 10;
            }
                Game1.global.bombcooldown--;
        }

        public void movement ()
        {
            int speed = 15;
            float UD = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;
            float LR = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            
            if (LR >= 0.3)
            {

                Game1.global.Player.dx = speed * LR;
                Game1.global.Player.x = Game1.global.Player.x + Game1.global.Player.dx;
            }
            if (LR <= -0.3)
            {
                Game1.global.Player.dx = -speed * LR;
                Game1.global.Player.x = Game1.global.Player.x - Game1.global.Player.dx;
            }
            if (UD >= 0.3)
            {
                Game1.global.Player.dy = speed * UD;
                Game1.global.Player.y = Game1.global.Player.y - Game1.global.Player.dy;
            }
            if (UD <= -0.3)
            {
                Game1.global.Player.dy = -speed * UD;
                Game1.global.Player.y = Game1.global.Player.y + Game1.global.Player.dy;
            }
        }
        public void Shooting ()
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
                    MyBullet.x = Game1.global.Player.x;
                    MyBullet.y = Game1.global.Player.y;
                    Game1.global.ListOfBullets.Add(MyBullet);
                    Game1.global.cooldown = 1;
                }
                Game1.global.cooldown--;
            }
        }
        public void update()
        {

            if (ballAlive == 0)
            {
                return;
            }
            Game1.global.Player.bombing();
            Game1.global.Player.SummonEnemies();
            Game1.global.Player.movement();
            Game1.global.Player.Shooting();
            //x = x + dx;
            //y = y + dy;

            if (x <= dx)
            {

                x = 1;
            }
            if (x >= WindowWidth - SpriteWidth)
            {
                x = WindowWidth - SpriteWidth;
            }

            if (y <= dy)
            {

                y = 1;
            }
            if (y >= WindowHeight - SpriteHeight)
            {
                y = WindowHeight - SpriteHeight;
            }

            if (x <= 1)
            {
                x = WindowWidth - SpriteHeight - 2;

            }
            if (x >= WindowWidth - SpriteHeight - 1)
            {
                x = 2;

            }
            if (y <= 1)
            {
                y = WindowHeight - SpriteHeight - 2;

            }
            if (y >= WindowHeight - SpriteHeight - 1)
            {
                y = 2;

            }

        }


    }
}
