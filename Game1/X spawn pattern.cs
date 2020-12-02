using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class X_spawn_pattern : SpawnWaveBaseClass
    {
        public int cooldown = 0;
        public int howmanyEnemies = 20;
        public int enemiesSoFar = 0;
        public int x = Game1.global.rand.Next(300, 1300);
        public int y = Game1.global.rand.Next(200, 600);
        public int spacing = Game1.global.rand.Next(3, 7);
        public int enemyChances = 0;
        public override void initialize(int EnemyChances)
        {
            enemyChances = EnemyChances;
        }

        public override void update()
        {
            int enemyType = 0;
            int hit = Game1.global.rand.Next(0, 100);
            if (hit < enemyChances)
                enemyType = 1;

            cooldown--;

            if (cooldown <= 15)
            {
                if (enemyType == 0) { 
                    Enemy enemy = new Enemy();
                    enemy.x = x + enemiesSoFar * spacing;
                    enemy.y = y + enemiesSoFar * spacing;
                    Game1.global.ListOfEnemies.Add(enemy);
                    enemiesSoFar++;

                    Enemy enemy2 = new Enemy();
                    enemy2.x = x - enemiesSoFar * spacing;
                    enemy2.y = y + enemiesSoFar * spacing;
                    Game1.global.ListOfEnemies.Add(enemy2);
                    enemiesSoFar++;

                    Enemy enemy3 = new Enemy();
                    enemy3.x = x + enemiesSoFar * spacing;
                    enemy3.y = y - enemiesSoFar * spacing;
                    Game1.global.ListOfEnemies.Add(enemy3);
                    enemiesSoFar++;

                    Enemy enemy4 = new Enemy();
                    enemy4.x = x - enemiesSoFar * spacing;
                    enemy4.y = y - enemiesSoFar * spacing;
                    Game1.global.ListOfEnemies.Add(enemy4);
                    cooldown = 30;
                    enemiesSoFar++;
                }
                else {
                    EnemyBouncer enemy = new EnemyBouncer();
                    enemy.x = x + enemiesSoFar * spacing;
                    enemy.y = y + enemiesSoFar * spacing;
                    Game1.global.ListOfEnemyBouncers.Add(enemy);
                    enemiesSoFar++;

                    EnemyBouncer enemy2 = new EnemyBouncer();
                    enemy2.x = x - enemiesSoFar * spacing;
                    enemy2.y = y + enemiesSoFar * spacing;
                    Game1.global.ListOfEnemyBouncers.Add(enemy2);
                    enemiesSoFar++;

                    EnemyBouncer enemy3 = new EnemyBouncer();
                    enemy3.x = x + enemiesSoFar * spacing;
                    enemy3.y = y - enemiesSoFar * spacing;
                    Game1.global.ListOfEnemyBouncers.Add(enemy3);
                    enemiesSoFar++;

                    EnemyBouncer enemy4 = new EnemyBouncer();
                    enemy4.x = x - enemiesSoFar * spacing;
                    enemy4.y = y - enemiesSoFar * spacing;
                    Game1.global.ListOfEnemyBouncers.Add(enemy4);
                    cooldown = 30;
                    enemiesSoFar++;
                }
            }
        }
        public override bool shouldDie()
        {
            if(enemiesSoFar > howmanyEnemies)
            return true;
            return false;
            
            
        }
    }
}
