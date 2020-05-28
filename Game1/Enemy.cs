using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Enemy
    {

        float x;
        float y;
        float dx;
        float dy;
        public int enemyAlive = 1;
        int enemyWidth = 50;
        int enemyHeight = 50;
        int enemyHP = 10;
        float speed = 2.0f;

        public Enemy ()
        {
            x = Game1.global.rand.Next(Game1.global.WindowWidth/2, Game1.global.WindowWidth);
            y = Game1.global.rand.Next(Game1.global.WindowHeight/2, Game1.global.WindowHeight);
            dx = Game1.global.rand.Next(-1,1);
            dy = Game1.global.rand.Next(-1, 1);
            
        }
        public void update ()
        {
            if(enemyAlive == 0)
            {
                return;
            }
            
            
            if (y < Game1.global.Player.y )
            {
                dy = 1;
            }
            if (y > Game1.global.Player.y)
            {
                dy = -1;
            }

            if (x < Game1.global.Player.x)
            {
                dx = 1;
            }
            if (x > Game1.global.Player.x)
            {
                dx = -1;
            }

            if (x > Game1.global.Player.x - 30 && 
                x < Game1.global.Player.x + 30 && 
                y > Game1.global.Player.y - 30 && 
                y < Game1.global.Player.y + 30)
            {

                Game1.global.Player.ballAlive = 0;
            }
            x = x + dx * speed;
            y = y + dy * speed;

            for(int i = 0; i<Game1.global.ListOfBullets.Count;i++)
            {
                if( x < Game1.global.ListOfBullets[i].x + 20 && 
                    x > Game1.global.ListOfBullets[i].x - 20 &&
                    y < Game1.global.ListOfBullets[i].y + 20 &&
                    y > Game1.global.ListOfBullets[i].y - 20)
                {
                    Game1.global.ListOfBullets[i].bulletAlive = 0;
                    enemyHP--;
                    
                }
                if (enemyHP <= 0)
                    enemyAlive = 0;
            }
            

        }
        public void draw()
        {
            if (enemyAlive == 0) { 
                
                return;
            }   

            Game1.global.spriteBatch.Draw(Game1.global.texMario,
                new Rectangle((int)x,
                (int)y,
                enemyWidth,
                enemyHeight),
                Color.White);
        }
        
    }
}
