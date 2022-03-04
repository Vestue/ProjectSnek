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
        Pen pen = new Pen(Color.Orange);
        int value;
        Rectangle Square = new Rectangle();
        public orangeFood(int x, int y)
        {
            Square.Width = 50;
            Square.Height = 50;
            Square.X = x;
            Square.Y = y;
            value = 1;

        }


        public void Draw(Graphics g)
        {
            g.DrawRectangle(pen, Square);


        }

        public void TryHit(Snake snake)
        {


        }
        public int returnPoints()
        {

            return value;
        }
    }
}
