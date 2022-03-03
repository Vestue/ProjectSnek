using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_DVA222
{
    internal class Engine
    {
        public int AmountOfPlayers { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        //TODO: Ändra utifrån implementation
        List<Snake> _snakes = new List<Snake>;
        List<Food> _food = new List<Food>;

        MainForm _form = new MainForm();
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        Movement _movement = new Movement();

        public void Run()
        {
            //TODO: Avkommentera efter implementation
            //_form.Paint += Draw;

            _timer.Tick += TimerEventHandler;
            _timer.Interval = 1000 / 30; // 30 fps lets goo
            _timer.Start();
            Application.Run(_form);

            Height = _form.Height;
            Width = _form.Width;
        }

        private void Draw(object? sender, PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TimerEventHandler(object? sender, EventArgs e)
        {
            
            _form.Refresh();
        }

        public void StartGame(int amountOfPlayers)
        {
            AmountOfPlayers = amountOfPlayers;

            //TODO: Clear form, spawn snakes and start spawning food
        }

        private void Move()
        {
            var snakes = new List<Snake>(_snakes);
            // Assumes snake has a snakeID which can be set in the constructor

            //UNDONE: Hur hantera flera inputs samtidigt?
            var key = Console.ReadKey(true).Key;
            foreach (var snake in _snakes)
                _movement.Move(key, snake);
        }

        private void Collide()
        {
            var snakes = new List<Snake>(_snakes);
            var foodList = new List<Food>(_food);
            foreach (var food in foodList)
                foreach (var snake in snakes)
                    food.TryHit(snake);
        }
    }
}
