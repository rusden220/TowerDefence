using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using TowerDefense.Render.Image;

namespace TowerDefense.Render
{
    public class GameRenderSettingsLoader
    {        
        public Bitmap LoadImageFromFile(string path)
        {
            return new Bitmap(path);
        }
        public AnimationBitmap LoadAnimationBitmapFromFile(AnimationBitmapSettingsData settings)
        {
            return new AnimationBitmap(settings.TimeInterval, CutImageByFrame(new Bitmap(settings.Path), settings.FrameSize));
        }
        private Bitmap[] CutImageByFrame(Bitmap bitmap, Size size)
        {
            //TODO write load data by frame
            return new Bitmap[] { bitmap };
        }
    }
}
