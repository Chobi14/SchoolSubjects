using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetico
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Elige una de las 3 funciones : \n1) Funcion 1\n2) Funcion 2\n3) Funcion 3\n ");
            string menu = Console.ReadLine();
            //switch (menu)

            double resultado = 0; int repeticiones = 0; int iteracion = 0;

            /////////// SE ELIGE EL rango de cada funcion que sea enteros //////////
            Console.WriteLine("Da el intervalo de rando para 'xa' : ");
            string x = Console.ReadLine();
            double ix = double.Parse(x);

            Console.WriteLine("Da el intervalo de rando para 'xb' : ");
            string xb = Console.ReadLine();
            double ixb = double.Parse(xb);

            Console.WriteLine("Da el intervalo de rando para 'ya' : ");
            string y = Console.ReadLine();
            double iy = double.Parse(y);

            Console.WriteLine("Da el intervalo de rando para 'yb' : ");
            string yb = Console.ReadLine();
            double iyb = double.Parse(yb);


            /////// SE DA EL NUMERO DE POBLACION ///////////////
            Console.WriteLine("Da el numero de poblacion");
            string poblacion = Console.ReadLine();
            int poblacione = int.Parse(poblacion);

            /////// SE DA EL % DE cruz ///////////////
            Console.WriteLine("Da el numero de cruza");
            string cruza = Console.ReadLine();
            double cruz = double.Parse(cruza);

            /////// SE DA EL % DE mutacion ///////////////
            Console.WriteLine("Da el numero de mutacion");
            string mutacion = Console.ReadLine();
            double mutacio = double.Parse(mutacion);

            Console.WriteLine("Da el numero de iteraciones");
            string iteracio = Console.ReadLine();
            repeticiones = int.Parse(iteracio);

            //LISTA PARA LA RULETA
            double[] resultados = new double[repeticiones];


            ///CRUZA
            double vezes = Math.Round((1 - cruz) * poblacione);
            int veces = Convert.ToInt32(vezes);

            double oli = (cruz * poblacione) / 2;
            double olis = Math.Round(oli * 2);
            int oliso = Convert.ToInt32(olis);


            ////////// SE CREA EL NUMERO DE BITS PARA CADA INDIVIDUO (B-A)*10A LA 6/////////////
            double bitsdeX = ((ixb - ix) * ((Int32)Math.Pow(10, 6) + 1));//int32 mas precision                                                                         

            double logx = Math.Log(bitsdeX, 2);            
            double n = 0;
            int contbitsX = 0;
            do
            {
                n++;
                contbitsX++;
            } while (logx >= n);
            n = 0;


            // Console.WriteLine("el cont x es " + contbitsX);
            double bitsdeY = ((iyb - iy) * ((Int32)Math.Pow(10, 6) + 1));
            //  Console.Write(bitsdeY);
            double logy = Math.Log(bitsdeY, 2);


            int contbitsY = 0;
            do
            {
                n++;
                contbitsY++;
            } while (logy >= n);
            n = 0;
            Console.WriteLine("el cont y es " + contbitsY);

            //NUMERO DE BITSTOTAL PARA CADA INDIVIDUO
            int bitstotal = (contbitsX + contbitsY);
            Console.WriteLine("el bits y es " + bitstotal);
			
            double[,] multi = new double[poblacione, bitstotal];

            //ARREGLO DE POBLACION
            double[] fitness = new double[poblacione];

            ///////GENERO 1S Y 0S PA LOS INDIVIDUOS
            Random ra = new Random();            
            int yu = 0; int gen = 0;

            ////////////PONER UNOS Y CEROS
            for (int i = 0; i < poblacione; i++)
            {
                for (int j = 0; j < bitstotal; j++)
                {
                    gen = ra.Next(1, 10);             
                    if (gen <= 5)
                    {
                        gen = 0;
                    }
                    else
                    {
                        gen = 1;
                    }
                    multi[i, j] = gen;                    
                    yu++;					
                }
            }
            gen = 0;

            for (int i = 0; i < poblacione; i++)
            {
                for (int j = 0; j < bitstotal; j++)
                {
                    Console.WriteLine(i + "susbits" + j);
                }
            }

            Console.WriteLine(multi[1, 0]);
            Console.WriteLine(multi[1, 2]);
            Console.WriteLine(multi[1, 1]);

            int olo = 0;

            double[,] Ps = new double[veces, bitstotal];

            double[,] Pss = new double[poblacione, bitstotal];
            List<double> seleccion = new List<double>();
            double mutacionparo = 0;            
            while (iteracion < repeticiones)
            {
                int cuenta = 0;
                gen = 0;               

                int contador = 0; int contadory = 0;
                double decdex = 0; double decdex1 = 0;/////4 bytes del integer mi maximo ha dado menor de 4 bytes 
                double decdey = 0; double decdey1 = 0;/// long 8 bytes
                double sumatoriax = 0; //double[] deccadabit = new double[contbitsX];
                double sumatoriay = 0; //double[] deccadabity = new double[contbitsY];
                double xx = 0; double yy = 0; double fxy = 0; double fitn = 0; double suma = 0;
				
                for (int i = 0; i < poblacione; i++)
                {
                    contador = 0;
                    contadory = 0;
                    xx = 0; yy = 0; contador = 0; contadory = 0;
                    decdex = 0; decdex1 = 0; decdey = 0; decdey1 = 0;
                    sumatoriax = 0; sumatoriay = 0; fxy = 0;
                    for (int j = bitstotal - 1; j >= 0; j--)
                    {

                        if (j >= contbitsX)
                        {
                            decdey = multi[i, j];///obtengo si es un 0 o 1 para poder hacer la conversion
                            if (decdey == 1)
                            {
                                decdey1 = (Int64)Math.Pow(2, contadory);
                                sumatoriay = sumatoriay + decdey1;                                
                            }
                            else
                            {
                                sumatoriay = sumatoriay + 0;                               
                            }
                            contadory++;
                        }
                        else
                        {
                            decdex = multi[i, j];///obtengo si es un 0 o 1 para poder hacer la conversion

                            if (decdex == 1)
                            {
                                decdex1 = (Int64)Math.Pow(2, contador);
                                sumatoriax = sumatoriax + decdex1;                            
                            }
                            else
                            {
                                sumatoriax = sumatoriax + 0;                                
                            }
                            contador++;
                        }

                    }
					
                    xx = ((ix) + (((sumatoriax) * (ixb - ix)) / (((double)Math.Pow(2, contbitsX)) - 1)));
                    yy = ((iy) + (((sumatoriay) * (iyb - iy)) / (((double)Math.Pow(2, contbitsY)) - 1)));                    
                    fxy = ((16 * xx) * (1 - xx) * (yy * (1 - yy)) * ((Math.Sin(poblacione * Math.PI * xx))) * ((Math.Sin(poblacione * Math.PI * yy)))) * ((16 * xx) * (1 - xx) * (yy * (1 - yy)) * ((Math.Sin(poblacione * Math.PI * xx))) * ((Math.Sin(poblacione * Math.PI * yy))));

                    //// ----------------------NEGAR LOS NEGATIVOS DE LOS FITNESSS------------------------------
                    if (fxy < 0)
                    {
                        fxy = 0;
                    }
					
                    fitn = 0;
                    fitn = (Math.Truncate(fxy * 100000)) / 100000;
                    fitness[i] = fitn;
                    Console.WriteLine("x es" + xx + "y es" + yy);
                    Console.WriteLine("sumatoria x" + sumatoriax + "sumatoria y" + sumatoriay);
                    suma = suma + fitn;
                    xx = 0;
                    yy = 0;
                }

                resultado = 0;
                resultado = suma / poblacione;
                Console.WriteLine("la suma es:" + suma + "el resultado" + resultado);
                resultados[iteracion] = resultado;

                double[] arreglo = new double[poblacione];
                for (int k = 0; k < poblacione; k++)
                {
                    arreglo[k] = fitness[k];

                }



                for (int k = 0; k < poblacione; k++)
                {
                    Console.WriteLine("normal" + fitness[k]);

                }

                Array.Sort(fitness);
                for (int k = 0; k < poblacione; k++)
                {
                    Console.WriteLine("ordenado" + fitness[k]);

                }
                fitness[0] = fitness[poblacione - 1];
                Console.WriteLine("elcambio" + fitness[0]);
                Array.Sort(fitness);
                for (int k = 0; k < poblacione; k++)
                {
                    Console.WriteLine("elnuevo" + fitness[k]);

                }
                suma = 0;
                resultado = 0;


                //////////**************      ENTRA LA RULETA                      *************/////////////////                
                double primer = 0, segundo = 0;
                double empieza = 0;
                empieza = Math.Round(poblacione * 0.3333);
                int empiezas = 0;
                empiezas = Convert.ToInt32(empieza);

                for (int i = 0; i < fitness.Length; i++)//tenia 1/empiezas
                {
                    primer = fitness[i];                
                    for (int j = 0; j < primer; j++)
                    {                        
                        seleccion.Add(primer);
                    }
                    primer = 0;                 
                }

                //SE APLICARA EL DE R PARA VER UCNATOS PASAN Y SE HAGA LA CRUZa

                Random r = new Random();
                int nuevas = 0;// cuentame = 0;
				              

                double[] temporal = new double[veces];
				
                for (int i = 0; i < veces; i++)
                {
                    nuevas = r.Next(seleccion.Count);//con 6 o -1
                    Console.WriteLine("seleccion es" + seleccion.Count);//comprueba[i] = seleccion[nuevas];
                    Console.WriteLine("las nuevas son" + nuevas);//comprueba[i] = seleccion[nuevas];
                    temporal[i] = seleccion[nuevas];
                }

                for (int i = 0; i < veces; i++)
                {
                    for (int j = 0; j < poblacione; j++)
                    {
                        if (temporal[i] == arreglo[j])
                        {
                            for (int k = 0; k < bitstotal; k++)
                            {
                                Ps[i, k] = multi[j, k];
                            }
                            break;/////////encuentra su fitness hace referencia a su binario y copia ese individuo al nuevo

                        }
                    }

                }

                for (int i = 0; i < veces; i++)
                {
                    Console.WriteLine("el temporal es " + temporal[i]);                    
                }


                for (int j = 0; j < bitstotal; j++)
                {
                    Console.WriteLine((veces - 1) + "el ps es " + Ps[(veces - 1), j]);
                }


                for (int i = 3; i < poblacione; i++)

                {
                    for (int j = 0; j < bitstotal; j++)
                    {
                        Console.WriteLine(i + "el multi es " + multi[i, j]);

                    }
                }

                Console.WriteLine(bitstotal);

                
                resultado = 0;


                ///////------------ RANDOM DE LA POB ORIBIGINAL AGARRO EL PAR PA FORMAR LOS Q FALTAN 

                Random aleatorio = new Random();
                int par = 0;

                double[] cruzando = new double[oliso];
                double[,] temporale = new double[oliso, bitstotal];

                // if (veces < poblacione)          


                for (int i = 0; i < oliso; i++)
                {
                    par = aleatorio.Next(seleccion.Count);//con 6 o -1
                    Console.WriteLine("el par es" + par);                                     //comprueba[i] = seleccion[nuevas];
                    cruzando[i] = seleccion[par];
                    Console.WriteLine("el cruzando es" + cruzando[i]);
                }
                int[] cruso = new int[oliso];
                int[] crusos = new int[oliso];
                //if (olo < 1)

                for (int i = 0; i < oliso; i++)
                {
                    for (int pl = 0; pl < poblacione; pl++)
                    {
                        if (cruzando[i] == arreglo[pl])
                        {
                            Console.WriteLine("el pl es" + pl);
                            for (int k = 0; k < bitstotal; k++)
                            {
                                temporale[i, k] = multi[pl, k];

                            }
                            break;/////////encuentra su fitness hace referencia a su binario y copia ese individuo al nuevo

                        }
                    }

                }

                ////PASAR TEMPORALE A PS PA COMPLETAR LA NUEVA POBLACION
                double[,] temporales = new double[oliso, bitstotal];
                int pob = oliso;
                for (int i = 0; i < oliso; i++)
                {

                    for (int k = 0; k < contbitsX; k++)
                    {
                        temporales[i, k] = temporale[i, k];

                    }


                }

                pob = (oliso - 1);
                for (int i = 0; i < oliso; i++)
                {

                    for (int k = contbitsX; k < bitstotal; k++)
                    {
                        temporales[i, k] = temporale[pob, k];

                    }
                    Console.WriteLine("El pob es:" + pob);
                    pob--;

                }

                /////////////////ENTRAN
                Array.Clear(multi, 0, ((bitstotal * poblacione) - 1));
                multi = new double[poblacione, bitstotal];
                for (int i = 0; i < poblacione; i++)
                {
                    if (i < (poblacione - oliso))
                    {
                        for (int k = 0; k < bitstotal; k++)
                        {
                            multi[i, k] = Ps[i, k];

                        }
                    }
                    else
                    {
                        for (int k = 0; k < bitstotal; k++)
                        {
                            multi[i, k] = temporales[(i - veces), k];

                        }
                    }


                }


                ////////////ENTRA MUTACION EN MI NUEVA POBLACION
                if (mutacio != 0)
                {
                    double tortuga = Math.Round(mutacio * poblacione);
                    int tortugas = Convert.ToInt32(tortuga);
                    int paro = 0;
                    int paros = 0;
                    for (int i = 0; i < tortugas; i++)
                    {
                        paro = aleatorio.Next(0, poblacione);
                        paros = aleatorio.Next(0, bitstotal);

                        Console.WriteLine("el indi es" + paro + "el bit es" + paros);

                        if (multi[paro, paros] == 0)
                        {
                            multi[paro, paros] = 1;
                        }
                        else
                        {
                            multi[paro, paros] = 0;
                        }


                    }
                }
                ////////////////////////////////
                seleccion.Clear();
                seleccion = new List<double>();

                Array.Clear(Ps, 0, ((bitstotal * veces) - 1));
                Ps = new double[poblacione, bitstotal];

                Array.Clear(Ps, 0, ((bitstotal * veces) - 1));
                Ps = new double[poblacione, bitstotal];

                Array.Clear(temporale, 0, ((bitstotal * oliso) - 1));
                Ps = new double[poblacione, bitstotal];

                Array.Clear(temporales, 0, ((bitstotal * oliso) - 1));
                Ps = new double[poblacione, bitstotal];

                Array.Clear(fitness, 0, (poblacione - 1));
                fitness = new double[poblacione];

                Console.WriteLine(iteracion);
                iteracion++;                
            }
            string[] lines = new string[repeticiones];
            int u = 0;

            foreach (double a in resultados)
            {
                string ad = Convert.ToString(a);
                lines[u] = ad;
                u++;
            }

            System.IO.File.WriteAllLines(@"C:\mutacion3.xls", lines);            
        }
    }
}