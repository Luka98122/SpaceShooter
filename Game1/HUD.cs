using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class HUD : GameEntity
    {
        static public Texture2D texHeart;
        public override void draw()
        {
            float width = 50;
            float height = 50;
            int x = Convert.ToInt32(width);
            int y = Convert.ToInt32(height);
            
            for(int i = 0;i<Game1.global.player.lives;i++)
            {
                Game1.global.spriteBatch.Draw(texHeart,
                    new Rectangle( x*i,
                        0,
                        (int)width,
                        (int)height),
                        Color.White);
            }
        }

        public override void initialize()
        {
        }
        public override void update()
        {
        }
        public void loadRecources ()
        {
            texHeart = Game1.global.Content.Load<Texture2D>("Heart");
        }
    }
}