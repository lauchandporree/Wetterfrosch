using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Intrinsics.X86;
/// <summary>
/// Joel Bora/// BfArM - Bundesinstitut fuer Arzneimittel und Medizinprodukte
/// 17.08.2020
/// </summary>
namespace Wetterfrosch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variablen            
            int uhrzeit = 0, minute = 0, stunde = 0, auswahlEingabe = 0, mintemp = -10, maxtemp = 40; 

            double temperatur = 0, mittelwertTag = 0, median, spannweite, abweichung, summeAbweichung;// Als double für Kommazahlen
            
            Random zufall = new Random();
            
            string beendigung = "";

            //Array
            double[] tabelle = new double[1440];


            for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
            {
                temperatur = zufall.Next(mintemp, maxtemp); //Temperaturwert
                temperatur = temperatur + zufall.NextDouble();
                tabelle[uhrzeit] = temperatur;
            }

            //Sortierter Array
            double[] sortierteTabelle = (double[])tabelle.Clone();
            System.Array.Sort(sortierteTabelle);

            //Mittelwert
            for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
            {
                mittelwertTag += tabelle[uhrzeit] / tabelle.Length;
            }

            //mittlere Abweichung
            
            summeAbweichung = 0;

            for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
            {
                summeAbweichung += tabelle[uhrzeit] - mittelwertTag;
            }

            abweichung = summeAbweichung / tabelle.Length;

            //Häufigkeit der Werte

            int[] haeufigkeit = new int[maxtemp-mintemp+1];

            for (uhrzeit =0; uhrzeit < tabelle.Length; uhrzeit++)
            {
                var wert = tabelle[uhrzeit];
                var wertGerundet = (int)Math.Round(wert)-mintemp;
                haeufigkeit[wertGerundet]++;
            }

            

            // Aufgaben
           
                
                
                Console.WriteLine("(1) Mittelwerte und Minutenwerte");
                Console.WriteLine("(2) Aufgabe 2");
                Console.WriteLine("(3) Aufgabe 3");
                Console.WriteLine("(4) Aufgabe 4");
                Console.WriteLine("(5) Aufgabe 5");
                Console.WriteLine("(6) Aufgabe 6");
                Console.WriteLine("(7) Aufgabe 7");
                Console.WriteLine("(8) Aufgabe 8");
                Console.WriteLine("(0) Ende");
                Console.WriteLine("Zahl ohne Klammer");
                

                
                auswahlEingabe = Int32.Parse(Console.ReadLine());
                
                switch (auswahlEingabe)
                {
                    case 1: //Ausgabe Temperatur bei Minutenwerte
                        

                        for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Die Temperatur betrug {0:F0}°C bei Minute {1}", tabelle[uhrzeit], uhrzeit);
                        }
                        
                        Console.WriteLine("Der Mittelwert des Tages lag bei {0:F0}°C", mittelwertTag);


                        break;

                    case 2: //Ausgabe Uhrzeit und Temperatur mit Nachkommastelle

                        for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
                        {
                            stunde = uhrzeit / 60;
                            minute = uhrzeit % 60;
                            Console.WriteLine();
                            Console.WriteLine("Die Temperatur um {0}:{1}Uhr betrug {2:F1}°C",stunde, minute, tabelle[uhrzeit]);
                        }
                        
                        Console.WriteLine("Der Mittelwert des Tages lag bei {0:F1}°C", mittelwertTag);


                        break;

                    case 3: //Minimalwert

                        Console.WriteLine("\nDer niedrigste Temperaturwert lag bei {0:F1}°C\n", sortierteTabelle[0]);


                        break;

                    case 4: // Maximalwert

                        Console.WriteLine("\nDer höchste Temperaturwert lag bei {0:F1}°C\n", sortierteTabelle[1439]);

                       
                        break;

                    case 5: // Median

                        median = sortierteTabelle[(sortierteTabelle.Length / 2)];

                        Console.WriteLine("\nDer Median liegt bei {0}°C \n", median);


                        break;

                    case 6: //Spannweite

                        spannweite = sortierteTabelle[1439] - sortierteTabelle[0];

                        Console.WriteLine("\nDie Spannweite beträgt {0:F1}°C.\n", spannweite);

                        break;

                    case 7: //Mittlere Abweichung

                        Console.WriteLine("Die mittlere Abweichung beträgt: {0} °C.", abweichung);

                        
                        break;

                    case 8: //Rangliste der Häufigkeit


                        for (int tempwert = 0; tempwert < haeufigkeit.Length; tempwert++)
                        {
                            Console.Write(mintemp+tempwert + "°C\t" + haeufigkeit[tempwert] +"\t");
                            for (int anzahlwert = 0; anzahlwert < haeufigkeit[tempwert]; anzahlwert++)
                            {
                                Console.Write('|');
                            }
                            Console.Write("\r\n");
                        }
                                                
                        break;

                    case 0:

                        Console.WriteLine("\nSie haben die (0) ausgewählt, mit der Sie das Programm beenden können!");
                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben\n");
                        beendigung = Console.ReadLine();

                        break;
                                    

                }
            

            //Console.Clear();
            Console.WriteLine("Danke, dass Sie Wetterfrosch benutzt haben. Auf Wiedersehen!");

            Console.ReadKey();
                      
            
        }
    }
}
