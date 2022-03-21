using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Snake_DVA222
{
    internal class Food
    {

        SolidBrush pen = new SolidBrush(Color.White);
        Pen outline = new Pen(Color.Black);
        int value;
        int points;
        Random random = new Random();
        int color;
        
        Rectangle Square = new Rectangle();
        Engine Engine;
       public Food(int x, int y, Engine engine)
        {
            Engine = engine;
            Square.Width = Engine.GameObjectSize;
            Square.Height = Engine.GameObjectSize;
            Square.X = x;
            Square.Y = y;
            color = random.Next(0, 3);
            switch (color)
            {
                case 0:
                    value = 1;
                    points = 1;
                    pen.Color = Color.Orange;
                    break;
                case 1:
                    value = 2;
                    points = 5;
                    pen.Color = Color.Red;
                    break;

                case 2:
                    value = -1;
                    points = 1;
                    pen.Color= Color.Yellow;
                    
                    break;
            }

            
            

        }


        public void Draw(Graphics g)
        {
                 
            g.FillRectangle(pen, Square);        

           
            

        }

        public bool intersect(Snake snake)
        {

            var BodyCord = snake.GetBodyCords();
            var SnakeHeadPos = BodyCord[0];


            float ClosestX = Math.Clamp(SnakeHeadPos.X - Square.Width / 2, Square.Left, Square.Right);
            float ClosestY = Math.Clamp(SnakeHeadPos.Y - Square.Height / 2, Square.Top, Square.Bottom);

            float DistanceX = (SnakeHeadPos.X - Square.Width / 2) - ClosestX;
            float DistanceY = (SnakeHeadPos.Y - Square.Height / 2) - ClosestY;
            float DistanceSqrd = (DistanceX * DistanceX) + (DistanceY * DistanceY);


            if (DistanceSqrd <= (Square.Width * Square.Height))
            {
                return true;
            }

            return false;
        }

        public int returnPoints()
        {

            return value;
        }

        public void TryHit(Snake snake)
        {
            snake.Hit(points, value);
            Engine.Remove(this);


        }
    }
}
