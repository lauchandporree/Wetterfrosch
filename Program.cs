using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Intrinsics.X86;

namespace Wetterfrosch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklaration der benötigten Variablen            
            int uhrzeit = 0, minute = 0, stunde = 0, tag = 1, monat = 1, jahr = 2020, auswahlEingabe = 0; // Soll später in Minuten hochgerechnet werden bis 1439

            double temperatur = 0, mittelwertTag = 0, median, spannweite;// Als double deklariert, um Kommazahlen zu erlauben
            
            Random zufall = new Random();
            
            string beendigung = "";

            //DateTime wetterfrosch1 = new DateTime(jahr, monat, tag, stunde, minute, 0);

            //Anlegen eines Arrays für die Uhrzeit und Temperaturwerte
            double[] tabelle = new double[1440];


            for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
            {
                temperatur = zufall.Next(-10, 40); // Es wurde eine Spanne von typischen europäischen Temperaturwerten gewählt
                temperatur = temperatur + zufall.NextDouble();
                tabelle[uhrzeit] = temperatur;
            }

            //Sortierte Form des Arrays
            double[] sortedTabelle = (double[])tabelle.Clone();
            System.Array.Sort(sortedTabelle);

            //Berechnung des Mittelwerts
            for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
            {
                mittelwertTag += tabelle[uhrzeit] / tabelle.Length;
            }


            // Programmoberfläche mit Funktionen ausstatten
            do
            {
                Console.WriteLine("Herzlich Willkommen beim Wetterfrosch");
                Console.WriteLine("Wählen Sie bitte eine der nachfolgenden Funktionen aus:");
                Console.WriteLine("(1) Ausgabe des Mittelwertes und der Minutenwerte");
                Console.WriteLine("(2) Geben Sie die Werte mit einer Nachkommastelle zeilenweise aus, im Format Uhrzeit Temperaturwert z.B. 9:20 - 9, 8°C");
                Console.WriteLine("(3) Ermitteln Sie den Minimalwert (niedrigsten Temperaturwert) des Tages.");
                Console.WriteLine("(4) Ermitteln Sie den Maximalwert (höchsten Temperaturwert) des Tages.");
                Console.WriteLine("(5) Berechnen Sie den Median der Messwerte.");
                Console.WriteLine("(6) Berechnen Sie die Spannweite der Messwerte.");
                Console.WriteLine("(7) Berechnen Sie die mittlere Abweichung der Messwerte.");
                Console.WriteLine("(8) Berechnen Sie eine Rangliste der Häufigkeit der Messwerte.");
                Console.WriteLine("(0) BEENDIGUNG DES PROGRAMMS");
                Console.WriteLine("Geben Sie nachfolgend eine der Optionen als Zahl ohne Klammer ein:");
                
                    auswahlEingabe = Int32.Parse(Console.ReadLine());
                //auswahlEingabe = Convert.ToInt32(Console.ReadLine());

                switch (auswahlEingabe)
                {
                    case 1:
                        //double[] tabelle = new double[1440];

                        for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Die Temperatur betrug {0:F0}°C bei Minute {1}", tabelle[uhrzeit], uhrzeit);
                        }
                        /*for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
                        {
                            mittelwertTag += tabelle[uhrzeit] / tabelle.Length;
                        }*/
                        Console.WriteLine("Der Mittelwert des Tages lag bei {0:F0}°C", mittelwertTag);

                        Console.WriteLine("Möchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();

                        break;
                    case 2:

                        for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
                        {
                            stunde = uhrzeit / 60;
                            minute = uhrzeit % 60;
                            DateTime wetterfrosch1 = new DateTime(jahr, monat, tag, stunde, minute, 0);
                            Console.WriteLine();
                            Console.WriteLine("Die Temperatur um " + wetterfrosch1.ToString("HH:mm", CultureInfo.InvariantCulture) + " Uhr betrug {0:F1}°C", tabelle[uhrzeit]);
                        }
                        /*for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
                        {
                            mittelwertTag += tabelle[uhrzeit] / tabelle.Length;
                        }*/
                        Console.WriteLine("Der Mittelwert des Tages lag bei {0:F1}°C", mittelwertTag);

                        Console.WriteLine("Möchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();
                        break;
                    case 3:

                        Console.WriteLine("\nDer niedrigste Temperaturwert lag bei {0:F1}°C\n", sortedTabelle[0]);

                        Console.WriteLine("Möchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();
                        break;
                    case 4:

                        Console.WriteLine("\nDer höchste Temperaturwert lag bei {0:F1}°C\n", sortedTabelle[1439]);

                        Console.WriteLine("Möchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();
                        break;
                    case 5:

                        median = sortedTabelle[(sortedTabelle.Length / 2)];

                        Console.WriteLine("\nDer Median liegt bei {0}°C \n", median);

                        Console.WriteLine("Möchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();
                        break;
                    case 6:

                        spannweite = sortedTabelle[1439] - sortedTabelle[0];

                        Console.WriteLine("\nDie Spannweite beträgt {0:F1}°C.\n", spannweite);

                        Console.WriteLine("Möchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();
                        break;
                    case 7:

                        Console.WriteLine("Möchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();
                        break;
                    case 8:

                        Console.WriteLine("Möchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();
                        break;
                    case 0:
                        
                        Console.WriteLine("Möchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Möchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();
                        break;


                }
            }
            while (beendigung != "N") ;

            //Console.Clear();
            Console.WriteLine("Danke, dass Sie Wetterfrosch benutzt haben. Auf Wiedersehen!");

            Console.ReadKey();

            Console.ReadKey();
            /*


          
            double[] sortedTabelle = (double[])tabelle.Clone();
            System.Array.Sort(sortedTabelle);
            foreach(var i in sortedTabelle)
            {
                Console.WriteLine();
                Console.WriteLine(i);
            }
            */
            

            
            Console.ReadKey();
        }
    }
}
