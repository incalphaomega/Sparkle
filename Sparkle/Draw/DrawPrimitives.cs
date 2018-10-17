using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sparkle.Draw.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Point = Sparkle.Draw.Primitives.Point;

namespace Sparkle.Draw
{
    class DrawPrimitives
    {
        static Texture2D texture = TextureManager.NullTexture;
        public static void DrawPoint(Point point, int thickness, Color color)
        {
            Main.spriteBatch.Draw(texture, new Rectangle(point.X - thickness / 2, point.Y - thickness / 2, thickness, thickness), color);
        }

        public static void DrawLine(Line line, int thickness)
        {
            Main.spriteBatch.Draw(texture, new Rectangle(line.P1.X, line.P1.Y, (int)line.length, thickness), null, line.color, line.angle, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
