using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;                                                     // Used for creating the images of the ants.

namespace AntProject152
{
    class Ant
    {
        public int AntID { get; set; }
        public int AntPositionX { get;  set; }
        public int AntPositionY { get; set; }
        public int AntRange { get; set; }

        public int NestPositionX { get; set; }
        public int NestPositionY { get; set; }

        public int FoodPositionX { get; set; }
        public int FoodPositionY { get; set; }

        public int XBoundary { get; set; }
        public int YBoundary { get; set; }

        public bool hasFood { get; set; }
        public bool knowsNest { get; set; }
        public bool knowsFood { get; set; }
        public bool foodEmpty { get; set; }


        private int direction;
        protected int tickCounter;

        protected Random rand = new Random();


        public Ant()
        {
            direction = rand.Next(0, 7);
            tickCounter = 0;
            hasFood = false;
            knowsNest = false;
            knowsFood = false;
            foodEmpty = false;
            AntID = 0;
            AntPositionX = 0;
            AntPositionY = 0;
            NestPositionX = 0;
            NestPositionY = 0;
            FoodPositionX = 0;
            FoodPositionY = 0;
            AntRange = 20;
        }

        //public Ant(int id, int xBound, int yBound) 
        public Ant(int id, int antPX, int antPY, int xBound, int yBound, Random ra)        // Constructor class.
        {
            direction = rand.Next(0, 7);
            tickCounter = 0;
            rand = ra;
            AntPositionX = antPX;
            AntPositionY = antPY;
            NestPositionX = 0;
            NestPositionY = 0;
            knowsNest = false;
            knowsFood = false;
            AntID = id;
            XBoundary = xBound;
            YBoundary = yBound;
            foodEmpty = false;
            hasFood = false;
        }

        public void RunProgram()
        {

        }

        private void MoveYDirection(int yBound)             // Turns the ant around if it reaches the y boundary of the panel.
        {
            if (AntPositionY >= yBound)
            {
                AntPositionY = 0;
            }
            else if (AntPositionY < 0)
            {
                AntPositionY = yBound;
            }
        }

        private void MoveXDirection(int xBound)            // Turns the ant around if it reaches the x boundary of the panel.
        {
            if (AntPositionX >= xBound)
            {
                AntPositionX = 0;
            }
            else if (AntPositionX < 0)
            {
                AntPositionX = xBound;
            }
        }

        public void MoveInDirection()
        {
            switch(direction)
            {
                case 0:                                 // north
                    AntPositionY++;
                    MoveYDirection(YBoundary);
                    break;

                case 1:                                 // north east
                    AntPositionY ++;
                    AntPositionX ++;

                    MoveYDirection(YBoundary);
                    MoveXDirection(XBoundary);
                    break;

                case 2:                                 // east
                    AntPositionX ++;
                    MoveXDirection(XBoundary);
                    break;

                case 3:                                 // south east
                    AntPositionY --;
                    AntPositionX ++;

                    MoveYDirection(YBoundary);
                    MoveXDirection(XBoundary);
                    break;

                case 4:                                 // south
                    AntPositionY --;
                    MoveYDirection(YBoundary);
                    break;

                case 5:                                 // south west
                    AntPositionY --;
                    AntPositionX--;
                    MoveYDirection(YBoundary);
                    MoveXDirection(XBoundary);
                    break;

                case 6:                                 // west
                    AntPositionX --;
                    MoveXDirection(XBoundary);
                    break;

                case 7:                                 //north west
                    AntPositionY ++;
                    AntPositionX --;

                    MoveYDirection(YBoundary);
                    MoveXDirection(XBoundary);
                    break;
            }
        }

        private void Forgetful()
        {
            if (rand.Next(1, 40) == 1)
                knowsNest = false;
            else if (rand.Next(1, 40) == 2)
                knowsFood = false;
        }

        public void Move()
        {
            tickCounter++;
            //Forgetful();

            if (hasFood)
            {
                if (knowsNest)
                    MoveToNest();
                else
                    MoveRandom();
            }
                                           
            else  // Has no food.
            {
                if (knowsFood && !foodEmpty)
                    MoveToFood();
                else
                    MoveRandom();
            }            
        }

        protected void MoveRandom()
        {
            int delta = 0;

            if (tickCounter % 5 == 0)
            {
                delta = rand.Next(-1, 2);
                direction = (direction + delta) % 8;                    // Wraps around from 7 to 0, so if the next random position is 8, it automatically goes to 0.

                if (direction == -1)
                    direction = 7;
            }            
          
            MoveInDirection();
        }

        protected void MoveToNest()
        {
            if (AntPositionX < NestPositionX)
                AntPositionX++;
            else if (AntPositionX > NestPositionX)
                AntPositionX--;

            if (AntPositionY < NestPositionY)
                AntPositionY++;
            else if (AntPositionY > NestPositionY)
                AntPositionY--;
        }

        private void MoveToFood()
        {
            if (AntPositionX < FoodPositionX)
                AntPositionX++;
            else if (AntPositionX > FoodPositionX)
                AntPositionX--;

            if (AntPositionY < FoodPositionY)
                AntPositionY++;
            else if (AntPositionY > FoodPositionY)
                AntPositionY--;
        }

        public void NearbyAnt(Ant nearbyAnt)
        {
            if (!hasFood)
            {
                if (nearbyAnt.knowsFood)
                {
                    if (!nearbyAnt.foodEmpty)
                    {
                        //If MY food source is empty ask nearby ant if THEIR food source is empty. Then get their details.

                        foodEmpty = nearbyAnt.foodEmpty;                    //If the food source is empty then one ant tells another.
                        FoodPositionX = nearbyAnt.FoodPositionX;            //Later the ant will not move towards the empty food.
                        FoodPositionY = nearbyAnt.FoodPositionY;
                    }
                }
            }

            if (!knowsNest)
            {
                knowsNest = nearbyAnt.knowsNest;
                NestPositionX = nearbyAnt.NestPositionX;
                NestPositionY = nearbyAnt.NestPositionY;
            }
        }

        public void NearbyNest(Nest nearbyNest)
        {
            //Keep original nest location. If that ant already has one.
            if (!knowsNest)
            {
                knowsNest = true;
                NestPositionX = nearbyNest.NestPositionX;
                NestPositionY = nearbyNest.NestPositionY;
            }
        }

        public void NearbyFood(Food nearbyFood)
        {
            //Keep original food location. If that ant already has one.
            if (!knowsFood)
            {
                knowsFood = true;
                FoodPositionX = nearbyFood.FoodPositionX;
                FoodPositionY = nearbyFood.FoodPositionY;
            }
        }

        public void AtFood(Food food)          
        {
            //Get the ant to pickup food. If the food source has some food left....
                      
            if (!hasFood)
            {
                int value = food.TakeFood();
                if (value == 1)
                    hasFood = true;
                else
                {
                    foodEmpty = true;
                }
            }
        }

        public void AtNest(Nest nest)
        {
            //Get the ant to drop off food.
            if (hasFood)
            {
                hasFood = false;
                nest.AddFood();
            }   
        }
    }

}
