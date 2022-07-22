using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntProject152
{
    class NastyAnt : Ant
    {
        private bool knowsAnt;
        private int targetAntX;
        private int targetAntY;


        public NastyAnt()
        {
            knowsAnt = false;
        }

        public NastyAnt(int id, int antPX, int antPY, int xBound, int yBound, Random ra)        // Constructor class.
        {
            this.AntID = id;
            this.AntPositionX = antPX;
            this.AntPositionY = antPY;
            this.XBoundary = xBound;
            this.YBoundary = yBound;
            this.rand = ra;

            knowsAnt = false;
            targetAntX = 0;
            targetAntY = 0;
        }

        public void Move()
        {
            tickCounter++;

            if (hasFood)
            {
                if (knowsNest)
                    MoveToNest();
                else
                    MoveRandom();
            }

            else  // Has no food.
            {
                if (knowsAnt)
                    MoveToAnt();
                else
                    MoveRandom();
            }
        }

        private void MoveToAnt()
        {
            if (AntPositionX < targetAntX)
                AntPositionX++;
            else if (AntPositionX > targetAntX)
                AntPositionX--;

            if (AntPositionY < targetAntY)
                AntPositionY++;
            else if (AntPositionY > targetAntY)
                AntPositionY--;
        }
    }
}
