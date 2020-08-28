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
        public int cooldown = 10;
        int numberHit; 
        int positiveSpace;
        int WhichSpawnWave = 1;
        public int chanceCooldown = 10;


        public void initalize ()
        {
            numberHit = Game1.global.rand.Next(0, 100);
            positiveSpace = 50 - Game1.global.ListOfEnemies.Count * 4;
        }
        public void update()
        {
            autoSpawn();

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

        public void autoSpawn ()
        {
            //Time wave
            cooldown--;
            if(cooldown <= 0)
            {
                cooldown = 300;
                SpawnWaveBaseClass spawn;
                int WhichSpawnWave = Game1.global.rand.Next(1, 4);
                if (WhichSpawnWave == 1)
                {
                    spawn = new SpawnWaveCorner();
                }
                else
                {
                    if (WhichSpawnWave == 2)
                    {
                        spawn = new SpawnWaveCenter();
                    }
                    else
                    {
                        spawn = new SpawnWaveEdges();
                    }
                }
                listOfSpawnWaves.Add(spawn);
            }
            //chance wave
            chanceCooldown--;
            if (chanceCooldown <= 0)
            {
                numberHit = Game1.global.rand.Next(0, 100);
                positiveSpace = 50 - Game1.global.ListOfEnemies.Count * 10;
                if(numberHit <= positiveSpace)
                {
                    randomSpawnWave();
                }
            }
            
        }
        public void randomSpawnWave()
        {
            
            WhichSpawnWave = Game1.global.rand.Next(3);
            SpawnWaveBaseClass spawn1;
            if (WhichSpawnWave == 0)
            {
                spawn1 = new SpawnWaveCorner();
            }
            else
            {
                if (WhichSpawnWave == 1)
                {
                    spawn1 = new SpawnWaveCenter();
                }
                else
                {
                    spawn1 = new SpawnWaveEdges();
                }
            }
            Game1.global.spawnManager.listOfSpawnWaves.Add(spawn1);
        }
    }
}
