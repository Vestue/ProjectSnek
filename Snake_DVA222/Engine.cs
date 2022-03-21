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
        public int GameObjectSize { get; private set; }

        List<Snake> _snakes = new List<Snake>();
        List<IFood> _food = new List<IFood>();

        MainForm _form;
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        Movement _movement = new Movement();

        public Engine()
        {

            _form = new MainForm(this);

        }

        public void Run()
        {
            _form.KeyDown += KeyEventHandler;
            _form.Paint += Draw;
            _form.Resize += OnResize;
            SetGameSizes();

            _timer.Tick += TimerEventHandler;
            _timer.Interval = 1000 / 30; // 30 fps lets goo

            Application.Run(_form);
        }

        private void SetGameSizes()
        {
            Height = _form.Height;
            Width = _form.Width;
            GameObjectSize = Width / 80;
        }

        private void OnResize(object? sender, EventArgs e) => SetGameSizes();

        public void Add(Snake snake) => _snakes.Add(snake);
        public void Add(IFood food) => _food.Add(food);
        public void Remove(Snake snake) => _snakes.Remove(snake);
        public void Remove(IFood food) => _food.Remove(food);

        private void Draw(object? sender, PaintEventArgs e)
        {
            var snakes = new List<Snake>(_snakes);
            var foods = new List<IFood>(_food);

            foreach (var snake in snakes)
                snake.Draw(e.Graphics);
            foreach (var food in foods)
                food.Draw(e.Graphics);
        }

        private void TimerEventHandler(object? sender, EventArgs e)
        {
            _form.Refresh();
            Collide();
            Move();
            TrySpawnFood();
            if (_snakes.Count < 1) GameOver();
        }

        public void StartGame(int amountOfPlayers)
        {
            _timer.Start();

            AmountOfPlayers = amountOfPlayers;
            Coordinate snakeCoordinate;
            for (int i = 0; i < amountOfPlayers; i++)
            {
                if (i % 2 == 0)
                {
                    // -10 is needed so that each "set" of snakes spawn with the same offset from the center.
                    snakeCoordinate = new Coordinate(Width / 2 - 10 - i * 10, Height / 2);
                }
                else
                {
                    snakeCoordinate = new Coordinate(Width / 2 + i * 10, Height / 2);
                }
                Add(new Snake(snakeStartLength, snakeCoordinate, i + 1, this));
            }
            Add(new orangeFood(Width / 2, Height / 2, this));
        }

        // This is triggered every time a key is pressed down after the game has been started.
        private void KeyEventHandler(object? sender, KeyEventArgs e)
        {
            foreach (var snake in _snakes)
                _movement.Move(e, snake);
        }

        private void Collide()
        {
            // Try doing this without the temp lists if collisions do not trigger things as they should.
            var snakes = new List<Snake>(_snakes);
            var foodList = new List<IFood>(_food);

            foreach (var food in foodList)
                foreach (var snake in snakes)
                    if(food.intersect(snake))
                    food.TryHit(snake);
            foreach (var snake in snakes)
                foreach (var otherSnake in snakes)
                    snake.SnakeCollide(otherSnake);
        }

        private void Move()
        {
            var snakes = new List<Snake>(_snakes);
            foreach (var snake in snakes) snake.Move(Width, Height);
        }

        private void TrySpawnFood()
        {
            // This can be changed depending on how much food should be spawned.
            // Could be a setting depending on player amount etc.
            if (_food.Count >= 1) return;

            var snakes = new List<Snake>(_snakes);
            List<Coordinate> snakeCoords = new List<Coordinate>();
            foreach (var snake in snakes) snakeCoords.AddRange(snake.GetBodyCords());

            Coordinate foodCoordinate;
            Random rand = new Random();
            do
            {
                // This randomization should use the min and max x-y values of the game area,
                // not sure if it currently does this.
                foodCoordinate = new Coordinate(rand.Next(0, Width - GameObjectSize), rand.Next(0, Height - GameObjectSize));
            } while (snakeCoords.Contains(foodCoordinate));

            // Should a food randomize its own type in the constructor?
            var foodType = rand.Next(0, 3);
            // This would be prettier using an enum
            if (foodType == 0) Add(new yellowFood(foodCoordinate.X, foodCoordinate.Y, this));
            else if (foodType == 1) Add(new orangeFood(foodCoordinate.X, foodCoordinate.Y, this));
            else Add(new redFood(foodCoordinate.X, foodCoordinate.Y, this));
        }

        private void GameOver()
        {
            _snakes.Clear();
            _food.Clear();
            _timer.Stop();
            _form.RestartMenu();
        }
    }
}