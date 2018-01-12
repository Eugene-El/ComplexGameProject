using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartGameStructure
{
    public class Animator
    {
        private VisualImage visualImage;

        public Vector2 AmountOfFrames { get; set; }
        public Vector2 CurrentFrame { get; set; }

        public int SwitchTime { get; set; }
        private double currentTime;

        public int FrameWidth
        {
            get
            {
                if (AmountOfFrames.X != 0)
                    return (int)visualImage.TextureSize.X / (int)(AmountOfFrames.X+1);
                return (int)visualImage.TextureSize.X;
            }
        }

        public int FrameHeight
        {
            get
            {
                if (AmountOfFrames.Y != 0)
                    return (int)visualImage.TextureSize.Y / (int)(AmountOfFrames.Y+1);
                return (int)visualImage.TextureSize.Y;
            }
        }

        //

        public Animator()
        {
            AmountOfFrames = Vector2.Zero;
            CurrentFrame = Vector2.Zero;
            SwitchTime = 60;
        }

        public void LoadContent(ref VisualImage image)
        {
            visualImage = image;
        }

        public void Update(GameTime gameTime)
        {
            currentTime += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (currentTime >= SwitchTime)
            {
                currentTime = 0;

                if (CurrentFrame.X + 1 <= AmountOfFrames.X)
                    CurrentFrame += new Vector2(1, 0);
                else
                    CurrentFrame = new Vector2(0, CurrentFrame.Y);
                

            }

            visualImage.Rect = new Rectangle((int)CurrentFrame.X * FrameWidth, (int)CurrentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
        }
    }
}
