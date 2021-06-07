using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class Rot13
    {
        public char[] abecedarioM = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '.' };
        public char[] abecedario = new char[28];
        public int[] numeros = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public Rot13()
        {
            int loop = 0;
            foreach (char letra in abecedarioM)
            {
                abecedario[loop] = Char.ToUpper(letra);
                loop++;
            }
        }
        public void imprimir()
        {
            foreach (char letras in abecedarioM)
            {
                Console.WriteLine(letras);
            }
            foreach (char letras in abecedario)
            {
                Console.WriteLine(letras);
            }
        }
    }
}
