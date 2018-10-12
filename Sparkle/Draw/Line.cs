using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkle.Draw
{
    class Line
    {
        Vector2 p1, p2;
        float length, angle;
        public float globalRotation = 0;

        public Line(Vector2 p1, Vector2 p2)
        {
            this.p1 = p1;
            this.p2 = p2;
            length = Vector2.Distance(p1,p2);
            angle = (float)Math.Atan2(p2.Y - p1.Y, p2.X - p1.X);
        }

        public Line(Vector2 p1, float length, int angle)
        {
            this.p1 = p1;
            this.length = length;
            this.angle = MathHelper.ToRadians(angle);
        }

        public void Draw(double thickness)
        {
            Main.spriteBatch.Draw(TextureManager.NullTexture, new Rectangle((int)p1.X, (int)p1.Y, (int)length, (int)thickness), null, Color.White, angle + globalRotation, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
