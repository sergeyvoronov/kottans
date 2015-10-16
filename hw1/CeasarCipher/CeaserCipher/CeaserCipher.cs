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
        private int offset;
        private int minValueASCIITable = 33;
        private int maxValueASCIITable = 127;
        private char[] charletters;


        public CeasarCipher(int offset)
        {
            charletters = new char[maxValueASCIITable-minValueASCIITable];
            Parallel.For(0, maxValueASCIITable - minValueASCIITable, index =>
            {
                charletters[index] = (char) (index + minValueASCIITable);
            });
            this.offset = offset;
        }

        public string Encrypt(string str)
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
                for (int j = 0; j < charletters.Length; j++)
                {
                    if (t == charletters[j])
                    {
                        result += (j + offset < charletters.Length)
                            ? charletters[j + offset]
                            : charletters[j + offset - charletters.Length];
                        break;
                    }
                }
            }

            return result;
        }

        public string Decrypt(string str)
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
                for (int j = 0; j < charletters.Length; j++)
                {
                    if (t == charletters[j])
                    {
                        result += (j - offset < 0)
                            ? charletters[charletters.Length - j - offset]
                            : charletters[j - offset];
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

