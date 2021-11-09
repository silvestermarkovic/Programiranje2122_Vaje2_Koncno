using System;
using System.Collections.Generic;
using System.Linq;

namespace Naloga1
{
    //TODO10 ustvarite razred Indexers
    class Indexers
    {

        //TODO20 dodajte Dictionary osebe, ki vsebuje naziv (string) in starost (int)
        public Dictionary<string, int> osebe = new Dictionary<string, int>();

        //TODO20 ustvarite propery steviloDodajanj (get, private set) s privzetno vrednostjo 0
        public int steviloDodajanj { get; private set; } = 0;


        //!!!! demo uporabe statične deklaracije lastnosti (vrednost za vse instancer razreda je enaka!!!)
        public static int steviloDodajanjStatic { get; private set; } = 0;


        //če je seznam osebe private moramo imeti metodo
        public int steviloZapisov()
        {
            return osebe.Count();
        }

        //primer static steviloDodajanj
        public int vrniSteviloDodajanj()
        {
            return steviloDodajanj;
        }
        public int vrniSteviloDodajanjStatic()
        {
            return steviloDodajanjStatic;
        }
        //TODO30 ustvarite metodo dodajOsebo (vhodni parameter je naziv (string) in starost (int))
        //TODO30 poveča propery steviloDodajanj ob vsakem klicu
        //TODO30 Če je parameter starost >= 18 doda osebo  v kolikor ne obstaja, če morda oseba že obstaja
        //TODO30 popravi starost osebe (prepiše)
        public void dodajOsebo(string naziv, int starost)
        {
            steviloDodajanj += 1;
            steviloDodajanjStatic += 1;
            if (starost >= 18)
            {
                if (!osebe.ContainsKey(naziv))
                {
                    osebe.Add(naziv, starost);
                }
                else
                {
                    osebe[naziv] = starost;
                }
            }
        }


        //TODO40 ustvarite metodo vrniPrvoOsebo, ki vrne prvo osebo iz slovarja in njeno starost v obliki "naziv - starost"
        //TODO40 v kolikor v slovarju ni zapisov vrnite "" prazen string
        //TODO40 pomoč: var prvaOseba = osebe.First() ali uporabite ElementAt(pozicija)
        public string vrniPrvoOsebo()
        {
            //opcija 1
            if (osebe.Count > 0)
            {
                return (osebe.ElementAt(0).Key + " - " + osebe.ElementAt(0).Value);
            }

            if (osebe.Count > 0)
            {

                var prvaOseba = osebe.First();
                return (prvaOseba.Key + " - " + prvaOseba.Value);
            }
            else
            {
                return "";
            }

        }


        //TODO45dod ustvarite metodo izpisiOsebeNaziv, ki izpiše vse Osebe po nazivu
        //TODO45dod foreach uporabite tip KeyValuePair<string, int> 
        public void izpisiOsebeNaziv()
        {
            Console.WriteLine("============= Sortirano po nazivu:");
            foreach (KeyValuePair<string, int> oseba in osebe.OrderBy(par => par.Key))
            {
                Console.WriteLine($"{oseba.Key,-10}  {oseba.Value,3}");
                Console.WriteLine("{0}  {1}", oseba.Key, oseba.Value);

                //Poglejte String Formati
            }

        }

        //TODO48dod ustvarite metodo izpisiOsebeStarosti, ki izpiše vse Osebe po nazivu
        //TODO48dod foreach uporabite tip KeyValuePair<string, int> 
        public void izpisiOsebeStarosti()
        {

            Console.WriteLine("============= Sortirano po starosti:");
            foreach (KeyValuePair<string, int> oseba in osebe.OrderBy(par => par.Value))
            {
                Console.WriteLine($"{oseba.Key,-10}  {oseba.Value,3}");
            }
        }

        //TODO49dod ustvarite metodo izpisiStarejseOd, ki izpiše vse Osebe po nazivu
        //TODO49dod foreach uporabite tip KeyValuePair<string, int> 
        public void izpisiStarejseOd(int pStarost)
        {
            Console.WriteLine($"============= Starejši od {pStarost}, sortirano po starosti:");
            foreach (KeyValuePair<string, int> oseba in osebe.Where(aa => (aa.Value >= pStarost)).OrderBy(par => par.Value))
            {
                Console.WriteLine($"{oseba.Key,-10} \t {oseba.Value,3}");
            }

            //način2
            foreach (KeyValuePair<string, int> oseba in osebe.OrderBy(par => par.Value))
            {
                if (oseba.Value >= pStarost)
                {
                    Console.WriteLine($"{oseba.Key,-10}  {oseba.Value,3}");
                }
            }
        }

    }
}
