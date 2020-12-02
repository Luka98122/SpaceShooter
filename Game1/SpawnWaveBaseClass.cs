using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public abstract class SpawnWaveBaseClass
    {
        public abstract void initialize(int EnemyChances);
        public abstract void update();
        public abstract bool shouldDie();
    }
}
