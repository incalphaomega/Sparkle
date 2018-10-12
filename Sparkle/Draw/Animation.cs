using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparkle.Draw
{
    class Animation
    {
        public Texture2D texture { get; set; }
        public int frameW { get; private set; }
        public int frameH { get; private set; }
        public int speed { get; set; }
        public int frameCount { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameCount">Количество кадров</param>
        /// <param name="texture">Раскадровка</param>
        /// <param name="speed">Скорость анимации в кадрах в секунду</param>
        public Animation(int frameCount, Texture2D texture, int speed)
        {
            this.texture = texture;
            frameW = texture.Width / frameCount - 1;
            frameH = texture.Height - 1;
            this.speed = speed;
            this.frameCount = frameCount;
        }
    }
}
