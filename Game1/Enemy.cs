using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        static public Texture2D texMario;

        public override void initialize()
        {
            x = Game1.global.rand.Next(Game1.global.windowWidth / 2, Game1.global.windowWidth);
            y = Game1.global.rand.Next(Game1.global.windowHeight / 2, Game1.global.windowHeight);
            dx = Game1.global.rand.Next(-1, 1);
            dy = Game1.global.rand.Next(-1, 1);
            width = 50;
            height = 50;
        }

        public static void loadResources()
        {
            texMario =Game1.global.Content.Load<Texture2D>("happy mario");

        }

        override public void update ()
        {
            if(state == State.Dead)
            {
                return;
            }
                        
            if (y < Game1.global.player.y )
            {
                dy = 1;
            }
            if (y > Game1.global.player.y)
            {
                dy = -1;
            }
            if (x < Game1.global.player.x)
            {
                dx = 1;
            }
            if (x > Game1.global.player.x)
            {
                dx = -1;
            }

            if (x > Game1.global.player.x - 30 && 
                x < Game1.global.player.x + 30 && 
                y > Game1.global.player.y - 30 && 
                y < Game1.global.player.y + 30)
            {
                Game1.global.player.state = State.Dead;
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

            drawSprite(texMario);
        }
    }
}
