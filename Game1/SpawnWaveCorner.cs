using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class SpawnWaveCorner  : SpawnWaveBaseClass
    {
        public int cooldown = 0;
        public int howmanyEnemies = 5;
        public int enemiesSoFar = 0;
        public int enemyChances = 0;

        public override void initialize(int EnemyChances)
        {
            enemyChances = EnemyChances;
        }

        public override void update()
        {
            cooldown--;
            if(cooldown <= 0)
            {
                cooldown = 15;

                Enemy enemy = new Enemy();
                enemy.x = enemy.width;
                enemy.y = enemy.height;
                Game1.global.ListOfEnemies.Add(enemy);
                
                Enemy enemy1 = new Enemy();
                enemy1.x = Game1.global.windowWidth;
                enemy1.y = enemy.height;
                Game1.global.ListOfEnemies.Add(enemy1);

                Enemy enemy2 = new Enemy();
                enemy2.x = enemy.width;
                enemy2.y = Game1.global.windowHeight;
                Game1.global.ListOfEnemies.Add(enemy2);

                Enemy enemy3 = new Enemy();
                enemy3.x = Game1.global.windowWidth;
                enemy3.y = Game1.global.windowHeight;
                Game1.global.ListOfEnemies.Add(enemy3);
                
                enemiesSoFar++;
            }
        }

        public override bool shouldDie()
        {
            if(enemiesSoFar>=howmanyEnemies)
            {
                return true;
            }
            return false;
        }
    }
}
