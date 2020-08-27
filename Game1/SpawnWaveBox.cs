using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public abstract class SpawnWaveBox : SpawnWaveBaseClass
    {
        public override void initialize()
        {
        }

        public override bool shouldDie()
        {
            return false;
        }
        public override void update()
        {
        }
    }
}
