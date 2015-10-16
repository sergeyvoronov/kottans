using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace CeaserCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string v = "~";
            CeasarCipher cp = new CeasarCipher(1);
           // string encryptedString =cp.Encrypt(v);
           // Console.WriteLine(encryptedString);
            Console.WriteLine(cp.Encrypt((v)));
           
            Console.ReadKey();
        }
    }
}
