using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class CoolMatrix
    {
        private readonly int[,] _arr;
        public Size Size { get; }
        public bool IsSquare { get; set; }


        public CoolMatrix(int[,] arr)
        {
            if (arr == null) throw  new ArgumentNullException();
            this._arr = arr;
            Size = new Size(arr.GetLength(0), arr.GetLength(1));
            IsSquare = Size.IsSquare;
        }

        public int this[int i, int k]
        {
            get { return _arr[i, k]; }
            set { _arr[i, k] = value; }  
        }

        public static implicit operator CoolMatrix(int[,] arr)
        {
            return new CoolMatrix(arr);
        }

        public static implicit operator int[,] (CoolMatrix matrix)
        {
            return (int[,])matrix._arr.Clone();
        }

        public static bool operator ==(CoolMatrix a, CoolMatrix b)
        {
            return true;
        }

        public static bool operator !=(CoolMatrix a, CoolMatrix b)
        {
            return true;
        }

    }
}
