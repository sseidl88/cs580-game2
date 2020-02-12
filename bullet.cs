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
    public class bullet: Game
    {
        public bool shooting = false;
        public Rectangle bulletPosition = new Rectangle(0,0,15,15);
        public bool isVisible;

        public bullet(Rectangle position)
        {
            bulletPosition.Y = position.Y + 35;
            bulletPosition.X = position.X + 40;
       
        }

        public void  LoadContent(ContentManager content)
        {
           
          
        }

        public void Update()
        {
            bulletPosition.X += 1;
        }

        public void UodateBullets()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }  
}
