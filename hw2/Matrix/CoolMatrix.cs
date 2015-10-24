using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class CoolMatrix
    {
        private readonly int[,] _arr;
        public Size Size { get; set; }
        public bool IsSquare { get; set; }

        public CoolMatrix(int[,] arr)
        {
            if (arr == null) throw  new ArgumentNullException();
            this._arr = arr;
            Size = new Size(arr.GetLength(1), arr.GetLength(0));
            IsSquare = Size.IsSquare;
        }

        public int this[int l, int k]
        {
            get { return _arr[l, k]; }
            set { _arr[l, k] = value; }  
        }

        public static implicit operator CoolMatrix(int[,] arr)
        {
            return new CoolMatrix(arr);
        }

        public static implicit operator int[,] (CoolMatrix matrix)
        {
            return (int[,])matrix._arr.Clone();
        }

        public static bool operator ==(CoolMatrix cm1, CoolMatrix cm2)
        {
           
            for (int i = 0; i < cm1.Size.Height; i++)
            {
                for (int j = 0; j < cm1.Size.Width; j++)
                {
                    if (cm1[i, j] != cm2[i, j]) return false;
                }
            }
            return true;
        }

        public static bool operator !=(CoolMatrix cm1, CoolMatrix cm2)
        {
            return !(cm1 == cm2);
        }


        public static CoolMatrix operator *(CoolMatrix matrix, int multiplier)
        {
            CoolMatrix newMatrix = new int[matrix.Size.Height, matrix.Size.Width];
            for (int i = 0; i < matrix.Size.Height; i++)
            {
                for (int j = 0; j < matrix.Size.Width; j++)
                {
                    newMatrix[i, j] = matrix[i, j] * multiplier;
                }
            }
            return newMatrix;
        }

        public static CoolMatrix operator +(CoolMatrix cm1, CoolMatrix cm2)
        {
            if (cm1.Size!=cm2.Size) throw  new ArgumentException();
            CoolMatrix cm = new int[cm1.Size.Width, cm1.Size.Height];
            for (int i = 0; i < cm1.Size.Width; i++)
            {
                for (int j = 0; j < cm1.Size.Height; j++)
                {
                    cm[i, j] = cm1[i, j] + cm2[i, j];
                }
            }
            return cm;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Size.Height; i++)
            {
                int[] ar = new int[Size.Height];
                sb.Append("[");
                for (int j = 0; j < Size.Width; j++)
                {
                    ar[j] = _arr[i, j];
                }
                sb.Append(string.Join(", ", ar));
                if (i != Size.Height-1)
                    sb.AppendLine("]");
                else
                    sb.Append("]");
            }
            return sb.ToString();
        }

        public CoolMatrix Transpose()
        {
             var newCoolMatrix = new int[this.Size.Width, this.Size.Height];
             for (int r = 0; r < this.Size.Width; r++)
             {
                 for (int c = 0; c < this.Size.Height; c++)
                 {
                     newCoolMatrix[r, c] = this[c, r];
                 }
             }
             return newCoolMatrix;
        }

        protected bool Equals(CoolMatrix other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Equals(_arr, other) && Equals(Size, other.Size)) return true;
            for (int column = 0; column < Size.Height; column++)
            {
                for (int row = 0; row < Size.Width; row++)
                {
                    if (this[column, row] != other[column, row])
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((CoolMatrix)obj);
        }


        public override int GetHashCode()
        {
            return Size.GetHashCode();
        }
   
    }
}
