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
        protected bool pointInRect(float x, float y, float rx, float ry, float rw, float rh)
        {
            bool collided = false;

            if (x > rx &&
                x < rx + rw &&
                y > ry &&
                y < ry + rh)
            {
                collided = true;
            }

            return collided;
        }
        protected bool collisionCheck ( GameEntity other)
        {
            float ox = other.x - other.width / 2;
            float oy = other.y - other.height / 2;
            float ox2 = other.width;
            float oy2 = other.height;

            float tx = x - width / 2;
            float ty = y - height / 2;

            if (pointInRect(x - width / 2, y - height / 2, ox, oy, ox2, oy2)) return true;
            if (pointInRect(x + width / 2, y - height / 2, ox, oy, ox2, oy2)) return true;
            if (pointInRect(x - width / 2, y + height / 2, ox, oy, ox2, oy2)) return true;
            if (pointInRect(x + width / 2, y + height / 2, ox, oy, ox2, oy2)) return true;

            if (pointInRect(ox              , oy               , tx, ty, width, height)) return true;
            if (pointInRect(ox + other.width, oy               , tx, ty, width, height)) return true;
            if (pointInRect(ox              , oy + other.height, tx, ty, width, height)) return true;
            if (pointInRect(ox + other.width, oy + other.height, tx, ty, width, height)) return true;

            return false;
        }
    }
}
