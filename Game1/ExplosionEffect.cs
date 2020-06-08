using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class ExplosionEffect
    {
        public int x;
        public int y;
        public float width;
        public float height;
        public float size;
        public float spread;
        public List<AnimatedSprite> explosions = new List<AnimatedSprite>();
        public void initalize ()
        {
            spread = 0.4f;
            x = 1000;
            y = 400;
            size = 100;
            for (int i = 0;i<10;i++)
            {
                AnimatedSprite anim = new AnimatedSprite();
                anim.x = Game1.global.rand.NextDouble()*2 - 1;
                anim.y = Game1.global.rand.NextDouble()*2 - 1;
                anim.initialize("explosion sheet",8,6,Game1.global.rand.NextDouble()*2 + 1);
                explosions.Add(anim);
            }
        }
        public void update ()
        {
            for(int i = 0;i<explosions.Count;i++)
            {
                
            }
        }

        public void draw ()
        {

            for (int i = 0; i < explosions.Count; i++) {

                Rectangle r = new Rectangle(0,0, 0,0);
                r.X = (int)(x + explosions[i].x*spread*size);
                r.Y = (int)(y + explosions[i].y*spread*size);
                r.Width = (int)size;
                r.Height = (int)size;


                explosions[i].draw(r);
            }
        }
    }
}