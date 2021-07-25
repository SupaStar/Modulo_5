using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Modulo_5.Models
{
    public class Encriptador
    {
        readonly SHA256 hashAlgorithm = SHA256.Create();
        private string path = @"/clave.txt";
        public void crearLlave()
        {
            if (!File.Exists(path))
            {
                try
                {
                    List<char> abecedario = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                            'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r','s','t','u','v','w','x','y','z',' ','1','2','3','4','5','6'
                        ,'7','8','9','0'};
                    using (FileStream fs = File.Create(path))
                    {
                        char[] nuevoAbecedario = new char[abecedario.Count];
                        DateTime foo = DateTime.Now;
                        long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
                        var random = new Random(Convert.ToInt32(unixTime));
                        int restantes = abecedario.Count;
                        int posicionRandom = random.Next(0, abecedario.Count);
                        int posicionnuevoIndice = 0;
                        while (restantes > 0)
                        {
                            nuevoAbecedario[posicionnuevoIndice] = abecedario[posicionRandom];
                            posicionnuevoIndice++;
                            abecedario.RemoveAt(posicionRandom);
                            posicionRandom = random.Next(0, abecedario.Count);
                            restantes = abecedario.Count;
                        }
                        string codigo = "";
                        foreach (char letra in nuevoAbecedario)
                        {
                            codigo += letra;
                        }
                        byte[] info = new UTF8Encoding(true).GetBytes(codigo);
                        fs.Write(info, 0, info.Length);
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public string Hashing(string input)
        {
            List<char> abecedario = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                            'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r','s','t','u','v','w','x','y','z',' ','1','2','3','4','5','6'
                        ,'7','8','9','0'};
            string nuevaPalabra = "";
            string codigo = "";
            string indices = "";
            List<char> codigoLista = new List<char>();
            using (StreamReader sr = File.OpenText(path))
            {
                string a;
                while ((a = sr.ReadLine()) != null)
                {
                    codigo += a;
                }
            }
            foreach (char letra in codigo)
            {
                codigoLista.Add(letra);
            }
            foreach (char letra in input)
            {
                int indice = abecedario.IndexOf(letra);
                nuevaPalabra += codigoLista[indice];
            }
            return nuevaPalabra;
        }
        public string DeHashing(string input)
        {
            List<char> abecedario = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                            'l', 'm', 'n', 'ñ', 'o', 'p', 'q', 'r','s','t','u','v','w','x','y','z',' ','1','2','3','4','5','6'
                        ,'7','8','9','0'};
            string nuevaPalabra = "";
            string codigo = "";
            List<char> codigoLista = new List<char>();
            using (StreamReader sr = File.OpenText(path))
            {
                string a;
                while ((a = sr.ReadLine()) != null)
                {
                    codigo += a;
                }
            }
            foreach (char letra in codigo)
            {
                codigoLista.Add(letra);
            }
            foreach (char letra in input)
            {
                int indice = codigoLista.IndexOf(letra);
                nuevaPalabra += abecedario[indice];
            }
            return nuevaPalabra;
        }
        public bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            var hashOfInput = Hashing(input);
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;
            return comparer.Compare(hashOfInput, hash) == 0;
        }

    }
}
