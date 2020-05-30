using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public abstract class GameEntity
    {
        public enum State
        {
            Dead,
            Alive
        };
        public float x=0;
        public float y=0;
        public float width=50;
        public float height=50;
        public State state=State.Alive;

        public abstract void initialize();
        public abstract void update();
        public abstract void draw();
        public GameEntity()
        {
            initialize();
        }

    }
}
