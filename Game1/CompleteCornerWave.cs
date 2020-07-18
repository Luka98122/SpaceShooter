using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    
    public class CompleteCornerWave
    {
        public List<SpawnWaveCorner> corners = new List<SpawnWaveCorner>();
        public void initalize ()
        {
            for (int i = 1; i < 5; i++)
            {
                SpawnWaveCorner cornerWave = new SpawnWaveCorner();
                cornerWave.initalize(i);
                corners.Add(cornerWave);
            }
        }
        public void update ()
        {
            for(int i = 0;i<corners.Count;i++)
            {
                corners[i].update();
            }
        }
    }
}
