using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CeaserCipher
{
    public class CeasarCipher
    {
        private readonly int _offset;
        private int minValueASCIITable = 33;
        private int maxValueASCIITable = 127;
        private readonly char[] _charletters;

        public CeasarCipher(int offset)
        {
            _charletters = new char[maxValueASCIITable-minValueASCIITable];
            Parallel.For(0, maxValueASCIITable - minValueASCIITable, index =>
            {
                _charletters[index] = (char) (index + minValueASCIITable);
            });
            this._offset = offset;
        }



        public string Decrypt(string str)
        {
            return DecryptEncrypt(str, Crypt.Decrypt);
        }

        public string Encrypt(string str)
        {
            return DecryptEncrypt(str, Crypt.Encrypt);
        }

        public string DecryptEncrypt(string str, Crypt crypt)
        {
            checkIsStringCorrect(str);
            string result = "";
            foreach (char t in str)
            {
                if (t == ' ')
                {
                    result += ' ';
                    continue;
                }
                for (int j = 0; j < _charletters.Length; j++)
                {
                    if (t == _charletters[j])
                    {
                        if (crypt== Crypt.Decrypt)
                        {
                            result += (j - _offset < 0)
                                ? _charletters[_charletters.Length - j - _offset]
                                : _charletters[j - _offset];
                        }
                        else
                        {
                            result += (j + _offset < _charletters.Length)
                           ? _charletters[j + _offset]
                           : _charletters[j + _offset - _charletters.Length];
                        }
                        break;
                    }
                }
            }
            return result;
        }


        private void checkIsStringCorrect(string str)
        {
           if (str == null) throw new ArgumentNullException();
           if (str.Length==1) if (char.IsControl(Convert.ToChar(str))) throw new ArgumentOutOfRangeException();
        }

        //realization without arrays

        //public string Encrypt(string str)
        //{
        //    checkIsStringCorrect(str);
        //    return string.Join("", str.Select(EncryptChar));
        //}

        //char EncryptChar(char letter)
        //{
        //    if (letter == ' ') return ' ';
        //    char encryptChar = (char)(((letter + offset)));
        //    if (encryptChar >= maxValueASCIITable) encryptChar = (char) (minValueASCIITable + (encryptChar - maxValueASCIITable));
        //    return encryptChar;
        //}

        //public string Decrypt(string str)
        //{
        //    checkIsStringCorrect(str);
        //    return string.Join("", str.Select(DecryptChar));
        //}

        //char DecryptChar(char letter)
        //{
        //    if (letter == ' ') return ' ';           
        //    char decryptChar = (char)(((letter - offset) ));
        //    if (decryptChar < minValueASCIITable) decryptChar = (char) (maxValueASCIITable - (minValueASCIITable - decryptChar));
        //    return decryptChar;
        //}
        
    }
}

