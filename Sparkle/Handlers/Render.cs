using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkle.Handlers
{
    class Render
    {
        public Texture2D texture { get; set; }
        public Rectangle sourceRectangle { get; set; }
        public Color color { get; set; }
        /// <summary>
        /// Угол вращения
        /// </summary>
        public float angle { get; set; }
        /// <summary>
        /// Центр вращения
        /// </summary>
        public Vector2 origin { get; set; }
        /// <summary>
        /// Размер в процентах
        /// </summary>
        public float size { get; set; }
        /// <summary>
        /// Отражение
        /// </summary>
        public SpriteEffects effect { get; set; }

        public int alphaLevel { get; set; }

        float rotation, alpha, scale;

        public Render()
        {
            texture = new Texture2D(Main.graphics.GraphicsDevice, 1, 1);
            sourceRectangle = fullTexture(texture);
            origin = Vector2.Zero;
            angle = 0;
            color = Color.White;
            alphaLevel = 100;
            size = 100;
            effect = SpriteEffects.None;
        }

        public void Draw(Vector2 position)
        {
            if(size >= 100)
            {
                size = 100;
            }
            else if (size <= 0)
            {
                size = 0;
            }
            if (alphaLevel >= 100)
            {
                alphaLevel = 100;
            }
            else if (alphaLevel <= 0)
            {
                alphaLevel = 0;
            }
            scale = size / 100;
            rotation = (float)MathHelper.ToRadians(angle);
            alpha = (float)alphaLevel / 100;
            Main.spriteBatch.Draw(texture, position, sourceRectangle, new Color(color, alpha), rotation, origin, scale, effect, 0);
        }

        public void setTexture(Texture2D texture)
        {
            this.texture = texture;
            sourceRectangle = fullTexture(texture);
        }

        /// <summary>
        /// Возвращает Rectangle по физическим масштабам текстуры
        /// </summary>
        /// <param name="texture"></param>
        /// <returns></returns>
        public Rectangle textureRectangle(Vector2 position)
        {
            int width = (int)Math.Floor(texture.Width * scale);
            int height = (int)Math.Floor(texture.Height * scale);
            if (origin == Vector2.Zero)
            {
                return new Rectangle((int)position.X, (int)position.Y, width, height);
            }
            else
            {
                return new Rectangle((int)position.X - width/2, (int)position.Y - height/2, width, height);
            }
        }

        public static Rectangle fullTexture(Texture2D texture)
        {
            return new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public static Vector2 textureCenter(Texture2D texture)
        {
            return new Vector2(texture.Width / 2, texture.Height / 2);
        }
    }
}
