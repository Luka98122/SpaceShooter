using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class SpawnWaveCenter : SpawnWaveBaseClass
    {
        public int cooldown = 0;
        public int howmanyEnemies = 5;
        public int enemiesSoFar = 0;
        public int enemyChances = 0;

        public override void initialize(int EnemyChances)
        {

        }

        public override void update()
        {
            cooldown--;

            if (cooldown <= 0)
            {
                Enemy enemy = new Enemy();
                enemy.x = Game1.global.windowWidth / 2;
                enemy.y = Game1.global.windowHeight / 2;
                Game1.global.ListOfEnemies.Add(enemy);
                enemiesSoFar++;
                cooldown = 15;
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
