using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class SpawnWaveCorner 
    {
        public int corner;
        public void initalize ( int Corner) {
            corner = Corner;
        
        }
        public void update()
        {
            for (int i = 0; i < 5; i++) {
                Enemy myEnemy = new Enemy ();
                if(corner == 1) // Top left
                {
                    myEnemy.x = myEnemy.width;
                    myEnemy.y = myEnemy.height;
                }
                if (corner == 2)
                {
                    myEnemy.x = Game1.global.windowWidth;
                    myEnemy.y = myEnemy.height;
                }
                if (corner == 3)
                {
                    myEnemy.x = Game1.global.windowWidth;
                    myEnemy.y = Game1.global.windowHeight;
                }
                if (corner == 4)
                {
                    myEnemy.x = myEnemy.width;
                    myEnemy.y = Game1.global.windowHeight;
                }
            }
        }
    }
}
