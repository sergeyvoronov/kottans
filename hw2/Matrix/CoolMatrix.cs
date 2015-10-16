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

        public static bool operator ==(CoolMatrix cm1, CoolMatrix cm2)
        {
            if (cm1.Size != cm2.Size) return false;
            for (int i = 0; i < cm1.Size.Width; i++)
            {
                for (int j = 0; j < cm2.Size.Height; j++)
                {
                    if (cm1[i, j] == cm2[i, j]) return false;
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
            for (int i = 0; i < matrix.Size.Width; i++)
            {
                for (int j = 0; j < matrix.Size.Height; j++)
                {
                    matrix[i, j] = matrix[i, j] * multiplier;
                }
            }
            return matrix;
        }

        public static CoolMatrix operator +(CoolMatrix cm1, CoolMatrix cm2)
        {
            if (cm1.Size!=cm2.Size) throw  new ArgumentException();
            for (int i = 0; i < cm1.Size.Width; i++)
            {
                for (int j = 0; j < cm1.Size.Height; j++)
                {
                    cm1[i, j] = cm1[i, j] + cm2[i, j];
                }
            }
            return cm1;
        }

        protected bool Equals(CoolMatrix other)
        {
            return Equals(_arr, other._arr) && Equals(Size, other.Size) && IsSquare == other.IsSquare;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CoolMatrix)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_arr != null ? _arr.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Size != null ? Size.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ IsSquare.GetHashCode();
                return hashCode;
            }
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
             var newCoolMatrix = new int[this.Size.Height, this.Size.Width];
             for (int i = 0; i < this.Size.Height; i++)
             {
                 for (int j = 0; j < this.Size.Width; j++)
                 {
                     newCoolMatrix[i, j] = this[j, i];
                 }
             }
             return newCoolMatrix;
        }
   
    }
}
