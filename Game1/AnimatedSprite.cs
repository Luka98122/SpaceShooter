using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game1
{
    public class AnimatedSprite
    {
        public Texture2D sheet;
        public double x;
        public double y;
        public int rowLength;
        public int rowCount;
        public int frameCounter = 0;
        public int spriteWidth;
        public int spriteHeight;
        public double cooldown;
        public double animationDelay;
        public void initialize (string name,int RowLength, int RowCount, double animationDelay)
        {
            rowLength = RowLength;
            rowCount = RowCount;
            
            sheet = Game1.global.Content.Load<Texture2D>(name);
            spriteWidth = sheet.Width / rowLength;
            spriteHeight = sheet.Height / rowCount;
            cooldown = animationDelay;
            this.animationDelay = animationDelay;
        }
        
        public void draw (Rectangle rectDest)
        {
            int frameX;
            int frameY;
            Rectangle rectSource = new Rectangle();

            frameY = frameCounter / rowLength;
            frameX = frameCounter % rowLength;
            
    
            rectSource.X = frameX*spriteWidth;
            rectSource.Y = frameY*spriteHeight;
            rectSource.Width = spriteWidth;
            rectSource.Height = spriteHeight;
            Color c = new Color(1.0f, 1.0f, 1.0f, 0.7f);
            Game1.global.spriteBatch.Draw(sheet, rectDest, rectSource, c);

            cooldown--;
            if (cooldown <= 0)
            {
                frameCounter++;
                if (frameCounter > rowLength * rowCount)
                {
                    frameCounter = 0;
                }

                cooldown += animationDelay;
            }
            
        }

    } 
}
