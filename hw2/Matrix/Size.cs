using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Size
    {
        public int Width => _width;
        public int Height => _height;
        private readonly int _height;
        private readonly int _width;
        public bool IsSquare;
     

        public Size(int width, int height)
        {
            _height = height;
            _width = width;
            IsSquare = (_height == _width) ? true : false;
        }

        public static bool operator  == (Size s1, Size s2)
        {  
            return (s1.Width == s2.Width && s1.Height == s2.Height);
        }

        public static bool operator !=(Size s1, Size s2)
        {
            return !(s1==s2);
        }

        public override bool Equals(object obj)
        {
            var objSize = obj as Size;
            if (objSize == null) return false;
            return objSize == this;
        }

        public override int GetHashCode()
        {
            return _width*_height;
        }
    }
}
