using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Snake_DVA222
{
    internal class yellowFood : IFood
    {
        Pen pen = new Pen(Color.Yellow);
        int value;
        Rectangle Square = new Rectangle();
        public yellowFood(int x, int y)
        {
            Square.Width = 50;
            Square.Height = 50;
            Square.X = x;
            Square.Y = y;
            value = -1;

        }


        public void Draw(Graphics g)
        {

            g.DrawRectangle(pen, Square);

        }

        
        public int returnpoints()
        {
            value = 1;

            return value;
        }
    }
}
