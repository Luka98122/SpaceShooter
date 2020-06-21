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
        public List<ExplosionEffect> listOfExplosionEffects;

        public void initalize()
        {
            
            listOfExplosionEffects = new List<ExplosionEffect>();
            Texture2D texExplosion = Game1.global.Content.Load<Texture2D>("explosion sheet");
        }

        public void update ()
        {
            for(int i = 0; i < listOfExplosionEffects.Count; i++)
            {
                listOfExplosionEffects[i].update();
            }
        }
        public void draw()
        {
            for (int i = 0; i < Game1.global.effectsManager.listOfExplosionEffects.Count; i++)
            {
                if (Game1.global.effectsManager.listOfExplosionEffects[i].state == GameEntity.State.Dead)
                {
                    return;
                }
                Game1.global.effectsManager.listOfExplosionEffects[i].draw();
            }
        }
        public void addExplosion (float X, float Y)
        {
            ExplosionEffect explosionEffect = new ExplosionEffect();
            explosionEffect.x = X;
            explosionEffect.y = Y;
            listOfExplosionEffects.Add(explosionEffect);
        }
    }
}

//Deals with effects(draws, lifetime) animatedSprites
//list of animated sprites 
//draw(), update(), addExplosion()