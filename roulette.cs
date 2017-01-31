//Luis German Paredes Aguilar
//Selection method called roulette

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Program
    {
        static void Main(string[] args)
        {
            int h1 = 0, h2 = 0, h3 = 0, h4 = 0;
            double temp = 0;
            List<double> seleccion = new List<double>();


            Console.WriteLine("Da el numero de población");
            string poblacion = Console.ReadLine();
            int poblacione = int.Parse(poblacion);

            double[] fitness = new double[poblacione];
           
            int cont = 1;

            for (int i = 0; i < fitness.Length; i++)
            {
                Console.WriteLine("\nDame los fitnes del h" + cont + " :\t");
                string fitnes = Console.ReadLine();
                double fitnese = double.Parse(fitnes);

                fitness[i] = fitnese;

                fitnes = "\0";
                fitnese = 0;
                cont++;
            }

            
            double primer = 0, segundo = 0;

            for (int i = 0; i < fitness.Length; i++)
            {
                primer = fitness[i];
                
                for (int j = 0; j < primer; j++)
                {                    
                    seleccion.Add(segundo);
                }
                primer = 0;                
            }

            Random r = new Random();
            int nuevas = 0, cuenta = 0;
            
            double[] comprueba = new double[seleccion.Count];

            Console.WriteLine("Como se distribuyo en mi lista son \t");

            for (int i = 0; i < seleccion.Count; i++)
            {
                Console.WriteLine(seleccion[i] + "\t");
            }
            
            for (int i = 0; i < 4000; i++)
            {
                nuevas = r.Next(seleccion.Count);            
                comprueba[i] = seleccion[nuevas];               
            }

            Console.WriteLine("los numeros aleatorios escogidos por la ruleta son : \n");

            for (int i = 0; i < 4000; i++)
            {
                Console.WriteLine(comprueba[i] + "\n");
            }

            Console.WriteLine("las probabilidades de caer en los h1,h2,h3,h4 son:\n");
            Console.WriteLine(h1 + "\n" + h2 + "\n" + h3 + "\n" + h4 + "\n");          


        }
    }

