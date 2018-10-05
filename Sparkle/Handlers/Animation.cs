using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkle.Handlers
{
    class Animation
    {
        Render render;

        int frames, frameW, frameH, currentFrame;
        double elapsedTime;
        public bool isComplete { get; }

        /// <summary>
        /// Создание анимации
        /// </summary>
        /// <param name="frames">Кол-во кадров анимации</param>
        /// <param name="render">Отрисовщик</param>
        public Animation(int frames, Render render)
        {
            this.render = render;
            this.frames = frames;
            frameW = render.texture.Width / frames;
            frameH = render.texture.Height;

            isComplete = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="speed">скорость в кадрах в секунду</param>
        /// <param name="gameTime"></param>
        public void Animate(int speed, GameTime gameTime, Vector2 position)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (elapsedTime >= 1000 / speed)
            {
                currentFrame++;
                elapsedTime = 0;
            }
            if (currentFrame >= frames)
            {
                currentFrame = 0;
            }
            render.sourceRectangle = new Rectangle(0 + frameW * currentFrame, 0, frameW - 1, frameH - 1);
            render.Draw(position);
        }
    }
}
