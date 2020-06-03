using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    public class Background : GameEntity
    {
        public Texture2D texSpaceBackground;
        public override void initialize()
        {
            texSpaceBackground = Game1.global.Content.Load<Texture2D>("Space Background");
            x = Game1.global.windowWidth/2;
            y = Game1.global.windowHeight / 2 ;
            width = Game1.global.windowWidth*1.25f;
            height = Game1.global.windowHeight*1.25f;
        }
        public override void draw()
        {
            drawSprite(texSpaceBackground);
        }
        public override void update()
        {
            x = -(Game1.global.player.x - Game1.global.windowWidth / 2) / 4 + Game1.global.windowWidth / 2;
            y = -(Game1.global.player.y - Game1.global.windowHeight / 2) / 4 + Game1.global.windowHeight / 2;
        }
    }
}
