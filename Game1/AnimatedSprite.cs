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
        public int rowLength;
        public int rowCount;
        public int frameCounter = 0;
        int spriteWidth;
        int spriteHeight;
        public void initialize (string name,int RowLength, int RowCount)
        {
            rowLength = RowLength;
            rowCount = RowCount;
            
            sheet = Game1.global.Content.Load<Texture2D>(name);
            spriteWidth = sheet.Width / rowLength;
            spriteHeight = sheet.Height / rowCount;
        }
        public void animate()
        {
            for (int i = 0; i < 8; i++)
            {
                
            }
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
            rectSource.Width = 256;
            rectSource.Height = 248;
            Game1.global.spriteBatch.Draw(sheet, rectDest, rectSource, Color.White);
            frameCounter++;
            if(frameCounter > rowLength* rowCount)
            {
                frameCounter = 0;
            }
        }

    } 
}
