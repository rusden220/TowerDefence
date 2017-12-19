using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TowerDefense.Render.Image
{
    public class AnimationBitmap
    {
        private List<Bitmap> _mainBitmapList;
        //private long _timeIntervalTicks;
        private int _currentIndexBitmapArray;

        //contains the time the last time were given bitmap
        private long _timeOfLastReturnBitmap;

        public AnimationBitmap(long timeIntervalTicks, params Bitmap[] arrayBitmap)
        {
            this.TimeIntervalTicks = timeIntervalTicks;
            _mainBitmapList = new List<Bitmap>();
            AddBitmaps(arrayBitmap);
            _currentIndexBitmapArray = 0;
        }
        public void AddBitmaps(params Bitmap[] arrayBitmap)
        {
            _mainBitmapList.AddRange(arrayBitmap);
        }
        public Bitmap GetNextBitmap(long timeStempTicks)
        {
            if (timeStempTicks > TimeIntervalTicks || timeStempTicks + _timeOfLastReturnBitmap > TimeIntervalTicks)
            {
                System.Diagnostics.Debug.WriteLine("new");
                _timeOfLastReturnBitmap = 0;
                return _mainBitmapList[GetNextIndexInBitmapArray()];
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("old");
                _timeOfLastReturnBitmap += timeStempTicks;
                return _mainBitmapList[_currentIndexBitmapArray];
            }
        }
        public long TimeIntervalTicks { get; set; }

        public bool isСyclic { get; set; }

        private int GetNextIndexInBitmapArray()
        {
            if (_currentIndexBitmapArray + 1 == _mainBitmapList.Count)
            {
                if (isСyclic)
                    _currentIndexBitmapArray = 0;
            }
            else
                _currentIndexBitmapArray++;

            return _currentIndexBitmapArray;
        }

    }
}
