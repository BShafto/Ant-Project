using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntProject152
{
    class Food
    {
        public int FoodPositionX { get; set; }
        public int FoodPositionY { get; set; }
        public int FoodRange { get; set; }
        public int FoodID { get; set; }
        public int FoodSize { get; set; }

        public Food()
        {
            FoodID = 0;
            FoodPositionX = 0;
            FoodPositionY = 0;
            FoodSize = 0;
        }

        public Food(int id, int FoodPosX, int FoodPosY, int Size)
        {
            FoodID = id;
            FoodPositionX = FoodPosX;
            FoodPositionY = FoodPosY;
            FoodSize = Size;
        }

        public int TakeFood()
        {
            if (FoodSize > 0)
            {
                FoodSize--;
                return 1;
            }
            else
                return 0;
        }
    }
}
