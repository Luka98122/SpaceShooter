using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;




namespace Game1
{
    public class EnemyBouncer : GameEntity
    {
        public double angle = 0;
        public float dx;
        public float dy;
        public float speed = 4;
        public int enemyHP = 3;
        public int explosionXoffset = 100;
        public int explosionYoffset = 100;
        public float size = 25.01f;

        static public Texture2D texAlien2;

        public override void draw()
        {
            if (state == State.Dead)
            {

                return;
            }

            drawSprite(texAlien2);
        }
        public override void update()
        {
            movement();
            checkEnemyState();
            killEnemies();
        }

        public override void initialize()
        {
            x = (float) (Game1.global.rand.NextDouble()*1200 + 200);
            y = Game1.global.rand.Next(200, 600); 
            angle = Game1.global.rand.NextDouble() * Math.PI * 2;
            dx = (float)(Math.Cos(angle));
            dy = (float)(Math.Sin(angle));
        }
    
        public void movement ()
        {
            if (x >= Game1.global.windowWidth)
                dx = -1;
            if (x <= 1)
                dx = 1;
            if (y >= Game1.global.windowHeight)
                dy = -1;
            if (y <= 0)
                dy = 1;

            x = x + dx * speed;
            y = y + dy * speed;
        }
        public static void loadResources()
        {
            texAlien2 = Game1.global.Content.Load<Texture2D>("Alien2");
        }

        public void checkEnemyState()
        {
            for (int i = 0; i < Game1.global.ListOfBullets.Count; i++)
            {
                if (Game1.global.ListOfBullets[i].state != State.Dead && collisionCheck(Game1.global.ListOfBullets[i]) && state != State.Dead)
                {
                    Game1.global.ListOfBullets[i].state = State.Dead;
                    enemyHP--;
                }
                if (enemyHP <= 0 && state != State.Dead)
                {
                    state = State.Dead;

                    Game1.global.effectsManager.addExplosion(
                        x - explosionXoffset,
                        y - explosionYoffset, size);
                }
            }
        }

        public void killEnemies()
        {
            for (int i = 0; i < Game1.global.ListOfEnemyBouncers.Count; i++)
            {
                if (Game1.global.ListOfEnemyBouncers[i].state == State.Dead)
                {
                    Game1.global.ListOfEnemyBouncers.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}