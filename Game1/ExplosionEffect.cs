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
        public List<AnimatedSprite> explAnims = new List<AnimatedSprite>();
        public GameEntity.State state = GameEntity.State.Alive;
        public ExplosionEffect ()
        {
            spread = 0.9f;
            x = 1000;
            y = 400;
            size = 50;
            int cAnims = Game1.global.rand.Next(4, 10);
            cAnims = Game1.global.rand.Next(4,10);
            for (int i = 0; i<cAnims; i++)
            {
                AnimatedSprite anim = new AnimatedSprite("explosion sheet", 8, 6, Game1.global.rand.NextDouble() * 2 + 1);
                anim.x = Game1.global.rand.NextDouble()*2 - 1;
                anim.y = Game1.global.rand.NextDouble()*2 - 1;
                explAnims.Add(anim);
            }
        }
        public void update ()
        {
            for(int i = 0;i<explAnims.Count;i++)
            {
                if (explAnims[i].state == GameEntity.State.Dead)
                {
                    explAnims.RemoveAt(i);
                }
            }
        }

        public void draw ()
        {
            for (int i = 0; i < explAnims.Count; i++) {

                Rectangle r = new Rectangle(0,0, 0,0);
                r.X = (int)(x + explAnims[i].x*spread*size);
                r.Y = (int)(y + explAnims[i].y*spread*size);
                r.Width = (int)100;
                r.Height = (int)100;
                
                explAnims[i].draw(r);
            }
        }
    }
}