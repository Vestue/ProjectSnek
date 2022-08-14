using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DVA222
{
    // EXTENSION
    // Extension suggestion 1, food that randomizes the controls of a random player for 10 seconds
    internal class FoodControls : Food
    {
        private static System.Timers.Timer? speedTimer;
        Snake? RandomSnake;
        public FoodControls(int x, int y, Engine engine) : base(x, y, engine)
        {
            value = 2;
            points = 5;
            pen.Color = Color.Pink;
        }

        public override void TryHit(Snake snake)
        {
            // The snake that hit the food should still get the points
            snake.Hit(points, value);

            // Place the food outside of the playing area so it "Disappears" without actually removing
            // so we can keep the event handler
            Square.X = -1000;
            Square.Y = -1000;

            var rand = new Random();
            List<Snake> snakeList = Engine.GetSnakes();
            if (snakeList == null) throw new NullReferenceException();
            int index = rand.Next(snakeList.Count);
            RandomSnake = snakeList[index];

            // We just want to randomize what button controls what, not give completely random keys as controls
            // therefore we randomize the order of the list of controls
            List<Keys> snakeControls = RandomSnake.GetKeyList();
            snakeControls = snakeControls.OrderBy(x => rand.Next()).ToList();
            RandomSnake.SetControls(snakeControls);

            speedTimer = new System.Timers.Timer();
            speedTimer.Interval = 10000;
            speedTimer.Elapsed += OnTimedEvent;
            speedTimer.AutoReset = false;
            speedTimer.Enabled = true;
        }

        // Removes self and removes the speed up from the snake
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            RandomSnake.InitializeKeys();
            Engine.Remove(this);
        }
    }
}
