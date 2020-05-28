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
            if(GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed && summonCooldown <= 0)
            {
                Enemy MyEnemy = new Enemy();
                ListOfEnemies.Add(MyEnemy);
                summonCooldown = 20;
            }
            if(GamePad.GetState(PlayerIndex.One).Triggers.Right >= 0.7 && bombCount>0 && bombcooldown <0 )
            {
                bombCount--;
                for(int i = 0;i<ListOfEnemies.Count;i++)
                {
                    ListOfEnemies[i].enemyAlive = 0;
                }
                Thread.Sleep(100);
                Console.Beep(200, 600);
                bombcooldown = 10;
            }
            bombcooldown--;

            summonCooldown--;
                
            int speed = 15;
              

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            float UD = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;
            float LR = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            float shooterX = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X;
            float shooterY = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y;
            
               
            if(GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
            {
               if(Player.dx < 0)
                  Player.dx = rand.Next(-10, -1);
               else {
                     Player.dx = rand.Next(1, 10);
                    }
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
                {
                if (Player.dy < 0)
                    Player.dy = rand.Next(-10, -1);
                else
                {
                    Player.dy = rand.Next(1, 10);
                }
            } 
            if(LR >= 0.3)
            {
                 
                Player.dx = speed * LR;
                Player.x = Player.x + Player.dx;
            }
            if (LR <= -0.3)
            {
                Player.dx = -speed * LR;
                Player.x = Player.x - Player.dx;
            }
            if (UD >= 0.3)
            {
                Player.dy = speed * UD;
                Player.y = Player.y - Player.dy;
            }
            if (UD <= -0.3)
            {
                Player.dy = -speed * UD;
                Player.y = Player.y + Player.dy;
            }

            // Handle bullet creation
            if ( shooterX >= 0.3   || shooterX <= -0.3 || shooterY >= 0.3 || shooterY <= -0.3)  
            {
                if (Game1.global.cooldown == 0)
                {
                    Bullet MyBullet = new Bullet();
                    MyBullet.dx = shooterX;
                    MyBullet.dy = -shooterY;
                    MyBullet.x = Player.x;
                    MyBullet.y = Player.y;
                    ListOfBullets.Add(MyBullet);
                    Game1.global.cooldown = 1;
                }
                Game1.global.cooldown--;
            }

            // Do the update
            Player.update();
            
            for(int i = 0;i<ListOfBullets.Count;i++)
            {
                ListOfBullets[i].update();
                if(ListOfBullets[i].bulletAlive == 0)
                {
                    ListOfBullets.RemoveAt(i);
                }
            }

            for(int i = 0;i < ListOfEnemies.Count; i++)
            {
                ListOfEnemies[i].update();
            }

            if (--debugCooldown <= 0) {
                Debug.WriteLine("Number of bullets " + ListOfBullets.Count);
                debugCooldown = 20;
            }
            base.Update(gameTime);
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