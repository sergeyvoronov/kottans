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

        public static bool operator ==(Size s1, Size s2)
        {
            return Equals(s1, s2);
        }

        public static bool operator !=(Size s1, Size s2)
        {
            return !(s1 == s2);
        }


        public bool Equals(Size s)
        {
            if (ReferenceEquals(null, s)) return false;
            if (ReferenceEquals(this, s)) return true;
            return Width == s.Width && Height == s.Height;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Size)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (Width * 397) ^ Height;
            }
        }
    }
}
