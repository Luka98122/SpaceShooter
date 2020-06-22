using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public int frameX;
        public int frameY;
        public GameEntity.State state = GameEntity.State.Alive;
        public  AnimatedSprite (string name,int RowLength, int RowCount, double animationDelay)
        {
            rowLength = RowLength;
            rowCount = RowCount;
            
            sheet = Game1.global.Content.Load<Texture2D>(name);
            spriteWidth = sheet.Width / rowLength;
            spriteHeight = sheet.Height / rowCount;
            cooldown = animationDelay;
            this.animationDelay = animationDelay;
            Debug.WriteLine("Anim delay " + animationDelay);
        }
        
        public void draw (Rectangle rectDest)
        {
            if (state == GameEntity.State.Dead)
            {
                return;
            }

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
                    state = GameEntity.State.Dead;
                }

                cooldown += animationDelay;
            }
            
        }

    } 
}
