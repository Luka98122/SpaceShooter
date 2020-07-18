using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class SpawnManager
    {
        public List<CompleteCornerWave> listOfCornerWaves = new List<CompleteCornerWave> ();

        public void addCornerWave() {
            CompleteCornerWave cornerWave = new CompleteCornerWave();
            listOfCornerWaves.Add(cornerWave);
        }
        public void initalize ()
        {
            for(int i = 0;i<listOfCornerWaves.Count;i++)
            {
                listOfCornerWaves[i].initalize();
            }
        }
        public void update ()
        {
            for(int i = 0;i<listOfCornerWaves.Count;i++)
            {
                listOfCornerWaves[i].update();
            }
        }
    }
}
