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
        Texture2D rectangleTex;

        Render render;
        Animation idle;

        public Player(Vector2 position)
        {
            this.position = position;
            rectangleTex = new Texture2D(Main.graphics.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            rectangleTex.SetData(new[] { Color.White });
            render = new Render();
        }

        public void LoadContent()
        {
            render.texture = Main.content.Load<Texture2D>("PlayerRun");
            idle = new Animation(8, render);
        }

        public void Update()
        {
            if (position.X <= Main.graphics.PreferredBackBufferWidth)
            {
                position.X += 1;
            }
        }

        public void Draw(GameTime gameTime)
        {
            idle.Animate(8, gameTime, position);
        }
    }
}
