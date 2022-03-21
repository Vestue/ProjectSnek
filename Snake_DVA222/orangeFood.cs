using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Snake_DVA222
{
    internal class orangeFood : IFood
    {
        SolidBrush pen = new SolidBrush(Color.Orange);
        Pen outline = new Pen(Color.Black);
        int value;
        int points;
        Rectangle Square = new Rectangle();

        Engine Engine;
        public orangeFood(int x, int y, Engine engine)
        {
            Engine = engine;
            Square.Width = engine.GameObjectSize;
            Square.Height = engine.GameObjectSize;
            Square.X = x;
            Square.Y = y;
            value = 1;
            points = 1;
            

        }


        public void Draw(Graphics g)
        {
            g.FillRectangle(pen, Square);
            

        }

        public void TryHit(Snake snake)
        {

            snake.Hit(points, value);
            //Engine.Remove(this);
        }
        public int returnPoints()
        {

            return value;
          
        }


       //Not totally accurate, if snake is slightly under food it will eat it
        public bool intersect(Snake snake)
        {
            var BodyCord = snake.GetBodyCords();
            var SnakeHeadPos = BodyCord[0];

            bool withinXRange = false;
            bool withinYRange = false;
           
            if (SnakeHeadPos.X - Engine.GameObjectSize <= Square.X && Square.X <= SnakeHeadPos.X + Engine.GameObjectSize)
                withinXRange = true;
            if (SnakeHeadPos.Y - Engine.GameObjectSize <= Square.Y && Square.Y <= SnakeHeadPos.Y + Engine.GameObjectSize)
                withinYRange = true;
          
               if(withinXRange && withinYRange)
            {
                return true;
            }

            return false;
        }
    }
}
