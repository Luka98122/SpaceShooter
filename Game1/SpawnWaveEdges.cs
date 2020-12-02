using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class SpawnWaveEdges : SpawnWaveBaseClass
    {
        public int cooldown = 0;
        public int howmanyEnemies = 20;
        public int enemiesSoFar = 0;
        public int spacing = 5;
        public int enemyChances = 0;

        public override void initialize(int EnemyChances)
        {
            enemyChances = EnemyChances;
        }

        public override void update()
        {
            cooldown--;
            if(cooldown<= 0)
            {
                cooldown = 5;
                enemiesSoFar++;
                
                Enemy enemy = new Enemy();
                if (enemiesSoFar == 1)
                {
                    enemy.x = enemy.width;
                    enemy.y = enemy.height;
                }
                enemy.x = enemy.width;
                enemy.y = enemy.height+40+enemy.height * enemiesSoFar;
                enemy.speed = 2.1f;
                Game1.global.ListOfEnemies.Add(enemy);

                Enemy enemy1 = new Enemy();
                enemy1.x = Game1.global.windowWidth;
                enemy1.y = enemy.height + 5+enemy.height * enemiesSoFar;
                enemy1.speed = 2.1f;
                Game1.global.ListOfEnemies.Add(enemy1);

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
