using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Runtime.Intrinsics.X86;
/// <summary>
/// Victor Weilemann
/// IS 119 - AWE - Kappel
/// BfArM - Bundesinstitut fuer Arzneimittel und Medizinprodukte
/// 17.08.2020
/// </summary>
namespace Wetterfrosch
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklaration der benötigten Variablen            
            int uhrzeit = 0, minute = 0, stunde = 0, tag = 1, monat = 1, jahr = 2020, auswahlEingabe = 0, mintemp = -10, maxtemp = 40; // Soll später in Minuten hochgerechnet werden bis 1439

            double temperatur = 0, mittelwertTag = 0, median, spannweite, abweichung, summeAbweichung;// Als double deklariert, um Kommazahlen zu erlauben
            
            Random zufall = new Random();
            
            string beendigung = "";

            //Anlegen eines Arrays für die Uhrzeit und Temperaturwerte
            double[] tabelle = new double[1440];


            for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
            {
                temperatur = zufall.Next(mintemp, maxtemp); // Es wurde eine Spanne von typischen europäischen Temperaturwerten gewählt
                temperatur = temperatur + zufall.NextDouble(); // Hinzufügen von Nachkommastellen
                tabelle[uhrzeit] = temperatur;
            }

            //Sortierte Form des Arrays
            double[] sortedTabelle = (double[])tabelle.Clone();
            System.Array.Sort(sortedTabelle); // Verwendung der Operation System.Array.Sort um die Tabelle zu sortieren

            //Berechnung des Mittelwerts
            for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
            {
                mittelwertTag += tabelle[uhrzeit] / tabelle.Length;
            }

            //Berechnung der mittleren Abweichung
            
            summeAbweichung = 0;

            for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
            {
                summeAbweichung += tabelle[uhrzeit] - mittelwertTag;
            }

            abweichung = summeAbweichung / tabelle.Length;

            //Berechnung der Rangliste der Häufigkeit der Werte

            int[] haeufigkeit = new int[maxtemp-mintemp+1];

            for (uhrzeit =0; uhrzeit < tabelle.Length; uhrzeit++)
            {
                var wert = tabelle[uhrzeit];
                var wertGerundet = (int)Math.Round(wert)-mintemp;
                haeufigkeit[wertGerundet]++;
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
                
                //Einfügen eines Try-Catch um ein Abbrechen bei Falscheingabe zu verhindern
                try
                { 
                auswahlEingabe = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\nBitte geben Sie nur eine Zahl zwischen (0) und (8) ein!\n");
                }
                    




                switch (auswahlEingabe)
                {
                    case 1: //Ausgabe Temperatur bei Minutenwerte
                        

                        for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Die Temperatur betrug {0:F0}°C bei Minute {1}", tabelle[uhrzeit], uhrzeit);
                        }
                        
                        Console.WriteLine("Der Mittelwert des Tages lag bei {0:F0}°C", mittelwertTag);

                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben)");
                        beendigung = Console.ReadLine();

                        break;

                    case 2: //Ausgabe Uhrzeit und Temperatur mit Nachkommastelle

                        for (uhrzeit = 0; uhrzeit < tabelle.Length; uhrzeit++)
                        {
                            stunde = uhrzeit / 60;
                            minute = uhrzeit % 60;
                            DateTime wetterfrosch1 = new DateTime(jahr, monat, tag, stunde, minute, 0); // Verwendung der DateTime-Funktion, um eine genauere Ausgabe der Zeit zu ermöglichen
                            Console.WriteLine();
                            Console.WriteLine("Die Temperatur um " + wetterfrosch1.ToString("HH:mm", CultureInfo.InvariantCulture) + " Uhr betrug {0:F1}°C", tabelle[uhrzeit]);
                        }
                        
                        Console.WriteLine("Der Mittelwert des Tages lag bei {0:F1}°C", mittelwertTag);

                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben\n");
                        beendigung = Console.ReadLine();

                        break;

                    case 3: //Minimalwert

                        Console.WriteLine("\nDer niedrigste Temperaturwert lag bei {0:F1}°C\n", sortedTabelle[0]);

                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben\n");
                        beendigung = Console.ReadLine();

                        break;

                    case 4: // Maximalwert

                        Console.WriteLine("\nDer höchste Temperaturwert lag bei {0:F1}°C\n", sortedTabelle[1439]);

                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben\n");
                        beendigung = Console.ReadLine();

                        break;

                    case 5: // Median

                        median = sortedTabelle[(sortedTabelle.Length / 2)];

                        Console.WriteLine("\nDer Median liegt bei {0}°C \n", median);

                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben\n");
                        beendigung = Console.ReadLine();

                        break;

                    case 6: //Spannweite

                        spannweite = sortedTabelle[1439] - sortedTabelle[0];

                        Console.WriteLine("\nDie Spannweite beträgt {0:F1}°C.\n", spannweite);

                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben\n");
                        beendigung = Console.ReadLine();

                        break;

                    case 7: //Mittlere Abweichung

                        Console.WriteLine("Die mittlere Abweichung beträgt: {0} °C.", abweichung);

                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben\n");
                        beendigung = Console.ReadLine();

                        break;

                    case 8: //Rangliste der Häufigkeit

                        Console.WriteLine("Die Rangliste der Häufigkeit sieht folgendermaßen aus:");

                        for (int temperaturWert = 0; temperaturWert < haeufigkeit.Length; temperaturWert++)
                        {
                            Console.Write(mintemp+temperaturWert + "°C\t" + haeufigkeit[temperaturWert] +"\t");
                            for (int anzahlTempWert = 0; anzahlTempWert < haeufigkeit[temperaturWert]; anzahlTempWert++)
                            {
                                Console.Write('|');
                            }
                            Console.Write("\r\n");
                        }

                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben\n");
                        beendigung = Console.ReadLine();

                        break;

                    case 0: //Beendigung des Programms

                        Console.WriteLine("\nSie haben die (0) ausgewählt, mit der Sie das Programm beenden können!");
                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben\n");
                        beendigung = Console.ReadLine();

                        break;

                    default: // Falls eine Falscheingabe erfolgt, wird der Benutzer zurückgeleitet

                        Console.WriteLine("\nBitte geben Sie nur eine Zahl zwischen (0) und (8) ein!");
                        Console.WriteLine("\nMöchten Sie eine weitere Aufgabe bearbeiten?");
                        Console.WriteLine("Bitte antworten Sie mit (J)a oder (N)ein!");
                        Console.WriteLine("Antwort ohne Klammer angeben\n");
                        beendigung = Console.ReadLine();

                        break;


                }
            }
            while (beendigung != "N") ; // Solange kein N eingegeben wird, läuft die Aufgabe weiter


            // Optische Beendigung des Programms 
            Console.Clear();
            Console.WriteLine("\n############################################################");
            Console.WriteLine("\nDanke, dass Sie Wetterfrosch benutzt haben. Auf Wiedersehen!\n");
            Console.WriteLine("############################################################\n");

            Console.ReadKey();
                      
            
        }
    }
}
