using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    public class enemy: Game
    {
        public bool isAlive = true;
        public Rectangle enemyPosition = new Rectangle(700, 0, 10, 10);
      

        public int speed;
        private int enemySpeed;

          
        const int ANIMATION_FRAME_RATE = 124;

        const float PLAYER_SPEED = 100;
        
        const int FRAME_WIDTH = 49;

        const int FRAME_HEIGHT = 64;
        
        Game1 game;
        Texture2D texture;
        TimeSpan timer;
        int frame;
        Vector2 position;
        SpriteFont font;


        public enemy(int enemySpeed, int randomY)
        {
            this.enemySpeed = enemySpeed;
            enemyPosition.Y = randomY;
           

        }

       

        public void CheckCollision(Rectangle player)
        {
            if (enemyPosition.Intersects(player))
            {
                Exit();
            }
        }

        public void Update()
        {
            enemyPosition.X += 2;
        }

        //public void Draw(SpriteBatch spritebatch)
        //{
        //    var source = new Rectangle(
        //        frame * FRAME_WIDTH, // X value 
        //        (int)state % 4 * FRAME_HEIGHT, // Y value
        //        FRAME_WIDTH, // Width 
        //        FRAME_HEIGHT // Height
        //        );

        //    // render the sprite
        //    spritebatch.Draw(texture, position, source, Color.White);
        //}
    }
}
