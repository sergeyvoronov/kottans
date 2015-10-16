using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Size
    {
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private int _height;
        private int _width;
        public bool IsSquare;

        public Size(int height, int width)
        {
            _height = height;
            _width = width;
            IsSquare = (_height == _width) ? true : false;
        }

        public static bool operator  == (Size s1, Size s2)
        {
            if (s1.Width == s2.Width && s1.Height == s2.Height) return true;
            else
                return false;
        }

        public static bool operator !=(Size s1, Size s2)
        {
            if (s1.Width != s2.Width || s1.Height != s2.Height)
                return true;
            else
                return false;
        }
    }
}
