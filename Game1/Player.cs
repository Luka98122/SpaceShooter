using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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

        public void update()
        {
            if (ballAlive == 0)
            {
                return;
            }
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
