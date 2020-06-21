using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class ExplosionEffect
    {
        public float x;
        public float y;
        public float width;
        public float height;
        public float size;
        public float spread;
        public List<AnimatedSprite> explosions = new List<AnimatedSprite>();
        public GameEntity.State state = GameEntity.State.Alive;
        public ExplosionEffect ()
        {
            spread = 0.4f;
            x = 1000;
            y = 400;
            size = 50;
            for (int i = 0;i<10;i++)
            {
                AnimatedSprite anim = new AnimatedSprite("explosion sheet", 8, 6, Game1.global.rand.NextDouble() * 2 + 1);
                anim.x = Game1.global.rand.NextDouble()*2 - 1;
                anim.y = Game1.global.rand.NextDouble()*2 - 1;
                explosions.Add(anim);
            }
        }
        public void update ()
        {
            //Nothing to update
        }

        public void draw ()
        {

            for (int i = 0; i < explosions.Count; i++) {

                Rectangle r = new Rectangle(0,0, 0,0);
                r.X = (int)(x + explosions[i].x*spread*size);
                r.Y = (int)(y + explosions[i].y*spread*size);
                r.Width = (int)size;
                r.Height = (int)size;
                

                if (explosions[i].state == GameEntity.State.Dead)
                {
                    explosions.RemoveAt(i);

                }
                else
                {
                    explosions[i].draw(r);
                }
            }
        }
    }
}