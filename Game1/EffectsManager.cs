using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class EffectsManager
    {
        public List<AnimatedSprite> listOfAnimatedSprites;

        public void initalize()
        {
            
            listOfAnimatedSprites = new List<AnimatedSprite>();
            Texture2D texExplosion = Game1.global.Content.Load<Texture2D>("explosion sheet");
        }

        public void update ()
        {

        }
        public void draw()
        {
        }
        public void addExplosion ()
        {
            AnimatedSprite animatedSprite = new AnimatedSprite();
            listOfAnimatedSprites.Add(animatedSprite);
        }
    }
}

//Deals with effects(draws, lifetime) animatedSprites
//list of animated sprites 
//draw(), update(), addExplosion()