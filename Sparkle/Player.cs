using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        Rectangle rectangle;
        Texture2D rectangleTex;

        Render render;

        public Player(Vector2 position)
        {
            this.position = position;
            render = new Render();
            //render.size = 25;
            rectangleTex = new Texture2D(Main.graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            rectangleTex.SetData(new[] { Color.White });
        }

        public void LoadContent()
        {
            texture = Main.content.Load<Texture2D>("Assassin");
            render.setTexture(texture);
            render.origin = Render.textureCenter(texture);
        }
        public void Update()
        {
            rectangle = render.textureRectangle(position);
            if (rectangle.Contains(mousePoint))
            {
                render.color = Color.Red;
            }
            else
            {
                render.color = Color.White;
            }
            if (isKeyDown(Keys.A))
            {
                position.X -= 2;
            }
            if (isKeyDown(Keys.D))
            {
                position.X += 2;

            }
            if (isKeyDown(Keys.W))
            {
                position.Y -= 2;
            }
            if (isKeyDown(Keys.S))
            {
                position.Y += 2;
            }
            if (isKeyDown(Keys.Q))
            {
                render.size--;
            }
            if (isKeyDown(Keys.E))
            {
                render.size++;
            }
            //if (mousePosition.X > position.X)
            //{
            //    render.effect = SpriteEffects.None;
            //}
            //else if (mousePosition.X < position.X)
            //{
            //    render.effect = SpriteEffects.FlipHorizontally;
            //}
        }

        public void Draw()
        {
            render.Draw(position);
            Main.spriteBatch.Draw(rectangleTex, rectangle, new Color(Color.Gray, 70));
        }


    }
}
