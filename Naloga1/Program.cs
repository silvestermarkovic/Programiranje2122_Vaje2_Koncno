using System;
using System.Linq;

namespace Naloga1
{
    class Program
    {
        static void Main(string[] args)
        {

            //TODO50 ustvaritite spremenljivko z imom indekserji tipa Indexers
            Indexers indekserji = new Indexers();

            //TODO50 dodajte nekaj 6+ oseb, s poljubnimi imeni (vsaj 1 naj se podvoji in ena naj bo mlajša od 18 let)
            //TODO50 izpišite vse

            indekserji.dodajOsebo("Martin", 99);
            indekserji.dodajOsebo("Silvester", 40);
            indekserji.dodajOsebo("Marko", 58);
            indekserji.dodajOsebo("Janez", 76);
            indekserji.dodajOsebo("Martin", 29);
            indekserji.dodajOsebo("Jože", 15);
            indekserji.dodajOsebo("Martin", 18);
            indekserji.dodajOsebo("Marko2", 34);
            indekserji.dodajOsebo("Janez", 67);

            //TODO60 izpisite vrednost Število dodajanj steviloDodajanj in število zapisov v slovarju
            Console.WriteLine($"Število dodajanj: {indekserji.vrniSteviloDodajanj()} Število zapisov: {indekserji.osebe.Count()}");

            //TODO60 izpisite vrednost, ki jo vrnem metoda vrniPrvoOsebo
            Console.WriteLine(indekserji.vrniPrvoOsebo());

            //TODO70dod kliči metodo, ki izpiše seznam po nazivu
            indekserji.izpisiOsebeNaziv();
            //TODO70dod kliči metodo, ki izpiše seznam po starosti
            indekserji.izpisiOsebeStarosti();

            //TODO70dod kliči metodo, ki izpiše seznam starejše od 30 let
            indekserji.izpisiStarejseOd(30);



            //--------------------------------------------------
            //!!primer statične lastnosti v razredu
            Indexers test1 = new Indexers();
            Indexers test2 = new Indexers();
            Console.WriteLine($"Število dodajanj: {test1.vrniSteviloDodajanj()} Število dodajanj static: {test1.vrniSteviloDodajanjStatic()}  Število zapisov: {test1.steviloZapisov()}");
            Console.WriteLine($"Število dodajanj: {test2.vrniSteviloDodajanj()} Število dodajanj static: {test2.vrniSteviloDodajanjStatic()}  Število zapisov: {test2.steviloZapisov()}");

            test1.dodajOsebo("Martin", 99);
            test1.dodajOsebo("Silvester", 40);
            test1.dodajOsebo("Marko", 58);
            test1.dodajOsebo("Janez", 76);
            test2.dodajOsebo("Marwtin", 99);
            test2.dodajOsebo("Silvwester", 40);
            test1.dodajOsebo("Janez", 76);
            test2.dodajOsebo("Marwtin", 99);

            Console.WriteLine($"Število dodajanj: {test1.vrniSteviloDodajanj()} Število dodajanj static: {test1.vrniSteviloDodajanjStatic()}  Število zapisov: {test1.steviloZapisov()}");
            Console.WriteLine($"Število dodajanj: {test2.vrniSteviloDodajanj()} Število dodajanj static: {test2.vrniSteviloDodajanjStatic()}  Število zapisov: {test2.steviloZapisov()}");

        }
    }
}
