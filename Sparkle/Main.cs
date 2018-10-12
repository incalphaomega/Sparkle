using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sparkle.Draw;
using Sparkle.Handlers;
using static Sparkle.Handlers.Input;

namespace Sparkle
{
    public class Main : Game
    {
        public static GraphicsDeviceManager graphics { get; private set; }
        public static SpriteBatch spriteBatch { get; private set; }
        public static ContentManager content { get; private set; }

        Player player;

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
            line = new Line(new Vector2(200), new Vector2(400));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            player.LoadContent();
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            if (keyPressed(Keys.Escape))
            {
                Exit();
            }

            line.globalRotation += 0.01f;

            player.Update();

            Input.oldUpdate();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, null, null, null, null);
            //player.Draw(gameTime);
            line.Draw(1);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
