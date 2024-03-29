﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SnakeGame
{
    internal class SnakePart : Sprite
    {
        public SnakePart(Texture2D texture, Vector2 position, Direction direction, Rectangle screen) : base(texture, position, direction, screen)
        {

        }

        public override void Update(GameTime gameTime)
        {
            switch (direction)
            {
                case Direction.Up:
                    position.Y += -Game1.snakePartSize;
                    break;
                case Direction.Down:
                    position.Y += Game1.snakePartSize;
                    break;
                case Direction.Left:
                    position.X += -Game1.snakePartSize;
                    break;
                case Direction.Right:
                    position.X += Game1.snakePartSize;
                    break;
              
            }

            Teleportation();


            base.Update(gameTime);
        }
        
        public void InputKeyBoard()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Up))
                if(direction != Direction.Down)
                    direction = Direction.Up;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                if (direction != Direction.Up)
                    direction = Direction.Down;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                if (direction != Direction.Right)
                    direction = Direction.Left;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                if (direction != Direction.Left)
                    direction = Direction.Right;
        }

        private void Teleportation()
        {
            if(position.X < 0)
                position.X = screen.Width - texture.Width;
            if (position.X > screen.Width - texture.Width)
                position.X = 0;
            if (position.Y < 0)
                position.Y = screen.Height - texture.Height;
            if (position.Y > screen.Height - texture.Height)
                position.Y = 0;
        }

    }
}
