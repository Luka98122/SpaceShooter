using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class AnimatedSprite
    {
        public Texture2D sheet;

        public void initialize (string name)
        {
            sheet = Game1.global.Content.Load<Texture2D>(name);
        }
        public void animate()
        {
            for (int i = 0; i < 8; i++)
            {
                
            }
        }
        public void draw (Rectangle rectDest, int frame)
        {
            int frameX = 7;
            int frameY = 5;
            Rectangle rectSource = new Rectangle();
            rectSource.X = frameX*256;
            rectSource.Y = frameY*248;
            rectSource.Width = 256;
            rectSource.Height = 248;
            Game1.global.spriteBatch.Draw(sheet, rectDest, rectSource, Color.White);
        }

    } 
}
