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
        public EffectsManager effectsManager = new EffectsManager();
        public int godMode = 0;
        public ExplosionEffect expy;
        public SpawnManager spawnManager = new SpawnManager() { };
        public HUD Hud;
        public int debugBulletsMove = 1;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            Game1.global = this;
        }

        int debugCooldown = 100;
        public void updateDebug ()
        {
            debugCooldown--;
            if (debugCooldown <= 0)
            {
                //effectsManager.addExplosion(100, 100,5000);
                debugCooldown = 100;
            }

        }
        protected override void Initialize()
        {
            spawnManager.initalize();
            player = new Player();
            Hud = new HUD();
            background = new Background();

            // Enemy init
            for (int i = 0; i < rand.Next(5,50); i++) {
                 Enemy MyEnemy = new Enemy();
                ListOfEnemies.Add(MyEnemy);
            }
            spawnManager.initalize();
            player.initialize();
            player.loadResources();
            effectsManager.initalize();
            Hud.initialize();
            base.Initialize();

        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Enemy.loadResources();
            Bullet.loadResources();
            Hud.loadRecources();
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

            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
            {
                debugBulletsMove = 1;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                debugBulletsMove = 0;
            }
            spawnManager.update();
            player.update();
            Hud.update();
            background.update();

            for (int i = 0; i < ListOfBullets.Count; i++)
            {
                ListOfBullets[i].update();
                if (ListOfBullets[i].state == GameEntity.State.Dead)
                {
                    ListOfBullets.RemoveAt(i);
                }
            }

            for (int i = 0; i < ListOfEnemies.Count; i++)
            {
                ListOfEnemies[i].update();
                //ListOfEnemies[i].checkEnemyState();
            }
            updateDebug();
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
            Hud.draw();
            spriteBatch.End();

            // Draw effects
            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.Additive);
            effectsManager.draw();
            //test.draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}