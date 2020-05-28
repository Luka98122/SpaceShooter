using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Bullet
    {
        public int bulletWidth = 15;
        public int bulletHeight = 15;
        public float dx;
        public float dy;
        public float x;
        public float y;
        public int bulletAlive = 1;
        public float speed = 5;
        public Random rand = new Random();


        public Bullet() 
        {
            x = 0;
            y = 0;
            dx = 0;
            dy = 0;
            
        }
        public void update ()
        {
            if (bulletAlive == 0)
            {
                return;
            }

            x = x + dx*speed;
            y = y + dy*speed;

            if (x<0 || x > Game1.global.WindowWidth || y < 0 || y > Game1.global.WindowHeight)
            {
                bulletAlive = 0;
            }
        }
        public void draw ()
        {
            if( bulletAlive == 0)
            {
                return;
            }
            Game1.global.spriteBatch.Draw(Game1.global.texBall,
                new Rectangle((int)x,
                (int)y,
                bulletWidth,
                bulletHeight),
                Color.White);


                
/*
            Game1.global.spriteBatch.Draw(texBall, 
                new Rectangle((int)ListOfBalls[i].x, 
                (int)ListOfBalls[i].y, 
                SpriteWidth, 
                SpriteHeight), 
                Color.White);

*/
        }
    }

    

}
