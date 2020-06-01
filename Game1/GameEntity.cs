using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Game1
{
    public abstract class GameEntity
    {
        public enum State
        {
            Dead,
            Alive
        };
        public float x=0;
        public float y=0;
        public float width=50;
        public float height=50;
        public State state=State.Alive;

        public abstract void initialize();
        public abstract void update();
        public abstract void draw();
        public GameEntity()
        {
            initialize();
        }
        protected void drawSprite (Texture2D sprite)
        {
            Game1.global.spriteBatch.Draw(sprite, 
                new Rectangle((int)(x-width/2), 
                (int)(y-height/2), 
                (int)width, 
                (int)height), 
                Color.White);
        }

    }
}
