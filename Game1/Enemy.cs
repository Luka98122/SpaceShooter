using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class Enemy : GameEntity
    {
        float dx;
        float dy;
        int enemyHP = 1;
        float speed = 2.9f;

        public override void initialize()
        {
            x = Game1.global.rand.Next(Game1.global.WindowWidth / 2, Game1.global.WindowWidth);
            y = Game1.global.rand.Next(Game1.global.WindowHeight / 2, Game1.global.WindowHeight);
            dx = Game1.global.rand.Next(-1, 1);
            dy = Game1.global.rand.Next(-1, 1);
            width = 50;
            height = 50;
        }

        override public void update ()
        {
            if(state == State.Dead)
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

            for (int i = 0; i < Game1.global.ListOfBullets.Count; i++)
            {
                if (x < Game1.global.ListOfBullets[i].x + 20 &&
                    x > Game1.global.ListOfBullets[i].x - 20 &&
                    y < Game1.global.ListOfBullets[i].y + 20 &&
                   y > Game1.global.ListOfBullets[i].y - 20)
                {
                    Game1.global.ListOfBullets[i].state = State.Dead;
                    enemyHP--;
                }
                if (enemyHP <= 0)
                {
                   state = State.Dead;
                }
            }
        }
        override public void draw()
        {
            if (state == State.Dead) { 
                return;
            }   

            Game1.global.spriteBatch.Draw(Game1.global.texMario,
                new Rectangle((int)x,
                (int)y,
                (int)width,
                (int)height),
                Color.White);
        }
    }
}
