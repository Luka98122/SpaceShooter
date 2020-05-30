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
        public Player Player;
        public Random rand = new Random();
        public List<Enemy> ListOfEnemies = new List<Enemy>();
        public static Game1 global = null;
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public Texture2D texBall;
        public Texture2D texMario;
        public int WindowWidth = 800;
        public int WindowHeight = 480;
        public List<Bullet> ListOfBullets = new List<Bullet>();
        public int cooldown = 20;
        public int Controlled = 0;
        public int summonCooldown = 20;
        public int bombCount = 3;
        public int bombcooldown = 20;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Game1.global = this;
        }

        
        protected override void Initialize()
        {
            Player = new Player();


            // Enemy init
            for (int i = 0; i < 10; i++) {
                 Enemy MyEnemy = new Enemy();
                ListOfEnemies.Add(MyEnemy);
            }

            base.Initialize();

        }
        

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            texBall = Content.Load<Texture2D>("ball");
            texMario = Content.Load<Texture2D>("happy mario");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

       
        protected override void Update(GameTime gameTime)
        {
            if(Player.ballAlive == 0)
            {
                Exit();
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Player.update();
            
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
            /*
            if (--debugCooldown <= 0) {
                Debug.WriteLine("Number of bullets " + ListOfBullets.Count);
                debugCooldown = 20;
            }
            base.Update(gameTime); */
        }
        static int debugCooldown = 20;
        


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);
            spriteBatch.Begin();

            int SpriteWidth = 50;
            int SpriteHeight = 50;
            // TODO: Add your drawing code here
            
                if(Player.ballAlive == 1)
                spriteBatch.Draw(texBall, new Rectangle((int)Player.x, (int)Player.y, SpriteWidth, SpriteHeight), Color.White);
                
            
            // For all bullets
            // bullet.draw()
            for(int i = 0;i<ListOfBullets.Count;i++)
            {
                ListOfBullets[i].draw();
                
            }

            for (int i = 0; i < ListOfEnemies.Count; i++)
            {
                ListOfEnemies[i].draw();

            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}