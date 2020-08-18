using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Bullet : GameEntity
    {
        public float dx;
        public float dy;
        public float speed = 5;
        static public Texture2D texBall;
        static public Texture2D texPlayer;
        static public Texture2D texFireBall;

        public override void initialize()
        {
            x = 0;
            y = 0;
            dx = 0;
            dy = 0;
            width = 20;
            height = 20;
            state = State.Alive;
            
        }

        public static void loadResources()
        {
            texBall = Game1.global.Content.Load<Texture2D>("ball");
            texFireBall = Game1.global.Content.Load<Texture2D>("Bullet");
            texPlayer = Game1.global.Content.Load<Texture2D>("player");
        }
        override public void update ()
        {
            if (state == State.Dead)
            {
                return;
            }

            if (Game1.global.debugBulletsMove == 1)
            {
                x = x + dx * speed;
                y = y + dy * speed;
            }

            if (x<0 || x > Game1.global.windowWidth || y < 0 || y > Game1.global.windowHeight)
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
            drawSprite(texFireBall);
        }
    }
}