using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkle.Draw
{
    class TextureManager
    {
        public static readonly Texture2D NullTexture = new Texture2D(Main.graphics.GraphicsDevice, 1, 1);

        public static void Initialize()
        {
            NullTexture.SetData(new[] { Color.White });
        }

        public static Texture2D Load(string path)
        {
            return Main.content.Load<Texture2D>(path);
        }
    }
}
