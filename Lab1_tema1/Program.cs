using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1_tema1
{
    class Program
    { 
        static int nrZile = 31;  // Pentru testare se poate inlocui cu 2 sau 3 (zile)
        static int nrOre = 24;
        static double[,] temperaturi_zilnic_pe_ore = new double[nrZile, nrOre];

        static void citire()
        {            
            //metoda GetLength(d) returneaza numarul de elemente aflate pe dimensiunea numarul d
                //(numararea dimensiunilor incepe cu 0)

                // Parcurgem liniile 0, 1, 2, ..., 30, pe rand (31 linii)
            for (int i = 0; i < temperaturi_zilnic_pe_ore.GetLength(0); i++) // sau nrZile
            {
               //In fiecare linie parcurgem elementele din coloana 0, 1, 2, 3... 23 (24 coloane)
                for (int j = 0; j < temperaturi_zilnic_pe_ore.GetLength(1); j++)  // sau nrOre
                {
                    Console.Write("ziua {0}, ora {1}= ", i+1, j);
                    temperaturi_zilnic_pe_ore[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }           
        }

        static void minMax()
        {
            //Cate o zi, pe rand
                for (int i = 0; i < nrZile; i++)
                {
                    // Presupunem ca temperatura din ziua i de la ora 0 este minima (/maxima)
                    double min = temperaturi_zilnic_pe_ore[i, 0],
                        max = temperaturi_zilnic_pe_ore[i, 0];
                    for (int j = 0; j < nrOre; j++)
                    {
                        // Daca gasim o temperatura in ziua i mai mica decat min (/mai mare decat max)
                        //   inlocuim valoarea aleasa pentru min (/max)
                        if (temperaturi_zilnic_pe_ore[i, j] < min)
                            min = temperaturi_zilnic_pe_ore[i, j];
                        if (temperaturi_zilnic_pe_ore[i, j] > max)
                            max = temperaturi_zilnic_pe_ore[i, j];
                    }
                    // Afisam minimul (/maximul) din ziua i (in loc de ziua 0 afisam ziua 1 = i+1)
                    Console.WriteLine("Temperatura minima  ziua {0}  = {1}", i + 1, min);
                    Console.WriteLine("Temperatura maxma  ziua {0}  = {1}", i + 1, max);
                }
        }

        static double mediaOra7()
        {
                double suma_temperaturi = 0;
                for (int i = 0; i < nrZile; i++)
                {
                    suma_temperaturi += temperaturi_zilnic_pe_ore[i, 7];
                }
                // Returnam media temperaturilor, 
                return suma_temperaturi / nrZile;
        }

        static void MaxNoaptea(ref double max)
        {
            // Presupunem ca temperatura din prima zi (0) de la ora 0 este maxima
            max = temperaturi_zilnic_pe_ore[0, 0];
            //Cate o zi, pe rand
            for (int i = 0; i < nrZile; i++)
            {
                for (int j = 0; j < nrOre; j++)
                {
                    // Daca gasim o temperatura in ziua i mai mica decat min (/mai mare decat max)
                    //   inlocuim valoarea aleasa pentru min (/max)
                    if (j <= 5 || j >= 22)
                        if (temperaturi_zilnic_pe_ore[i, j] > max)
                            max = temperaturi_zilnic_pe_ore[i, j];
                }
            }
        }

        static void Main(string[] args)
        {
            try
            {
                // Citim elementele matricei
                citire();                

                // Afisam temperaturile minima si maxima
                minMax();

                // Afisam temperatura medie la ora 7
                Console.WriteLine("Temperatura medie la ora 7 = {0} ", mediaOra7());

                // Afisam temperatura maxima de noaptea
                double maxN = 0;
                MaxNoaptea(ref maxN);
                Console.WriteLine("Temperatura maxima de noapte = {0} ", maxN);

                // Afisam elementele matricei
                Console.WriteLine("\n========Afisare cu 2 zecimale aliniere la dreapta=========");
                for (int i = 0; i < temperaturi_zilnic_pe_ore.GetLength(0); i++)
                {
                    for (int j = 0; j < temperaturi_zilnic_pe_ore.GetLength(1); j++)
                    {
                        // Afisam elementele,  sub forma de tablou bidimensional pe linii si coloane
                        //  pe 10 pozitii, aliniate la dreapta cu 2 zecimale
                        Console.Write("{0,10:f2} ", temperaturi_zilnic_pe_ore[i, j]);
                    }
                    // Dupa fiecare linie afisata trecem la rand nou
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
