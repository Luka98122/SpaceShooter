using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class EnemyWanderer : GameEntity
    {
        public double angle = 0;
        public float dx;
        public float dy;
        public float speed = 4;
        public int enemyHP = 3;
        public int explosionXoffset = 100;
        public int explosionYoffset = 100;
        public float size = 25.01f;
        public int directionCooldown = 10;

        //static public Texture2D texAlien2;

        public override void draw()
        {
            if (state == State.Dead)
            {

                return;
            }
            //drawSprite(texAlien2);
        }
        public override void update()
        {
            movement();
            //checkEnemyState();
            //killEnemies();
        }
        public override void initialize()
        {
            x = (float)(Game1.global.rand.NextDouble() * 1200 + 200);
            y = Game1.global.rand.Next(200, 600);
            angle = Game1.global.rand.NextDouble() * Math.PI * 2;
            dx = (float)(Math.Cos(angle));
            dy = (float)(Math.Sin(angle));
        }

        public void movement ()
        {
            directionCooldown--;
            if(directionCooldown < 0)
            {
                directionCooldown = 100;
                angle = Game1.global.rand.NextDouble() * Math.PI * 2;
                dx = (float)(Math.Cos(angle));
                dy = (float)(Math.Sin(angle));
            }
        }


    
    }
}
