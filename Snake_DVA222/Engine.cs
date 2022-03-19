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
        private int snakeStartLength = 5;


        //TODO: Ändra utifrån implementation
        List<Snake> _snakes = new List<Snake>();
        List<IFood> _food = new List<IFood>();

        MainForm _form;
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        Movement _movement = new Movement();

        public void Run()
        {
            _form = new MainForm(this);
            Application.Run(_form);

            Height = _form.Height;
            Width = _form.Width;
        }

        public void Add(Snake snake) => _snakes.Add(snake);
        public void Add(IFood food) => _food.Add(food);
        public void Remove(Snake snake) => _snakes.Remove(snake);
        public void Remove(IFood food) => _food.Remove(food);

        private void Draw(object? sender, PaintEventArgs e)
        {
            var snakes = new List<Snake>(_snakes);
            var foods = new List<IFood>(_food);
            foreach (var snake in snakes)
                snake.Draw(e.Graphics, Width);
            foreach (var food in foods)
                food.Draw(e.Graphics);
        }

        private void TimerEventHandler(object? sender, EventArgs e)
        {
            
            _form.Refresh();
            Collide();
        }

        public void StartGame(int amountOfPlayers)
        {
            _form.KeyDown += KeyEventHandler;
            _form.Paint += Draw;

            _timer.Tick += TimerEventHandler;
            _timer.Interval = 1000 / 30; // 30 fps lets goo
            _timer.Start();

            AmountOfPlayers = amountOfPlayers;

            //TODO: Start spawning food
            for (int i = 0; i < amountOfPlayers; i++)
            {
                var snake = new Snake(snakeStartLength, new Coordinate(i*i*i, i*i*i), i+1, this);
                _snakes.Add(snake);

                _food.Add(new orangeFood(5, 5));
            }
        }

        // This is triggered every time a key is pressed down after the game has been started.
        private void KeyEventHandler(object? sender, KeyEventArgs e)
        {
            var snakes = new List<Snake>(_snakes);
            foreach(var snake in _snakes)
                _movement.Move(e, snake);
        }

        private void Collide()
        {
            var snakes = new List<Snake>(_snakes);
            var foodList = new List<IFood>(_food);
            foreach (var food in foodList)
                foreach (var snake in snakes)
                    food.TryHit(snake);
        }
    }
}
