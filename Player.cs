using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameWindowsStarter
{
    enum State
    {
        South = 2,
        North = 1,
        Idle = 0,
    }

    public class Player
    {
   
        const int ANIMATION_FRAME_RATE = 124;


        const int FRAME_WIDTH = 64;

        const int FRAME_HEIGHT = 64;

        const float PLAYER_SPEED = 150;


        Game1 game;
        Texture2D player_sprite;
        State state;
        TimeSpan timer;
        int frame;
        public Vector2 playerPosition;
        public Rectangle playerRec;

        public Player(Game1 game)
        {
            this.game = game;
            timer = new TimeSpan(0);
            playerPosition = new Vector2(0, 0);
            state = State.Idle;
            playerRec = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, 40, 64);
        }


        public void LoadContent()
        {
            player_sprite = game.Content.Load<Texture2D>("player_sheet_big");
        }


        public void Update(GameTime gameTime, GraphicsDeviceManager graphics)
        {
            KeyboardState keyboard = Keyboard.GetState();
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Update the player state based on input
            if (keyboard.IsKeyDown(Keys.Up))
            {
                state = State.North;
                // playerPosition.Y = playerPosition.Y - 5;
                playerPosition.Y -= delta * PLAYER_SPEED;
                playerRec.Y = (int)playerPosition.Y;
            }
            else if (keyboard.IsKeyDown(Keys.Down))
            {
                state = State.South;
                //playerPosition.Y = playerPosition.Y + 5;
                playerPosition.Y += delta * PLAYER_SPEED;
                playerRec.Y = (int)playerPosition.Y;
            }
            else state = State.Idle;

            //stops player from going off screen
            if (playerPosition.Y < 0)
            {
                playerPosition.Y = 0;
            }
            if (playerPosition.Y > graphics.PreferredBackBufferHeight - 100)
            {
                playerPosition.Y = graphics.PreferredBackBufferHeight - 100;
            }
            if (playerPosition.X < 0)
            {
                playerPosition.X = 0;
            }
            if (playerPosition.X > graphics.PreferredBackBufferWidth - 100)
            {
                playerPosition.X = graphics.PreferredBackBufferWidth - 100;
            }




            if (state != State.Idle) timer += gameTime.ElapsedGameTime;

   
            while (timer.TotalMilliseconds > ANIMATION_FRAME_RATE)
            {
   
                frame++;
     
                timer -= new TimeSpan(0, 0, 0, 0, ANIMATION_FRAME_RATE);
            }
            
            frame %= 1;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // determine the source rectagle of the sprite's current frame
            var source = new Rectangle(
                frame * FRAME_WIDTH, // X value 
                (int)state % 3 * FRAME_HEIGHT, // Y value
                FRAME_WIDTH, // Width 
                FRAME_HEIGHT // Height
                );

            // render the sprite
            spriteBatch.Draw(player_sprite, playerPosition, source, Color.White);
            
        }






    }


}
