using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkle.Draw
{
    class Render
    {
        Texture2D texture;
        Rectangle sourceRectangle;
        Vector2 origin;
        float alpha, rotation, scale;

        /// <summary>
        /// Текстура для отрисовки.
        /// </summary>
        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
                sourceRectangle = fullTexture();
            }
        }
        /// <summary>
        /// Бокс фактически отрисовываемой текстуры с учётом масштаба.
        /// </summary>
        public Rectangle SourceRectangle
        {
            get
            {
                return new Rectangle((int)(sourceRectangle.X * scale), (int)(sourceRectangle.Y * scale), (int)(sourceRectangle.Width * scale), (int)(sourceRectangle.Height * scale));
            }
            set
            {
                sourceRectangle = new Rectangle((int)(value.X * scale), (int)(value.Y * scale), (int)(value.Width * scale), (int)(value.Height * scale));
            }
        }
        /// <summary>
        /// Цвет текстуры.
        /// </summary>
        public Color color { get; set; }
        /// <summary>
        /// Центр вращения и масштаба текстуры.
        /// </summary>
        public Vector2 Origin
        {
            get 
            {
                return new Vector2(origin.X, origin.Y);
            }
            set
            {
                origin = new Vector2(value.X, value.Y);
            }
        }
        /// <summary>
        /// Отражение по двум осям.
        /// </summary>
        public SpriteEffects effect { get; set; }
        /// <summary>
        /// Непрозрачность текстуры в процентах.
        /// </summary>
        public float Alpha
        {
            get
            {
                return alpha * 100;
            }
            set
            {
                if(value < 0)
                {
                    value = 0;
                }
                else if(value > 100)
                {
                    value = 100;
                }
                alpha = value / 100;
                color = new Color(color, alpha);
            }
        }
        /// <summary>
        /// Угол поворота текстуры в градусах.
        /// </summary>
        public float Angle
        {
            get
            {
                return MathHelper.ToDegrees(rotation);
            }
            set
            {
                if(value < 0)
                {
                    value = 360 - Math.Abs(value);
                }
                else if(value > 360)
                {
                    value -= 360;
                }
                rotation = MathHelper.ToRadians((float)Math.Round(value));
            }
        }
        /// <summary>
        /// Масштаб текстуры в процентах.
        /// </summary>
        public float Size
        {
            get
            {
                return scale * 100;
            }
            set
            {
                if(value < 1)
                {
                    value = 1;
                }
                scale = value / 100;
            }
        }

        public Render()
        {
            Texture = TextureManager.NullTexture;
            SourceRectangle = fullTexture();
            color = Color.White;
            Alpha = 100;
            Angle = 0;
            Origin = Vector2.Zero;
            Size = 100;
            effect = SpriteEffects.None;
        }

        public void Draw(Vector2 position)
        {
            Main.spriteBatch.Draw(texture, position, sourceRectangle, new Color(color, alpha), rotation, origin, scale, effect, 0);
        }

        public Rectangle texRec(Vector2 position)
        {
            return new Rectangle((int)(position.X - Origin.X), (int)(position.Y - Origin.Y), sourceRectangle.Width, sourceRectangle.Height);
        }

        public Rectangle textureRectangle(Vector2 position)
        {
            Vector2 origin = new Vector2((float)position.X + Origin.X / 2 * scale, (float)position.Y + Origin.Y / 2 * scale);

            float dx = (float)Math.Abs(Math.Cos(rotation)) * (sourceRectangle.Width * scale / 2.0f) + (float)Math.Abs(Math.Sin(rotation)) * (sourceRectangle.Height * scale / 2.0f);
            float dy = (float)Math.Abs(Math.Sin(rotation)) * (sourceRectangle.Width * scale / 2.0f) + (float)Math.Abs(Math.Cos(rotation)) * (sourceRectangle.Height * scale / 2.0f);

            //Vector2 origin = new Vector2((float)position.X + Origin.X * scale, (float)position.Y + Origin.Y * scale);

            //float dx = (float)Math.Abs(Math.Cos(rotation)) * (0 + origin.X * scale) + (float)Math.Abs(Math.Sin(rotation)) * (0 + origin.Y * scale);
            //float dy = (float)Math.Abs(Math.Sin(rotation)) * (0 + origin.X * scale) + (float)Math.Abs(Math.Cos(rotation)) * (0 + origin.Y * scale);

            int x = (int)Math.Round(origin.X - dx);
            int y = (int)Math.Round(origin.Y - dy);
            int w = (int)Math.Round(dx * 2.0f);
            int h = (int)Math.Round(dy * 2.0f);

            return new Rectangle(x, y, w, h);
        }

        public Vector2 textureCenter() => new Vector2(texture.Width / 2, texture.Height / 2);

        public Rectangle fullTexture()
        {
            return new Rectangle(0, 0, (int)(texture.Width * scale), (int)(texture.Height * scale));
        }
    }
}
