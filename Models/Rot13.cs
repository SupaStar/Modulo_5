using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class Rot13
    {
        public char[] abecedarioM = { ' ', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '.','0', '1', '2', '3', '4', '5','6', '7', '8', '9' };
        public char[] abecedario = new char[38];
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
        
        public void encriptar()
        {
            string phrase = "El viernes 11 de Junio del 2021 el equipo 3 expone Rot13";
            string palabra = "";
            char[] caracteres = new char[phrase.Length];
            foreach (char letra in phrase)
            {
                for (int i = 0; i < abecedario.Length; i++)
                {
                    if (letra == abecedarioM[i])
                    {

                        if (i == 0)
                        {
                            System.Diagnostics.Debug.WriteLine(abecedarioM[i + 27]);
                            palabra+=(abecedarioM[i + 27]);
                        }
                        else if (i == 27)
                        {
                            System.Diagnostics.Debug.WriteLine(abecedarioM[i - 27]);
                            palabra+=(abecedarioM[i - 27]);

                        }
                        else
                        {
                            if(i<=13)
                            {
                                System.Diagnostics.Debug.WriteLine(abecedarioM[i +13]);
                                palabra+=(abecedarioM[i + 13]);

                            }
                            else if(i<27)
                            {
                                System.Diagnostics.Debug.WriteLine(abecedarioM[i - 13]);
                                palabra+=(abecedarioM[i - 13]);
                            }
                            else
                            {
                                if(i>27 && i<=32)
                                {
                                    System.Diagnostics.Debug.WriteLine(abecedarioM[i +5]);
                                    palabra+=(abecedarioM[i + 5]);
                                }
                                else if(i>32)
                                {
                                    System.Diagnostics.Debug.WriteLine(abecedarioM[i - 5]);
                                    palabra+=(abecedarioM[i - 5]);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (letra == abecedario[i])
                        {


                            if (i <= 13)
                            {
                                System.Diagnostics.Debug.WriteLine(abecedario[i + 13]);
                                palabra+=(abecedario[i + 13]);

                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine(abecedario[i - 13]);
                                palabra+=(abecedario[i - 13]);
                            }
                        }
                     
                      
                        }
                    }
                }
            Console.WriteLine(palabra);
          
            }
          

        }
    }

