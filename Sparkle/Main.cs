using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Sparkle.Draw;
using Sparkle.Draw.Primitives;
using Sparkle.Handlers;
using System;
using System.Collections.Generic;
using static Sparkle.Handlers.Input;
using Point = Sparkle.Draw.Primitives.Point;

namespace Sparkle
{
    public class Main : Game
    {
        public static GraphicsDeviceManager graphics { get; private set; }
        public static SpriteBatch spriteBatch { get; private set; }
        public static ContentManager content { get; private set; }

        public static SpriteFont console { get; private set; }

        Player player;

        Rectangle rect;

        List<Point> points = new List<Point>();
        Line line;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            content = Content;
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            TextureManager.Initialize();
            player = new Player(new Vector2(200));
            rect = new Rectangle(200, 200, 200, 200);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            console = Content.Load<SpriteFont>("Console");
            player.LoadContent();
        }

        protected override void UnloadContent()
        {

        }

        Point check;
        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            if (keyPressed(Keys.Escape))
            {
                Exit();
            }
            line.Update();
            if (isButtonDown(Input.Buttons.Left))
            {
                line.P1 = mousePoint;
            }
            if (isButtonDown(Input.Buttons.Right))
            {
                line.P2 = mousePoint;
            }
            if (line.Intersects(mousePoint))
            {
                line.color = Color.Red;
            }
            else
            {
                line.color = Color.White;
            }
            check.X = mousePoint.X;
            if (line.Intersects(mousePoint))
            {
            check.Y = (int)(mousePoint.X * Math.Abs(line.angle));
            }
            else
            {
                check.Y = mousePoint.Y;
            }

            player.Update();

            Input.oldUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null, null, null);
            //player.Draw(gameTime);
            int pointsCount = 0;
            foreach(Point p in points)
            {
                pointsCount++;
                DrawPrimitives.DrawPoint(p, 2, Color.White);
            }
            DrawPrimitives.DrawPoint(line.P1, 2, Color.Red);
            DrawPrimitives.DrawPoint(line.P2, 2, Color.Blue);
            DrawPrimitives.DrawPoint(check, 5, Color.Green);
            DrawPrimitives.DrawLine(line, 2);
            spriteBatch.DrawString(console, pointsCount.ToString(), Vector2.Zero, Color.Black);
            spriteBatch.DrawString(console, pointsCount.ToString(), Vector2.Zero, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
