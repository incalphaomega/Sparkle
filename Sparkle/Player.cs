using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sparkle.Draw;
using Sparkle.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Sparkle.Handlers.Input;

namespace Sparkle
{
    class Player
    {
        Texture2D texture;
        Vector2 position;

        Rectangle rect, rect1, rect2;
        Texture2D rectangleTex;

        BoundingBox box;

        Render render;
        //Animation animation;

        public Player(Vector2 position)
        {
            this.position = position;
            rectangleTex = new Texture2D(Main.graphics.GraphicsDevice, 1, 1);
            rectangleTex.SetData(new[] { Color.White });
            render = new Render();
        }

        public void LoadContent()
        {
            render.Texture = TextureManager.Load<Texture2D>("Assassin");
            //animation = new Animation(2, TextureManager.Load<Texture2D>("Player"), 2);
            render.Origin = render.textureCenter();
            //render.Size = 25;
        }

        public void Update()
        {
            //rect = render.textureRectangle(position);
            rect = render.texRec(position);
            rect1 = new Rectangle((int)(position.X + render.Origin.X - 2.5f), (int)(position.Y + render.Origin.Y - 2.5f), 5, 5);
            rect2 = new Rectangle((int)(position.X - 2.5f), (int)(position.Y - 2.5f), 5, 5);
            if (isKeyDown(Keys.OemMinus))
            {
                render.Alpha--;
            }
            if (isKeyDown(Keys.OemPlus))
            {
                render.Alpha++;
            }
            if (isKeyDown(Keys.Q))
            {
                render.Angle--;
            }
            if (isKeyDown(Keys.E))
            {
                render.Angle++;
            }
            if (isKeyDown(Keys.Subtract))
            {
                render.Size--;
            }
            if (isKeyDown(Keys.Add))
            {
                render.Size++;
            }
            if (isKeyDown(Keys.Z))
            {
                render.Origin -= Vector2.One;
            }
            if (isKeyDown(Keys.X))
            {
                render.Origin += Vector2.One;
            }
            if (keyPressed(Keys.Left))
            {
                render.Angle -= 90;
            }
            if (keyPressed(Keys.Right))
            {
                render.Angle += 90;
            }

            if (rect.Contains(mousePoint))
            {
                render.color = Color.Red;
            }
            else
            {
                render.color = Color.White;
            }
        }

        public void Draw(GameTime gameTime)
        {
            Main.spriteBatch.Draw(rectangleTex, rect, new Color(Color.LightGray, 50));
            render.Draw(position);
            //render.Animate(position, animation, gameTime);
            //Main.spriteBatch.Draw(rectangleTex, rect1, new Color(Color.Red, 100f));
            Main.spriteBatch.Draw(rectangleTex, rect2, new Color(Color.Blue, 100f));
        }
    }
}
