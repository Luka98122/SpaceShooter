using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Bullet : GameEntity
    {
        public float dx;
        public float dy;
        public float speed = 5;
        public Random rand = new Random();



        public override void initialize()
        {
            x = 0;
            y = 0;
            dx = 0;
            dy = 0;
            width = 15;
            height = 15;
            state = State.Alive;
        }
        override public void update ()
        {
            if (state == State.Dead)
            {
                return;
            }

            x = x + dx*speed;
            y = y + dy*speed;

            if (x<0 || x > Game1.global.WindowWidth || y < 0 || y > Game1.global.WindowHeight)
            {
                state = State.Dead;
            }
        }
        override public void draw ()
        {
            if( state == State.Dead)
            {
                return;
            }
            Game1.global.spriteBatch.Draw(Game1.global.texBall,
                new Rectangle((int)x,
                (int)y,
                (int)width,
                (int)height),
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
