using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Game1
{
    public class Game1 : Game
    {
        public Player player;
        public AnimatedSprite anim;
        public Background background;
        public Random rand = new Random();
        public List<Enemy> ListOfEnemies = new List<Enemy>();
        public static Game1 global = null;
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public int windowWidth = 1600;
        public int windowHeight = 800;      
        public List<Bullet> ListOfBullets = new List<Bullet>();
        public int cooldown = 20;
        public int Controlled = 0;
        

        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            Game1.global = this;
        }

        
        protected override void Initialize()
        {
            player = new Player();
            background = new Background();
            anim = new AnimatedSprite();

            // Enemy init
            for (int i = 0; i < 10; i++) {
                 Enemy MyEnemy = new Enemy();
                ListOfEnemies.Add(MyEnemy);
            }
            player.initialize();
            player.loadResources();
            anim.initialize("explosion sheet", 8,6);
            base.Initialize();

        }
        

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Enemy.loadResources();
            Bullet.loadResources();

            
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            
            if (player.state == GameEntity.State.Dead)
            {
                Exit();
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.update();
            background.update();
            
            for(int i = 0;i<ListOfBullets.Count;i++)
            {
                ListOfBullets[i].update();
                if(ListOfBullets[i].state == GameEntity.State.Dead)
                {
                    ListOfBullets.RemoveAt(i);
                }
            }

            for(int i = 0;i < ListOfEnemies.Count; i++)
            {
                ListOfEnemies[i].update();
            }
        }
        


        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            // TODO: Add your drawing code here
            background.draw();
            
            
            // For all bullets
            // bullet.draw()
            for (int i = 0;i<ListOfBullets.Count;i++)
            {
                ListOfBullets[i].draw();
                
            }

            for (int i = 0; i < ListOfEnemies.Count; i++)
            {
                ListOfEnemies[i].draw();

            }
            player.draw();
            
            anim.draw(new Rectangle(5, 5, 300, 300));
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}