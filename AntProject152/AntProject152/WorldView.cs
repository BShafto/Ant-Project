using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace AntProject152
{
    public partial class WorldView : Form
    {
        //declare the List<T> antList object.
        private int tickCounter = 0;
        private Random randomPosition;

        private List<Ant> antList;
        private List<Nest> nestList;
        private List<Food> foodList;
        private Bitmap worldImage;
        private Point mouseDownPoint;
        private int countNests = 1;
        private int countFoodSources = 1;
        int nestRange = 30;
        int foodRange = 30;
        int nestSize = 20;
        int foodSize = 20;
        int xBoundary;
        int yBoundary;

        public WorldView()
        {
            InitializeComponent();
            randomPosition = new Random();
            worldImage = new Bitmap(antWorld.Width, antWorld.Height);          //Create the Bitmap with the world width and height.
            antList = new List<Ant>();                              //Make a new list of ants made up of the constructor type ant 
            nestList = new List<Nest>();
            foodList = new List<Food>();
            simpleTimer.Start();
        }

        public void MakeAnts(Random r)
        {
            Ant tempAnt;

            int noAnts = 0;
            randomPosition = r;

            try
            {
                noAnts = Convert.ToInt32(txtNoAnts.Text);
            }
            catch(FormatException)
            {
                MessageBox.Show("A value, you  must enter.");
                noAnts = 1;
            }

            int nastyAntIndex = noAnts / 2;

            for (int id = 1; id <= noAnts; id++)
            {
                if (id < nastyAntIndex)
                {
                    int antPX = randomPosition.Next(0, xBoundary);
                    int antPY = randomPosition.Next(0, yBoundary);

                    tempAnt = new Ant(id, antPX, antPY, xBoundary, yBoundary, randomPosition);
                    antList.Add(tempAnt);
                }
                else
                {
                    int antPX = randomPosition.Next(0, xBoundary);
                    int antPY = randomPosition.Next(0, yBoundary);

                    tempAnt = new NastyAnt(id, antPX, antPY, xBoundary, yBoundary, randomPosition);
                    antList.Add(tempAnt);
                }
            }


        }

        private void MakeNest(int id)
        {
            Nest tempNest;

            lbNoNests.Text = countNests.ToString();

            int randNestPosX = mouseDownPoint.X;
            int randNestPosY = mouseDownPoint.Y;
            tempNest = new Nest(id, randNestPosX, randNestPosY, 50, nestSize);
            nestList.Add(tempNest);
        }

        private void MakeFood(int id)
        {
            Food tempFood;


            lbNoFood.Text = countFoodSources.ToString();

            int randPosX = mouseDownPoint.X;
            int randPosY = mouseDownPoint.Y;
            tempFood = new Food(id, randPosX, randPosY, foodSize);
            foodList.Add(tempFood);
        }

        public void SetBoundary()                                               //Sets the dimentions the ants can travel in.
        {
            xBoundary = antWorld.Width;
            yBoundary = antWorld.Height;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SetBoundary();
            MakeAnts(randomPosition);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void DrawAntsNestsFoodSources()
        {
            //Get the graphics context of the worldImage. As it's the image on which all the drawing will be taking place.
            using (Graphics worldImageGraphics = Graphics.FromImage(worldImage))
            {                    
                using (Graphics panelGraphics = antWorld.CreateGraphics())
                {
                    //The order in which we draw is the layers, so in this order the ants are drawn after the nest and the food source.
                    //Use the .Clear method to clear the panel of all the drawing after every tick so the ants don
                    worldImageGraphics.Clear(Color.Gray);

                    using (Brush nBrush = new SolidBrush(Color.Cyan))
                    using (Brush fBrush = new SolidBrush(Color.Green))
                    using (Brush aBrush = new SolidBrush(Color.Black))                     //Boring ant.
                    using (Brush pBrush = new SolidBrush(Color.Pink))                      //Has food but doesn't know nest.
                    using (Brush yBrush = new SolidBrush(Color.Yellow))                    //Has no food but knows nest.
                    using (Brush bBrush = new SolidBrush(Color.Blue))                      //Has food and knows nest.
                    using (Brush rBrush = new SolidBrush(Color.Red))
                    {
                        foreach (Nest n in nestList)
                        {
                            int s = n.NestSize / 2;
                            worldImageGraphics.FillEllipse(nBrush, n.NestPositionX - s, n.NestPositionY - s, n.NestSize, n.NestSize);
                        }

                        foreach (Food f in foodList)
                        {
                            int s = f.FoodSize / 2;
                            worldImageGraphics.FillRectangle(fBrush, (f.FoodPositionX - s), (f.FoodPositionY - s), f.FoodSize, f.FoodSize);
                        }

                        foreach (Ant a in antList)
                        {
                            if (a.GetType() == typeof(Ant))
                            {
                                if (a.hasFood)
                                {
                                    if (a.knowsNest)
                                        worldImageGraphics.FillRectangle(bBrush, a.AntPositionX, a.AntPositionY, 4, 4);              //(x, y, width, height).
                                    //Blue
                                    else
                                        worldImageGraphics.FillRectangle(pBrush, a.AntPositionX, a.AntPositionY, 4, 4);              //(x, y, width, height).
                                    //Pink
                                }
                                else if (a.knowsFood && a.knowsNest)
                                    worldImageGraphics.FillRectangle(nBrush, a.AntPositionX, a.AntPositionY, 4, 4);              //(x, y, width, height)
                                //Brown
                                else if (a.knowsFood && !a.foodEmpty)
                                    worldImageGraphics.FillRectangle(fBrush, a.AntPositionX, a.AntPositionY, 4, 4);              //(x, y, width, height).
                                //Green
                                else if (a.knowsNest)
                                    worldImageGraphics.FillRectangle(yBrush, a.AntPositionX, a.AntPositionY, 4, 4);              //(x, y, width, height).
                                //Yellow

                                else
                                worldImageGraphics.FillRectangle(aBrush, a.AntPositionX, a.AntPositionY, 4, 4);              //(x, y, width, height).
                                //Black
                            }

                            else if (a.GetType() == typeof(NastyAnt))
                            {
                                worldImageGraphics.FillRectangle(rBrush, a.AntPositionX, a.AntPositionY, 4, 4);              //(x, y, width, height).
                            }
                        }
                    }
                // Having finished drawing on the image, now draw the whole image onto the panel.
                panelGraphics.DrawImage(worldImage, 0, 0, antWorld.Width, antWorld.Height);
               }
            }
        }

        private void MoveAnts()
        {
            int countdown = 0;
            countdown = tickCounter % 10;



            foreach (Ant a in antList)
            {
                a.Move();

                Ant nearbyAnt = GetNearbyAnt(a);
                if (nearbyAnt.AntID != 0)
                {
                    //An ant has bumped into another ant, swap information.
                    a.NearbyAnt(nearbyAnt);                         //Tell ant a that it has a nearby ant.
                }

                Food nearbyFood = GetNearbyFoodLocation(a);
                if (nearbyFood.FoodID != 0)                                         
                {
                    //An ant is near a food source --> Let them know!
                    a.NearbyFood(nearbyFood);                         
                }

                Food atFood = PickUpFood(a);
                if (atFood.FoodID != 0)
                {
                    //An ant is at a food source! Tell him to pick up some food!
                    a.AtFood(atFood);
                }

                Nest nearbyNest = GetNearbyNestLocation(a);
                if (nearbyNest.NestID != 0)
                {
                    //An ant is near a nest --> Let them know!
                    a.NearbyNest(nearbyNest);
                }

                Nest nest = DropOffFood(a);
                if (nest.NestID != 0)
                {
                    //An ant is at a nest! Tell them do drop off some food!
                    a.AtNest(nest);
                }
            }
        }
        private Ant GetNearbyAnt(Ant myAnt)                       //Passes the first ant in from antList.
        {

            foreach (Ant a in antList)
            {   
                if (a.AntID != myAnt.AntID)                         //Compares the first ant with the current ant.
                {
                    if (Nearby(a, myAnt))                           //Compares the next and with the current ant.
                    {
                        return a;
                    }
                }
            }
            return new Ant();
        }

        private Nest GetNearbyNestLocation(Ant myAnt)                       //Passes in an ant.
        {
            foreach (Nest n in nestList)
            {

                if ((Math.Abs(myAnt.AntPositionX - n.NestPositionX) < nestRange) && (Math.Abs(myAnt.AntPositionY - n.NestPositionY) < nestRange))
                    return n;
            }
            return new Nest();
        }

        private Food GetNearbyFoodLocation(Ant myAnt)                       //Passes in an ant.
        {
            foreach (Food f in foodList)
            {

                if ((Math.Abs(myAnt.AntPositionX - f.FoodPositionX) < foodRange) && (Math.Abs(myAnt.AntPositionY - f.FoodPositionY) < foodRange))
                    return f;
            }
            return new Food();
        }

        private Food PickUpFood(Ant myAnt)                          //Passes in an ant and compares it with all the food sources.
        {
            foreach (Food f in foodList)
            {

                if ((myAnt.AntPositionX == f.FoodPositionX) && (myAnt.AntPositionY == f.FoodPositionY))
                    return f;
            }
            return new Food();
        }

        private Nest DropOffFood(Ant myAnt)                         //Passes in an ant and compares it with all the nests.
        {
            foreach (Nest n in nestList)
            {
                if ((myAnt.AntPositionX == n.NestPositionX) && (myAnt.AntPositionY == n.NestPositionY))
                    return n;
            }
            return new Nest();
        }

        private bool Nearby(Ant ant1, Ant ant2)
        {
            return ((Math.Abs(ant1.AntPositionX - ant2.AntPositionX) < 4) && (Math.Abs(ant1.AntPositionY - ant2.AntPositionY) < 4));
            //Returns true --> if the x AND y co-ordinates are within 4 bits of eachother.
        }










        private void TimerTick(object sender, EventArgs e)
        {
            tickCounter++;
            timerLabel.Text = tickCounter.ToString();
            MoveAnts();                                                                //Put me in the ant class. 
            DrawAntsNestsFoodSources();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int trackBarValue;
            //Get the value of the TrackBar.
            trackBarValue = timerTrackBar.Value;

            //Update a level.
            sliderLabel.Text = trackBarValue.ToString();

            //Change the timer interval using the value from the trackbar.
            simpleTimer.Interval = trackBarValue;
            //The Timer class has a property named 'Interval' in miliseconds,
            //which sets the interval between 'tick events'.
        }

        private void antWorld_MouseDown(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("number of nests is" + countNests);
            //Remember where the mouse was clicked.
            mouseDownPoint = e.Location;

            if (e.Button == MouseButtons.Left)
            {
                MakeFood(countFoodSources);
                countFoodSources++;
            }
            
            else if (e.Button == MouseButtons.Right)
            {
                MakeNest(countNests);
                countNests++;
            }
        }

        private void AntForm_Load(object sender, EventArgs e)
        {

        }
    }
}
