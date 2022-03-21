﻿using System;
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
        List<Food> _food = new List<Food>();

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
            Height = _form.Height - _form.Height / 16;
            Width = _form.Width - _form.Width / 36;
            GameObjectSize = Width / 80;
        }

        private void OnResize(object? sender, EventArgs e) => SetGameSizes();

        public void Add(Snake snake) => _snakes.Add(snake);
        public void Add(Food food) => _food.Add(food);
        public void Remove(Snake snake) => _snakes.Remove(snake);
        public void Remove(Food food) => _food.Remove(food);

        private void Draw(object? sender, PaintEventArgs e)
        {
            var snakes = new List<Snake>(_snakes);
            var foods = new List<Food>(_food);

            foreach (var snake in snakes)
                snake.Draw(e.Graphics);
            foreach (var food in foods)
                food.Draw(e.Graphics);
        }

        private void TimerEventHandler(object? sender, EventArgs e)
        {
            _form.ScoreDisplay.Text = GetScoreString();
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
                    // "10 * GameObjectSize" is how far away it should be from the center.
                    // i * 4 * GameObjectSize is far away it should be from snakes spawning on the same side.
                    snakeCoordinate = new Coordinate(Width / 2 - 10 * GameObjectSize - i * 4 * GameObjectSize, Height / 2);
                }
                else
                {
                    snakeCoordinate = new Coordinate(Width / 2 + 9 * GameObjectSize + i * 4 * GameObjectSize, Height / 2);
                }
                Add(new Snake(snakeStartLength, snakeCoordinate, i + 1, this));
            }
            Add(new Food(Width / 2, Height / 2, this));
        }

        // This is triggered every time a key is pressed down after the game has been started.
        private void KeyEventHandler(object? sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            foreach (var snake in _snakes)
                _movement.Move(e, snake);
        }

        private void Collide()
        {
            // Try doing this without the temp lists if collisions do not trigger things as they should.
            var snakes = new List<Snake>(_snakes);
            var foodList = new List<Food>(_food);

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

          
            Add(new Food(foodCoordinate.X, foodCoordinate.Y, this));
        }

        private void GameOver()
        {
            _snakes.Clear();
            _food.Clear();
            _timer.Stop();
            _form.RestartMenu();
        }

        public string GetScoreString()
        {
            var snakes = new List<Snake>(_snakes);
            string scoreString = "Score:\r\n";
            foreach (var snake in snakes)
                scoreString += $"\r\nPlayer {snake.ID}: {snake.GetPoints}";
            return scoreString;
        }
    }
}