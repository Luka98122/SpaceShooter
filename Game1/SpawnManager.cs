using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game1
{
    public class SpawnManager
    {
        public List<SpawnWaveBaseClass> listOfSpawnWaves = new List<SpawnWaveBaseClass>();

        public void addCornerWave() {
            
        }
        public void initalize ()
        {
        }
        public void update()
        {
            for (int i = 0; i < listOfSpawnWaves.Count; i++)
            {
                listOfSpawnWaves[i].update();
            }

            for (int i = 0; i < listOfSpawnWaves.Count; i++)
            {
                
                if(listOfSpawnWaves[i].shouldDie() == true)
                {
                    listOfSpawnWaves.RemoveAt(i);
                }
            }
        }
    }
}
