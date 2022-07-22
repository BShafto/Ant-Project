using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntProject152
{
    class Nest
    {
        public int NestPositionX {get; set; }
        public int NestPositionY {get; set;}
        public int NestRange { get; set; }
        public int NestID { get; set; }
        public int NestSize { get; set; }

        public Nest()
        {
            NestID = 0;
            NestPositionX = 0;
            NestPositionY = 0;
            NestRange = 0;
            NestSize = 0;
        }

        public Nest(int id, int NestPosX, int NestPosY, int range, int Size)                  //Constructor.
        {
            NestID = id;
            NestPositionX = NestPosX;
            NestPositionY = NestPosY;
            NestRange = range;
            NestSize = Size;
        }

        public void AddFood()
        {
            NestSize++;
        }


    }
}
