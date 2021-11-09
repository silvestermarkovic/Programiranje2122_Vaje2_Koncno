using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Naloga3
{
    class Program
    {
        static void Main(string[] args)
        {


            //TODO30 ustvari seznam tipa List<Zaposleni>

            List<Zaposleni> seznam = new List<Zaposleni>();

            //TODO31 dodaj 5 zaposlenih ročno!!

            seznam.Add(new Zaposleni() { id = 100, employee_name = "Naziv 100", employee_age = 45, employee_salary = 30000 });
            seznam.Add(new Zaposleni() { id = 101, employee_name = "Naziv 101", employee_age = 55, employee_salary = 45000 });
            seznam.Add(new Zaposleni() { id = 102, employee_name = "Naziv 102", employee_age = 60, employee_salary = 39000 });
            seznam.Add(new Zaposleni() { id = 103, employee_name = "Naziv 103", employee_age = 48, employee_salary = 8000 });
            seznam.Add(new Zaposleni() { id = 104, employee_name = "Naziv 104", employee_age = 74, employee_salary = 19000 });

            //TODO36 kličite metodo, ki izpiše seznam zaposlenih
            izpisi_seznam(seznam);


            //TODO38 ustvarite spremenljivko povprecnaplaca placa
            //TODO38 iz seznama iračunajte povprečno plačo in jo shranite v ustvarjeno spremenljvko
            //TODO38 izračunano vrednost izpišite "Povprečna plača: "
            double povprecnaplaca = seznam.Average(s => s.employee_salary);
            Console.WriteLine("Povprečna plača: " + String.Format("{0}", povprecnaplaca));


            //TODO40
            //izpišite vse osebe z nadpovprečno plačno
            /*var seznamnadpovpresno = from sez in seznam
                                     where sez.employee_salary > povprecnaplaca
                                     select sez;  */

            seznam.ForEach(s => { if (s.employee_salary > 15000) { s.izpisi(); } });

            //2. način
            foreach (Zaposleni zap in seznam)
            {
                if (zap.employee_salary > 15000)
                {
                    zap.izpisi();
                }
            }

            Console.WriteLine("BRANJE JSON");
            //TODO62 uporabite dopolnjeno metodo Vrnivsebino in jo kličite
            //TODO62 s parametrov http://dummy.restapiexample.com/api/v1/employees
            //TODO62 vsebino, ki jo vrne metoda shranite v spremenljivko vsebina tipa stirng
            string vsebina = Vrnivsebino("http://dummy.restapiexample.com/api/v1/employees");


            //TODO63 izpišite vsebino prebrane strani (kasneje lahko izključite),
            //TODO63 vsebino mora biti enaka vsebini, če jo kličete s brsklalnikom
            Console.WriteLine($"{vsebina}");



            //TODO65 poglejte kodo in dopišite komentar
            JToken token = JToken.Parse(vsebina);
            JArray zaposleni = (JArray)token.SelectToken("data");
            foreach (JToken zap in zaposleni)
            {
                Console.Write("id: " + zap["id"] + " " + zap["id"]);
                Console.Write(" employee_name: " + zap["employee_name"]);
                Console.Write(" employee_salary: " + zap["employee_salary"]);
                Console.Write(" employee_age: " + zap["employee_age"]);
                Console.WriteLine();


                //TODO66 prebrano zaposlene dodajte v že obstoječi seznam zaposlenih
                seznam.Add(new Zaposleni()
                {
                    id = (int)zap["id"],
                    employee_name = (string)zap["employee_name"],
                    employee_age = (int)zap["employee_age"],
                    employee_salary = (double)zap["employee_salary"]
                });

            }


            //TODO70 izpišite vse trenutno zaposlene v seznamu
            izpisi_seznam(seznam);
            /* drugi način
            foreach (Zaposleni zap in seznam)
            {
                Console.WriteLine($"{zap.id},{zap.employee_name},{zap.employee_salary},{zap.employee_age} ");
            }
            //*/
            Console.WriteLine("Zaposleni s plačo od 10000 do 40000:");


            //TODO81 uporabite metodo izpisi seznam TODO35 in vrni_zaposlene_filter (TODO80)
            //TODO81 izpisite vse zaposlene, ki zaslužijo med 10000 in 40000
            izpisi_seznam(vrni_zaposlene_filter_placa(seznam, 10000, 40000));


            //TODO86  uporabite metodo izpisi seznam TODO35 in vrni_zaposlene_filter (TODO85)
            //TODO86 izpiši zaposlene nad 40 let
            Console.WriteLine("Zaposleni nad 40let:");
            izpisi_seznam(vrni_zaposlene_filter_starost(seznam, 40, 99999));




            //DODATNO NAMESTO FOR UPORABI WHERE
            Console.WriteLine("Zaposleni nad 40let Select:");
            var seznam_nad40 = from s in seznam
                               where s.employee_age >= 40 && s.employee_age < 999999
                               select s;
            foreach (Zaposleni zap in seznam_nad40)
            {
                Console.WriteLine($"{zap.id},  {zap.employee_name}, {zap.employee_salary}, {zap.employee_age }");
            }

            Console.WriteLine("Zaposleni nad 40let SelectLamda:");
            var seznam_nad40_lamda = seznam.Where(s => s.employee_age > 40 && s.employee_age < 999999);
            foreach (Zaposleni zap in seznam_nad40)
            {
                Console.WriteLine($"{zap.id},  {zap.employee_name}, {zap.employee_salary}, {zap.employee_age }");
            }

        }

        //TODO60 metodo dopolnite tako:
        //TODO60 -da bo URL podan kot parameter
        //TODO60 -da bo metoda vračala vsebino
        static string Vrnivsebino(string url)
        {
            //url = "http://dummy.restapiexample.com/api/v1/employees";
            string vsebina = "";
            using (var webClient = new System.Net.WebClient())
            {
                vsebina = webClient.DownloadString(url);
            }
            return vsebina;
        }


        //TODO80 ustvarite statično metodo vrni_zaposlene_filter_placa, ki vrne seznam List<Zaposleni>
        //TODO80 metoda kot parameter dobi List<Zaposleni>, placaOd in placaDo
        //TODO80 ustvari nov seznam!!, ki ga vrne, v seznamu so zaposleni s plačo v podanem območju
        static List<Zaposleni> vrni_zaposlene_filter_placa(List<Zaposleni> p_seznam, double placa_od, double placa_do)
        {
            List<Zaposleni> sez = new List<Zaposleni>();
            foreach (Zaposleni zap in p_seznam)
            {
                if (zap.employee_salary >= placa_od && zap.employee_salary <= placa_do)
                {
                    sez.Add(zap);
                }
            }
            return sez;
        }


        //TODO85 ustvarite statično metodo vrni_zaposlene_filter_starost, ki vrne seznam List<Zaposleni>
        //TODO85 metoda kot parameter dobi List<Zaposleni>, starostOd in starostDo
        //TODO85 ustvari nov seznam!!, ki ga vrne, v seznamu so zaposleni stari v podanem območju

        static List<Zaposleni> vrni_zaposlene_filter_starost(List<Zaposleni> p_seznam, double starost_od, double starost_do)
        {
            List<Zaposleni> sez = new List<Zaposleni>();

            foreach (Zaposleni zap in p_seznam)
            {
                if (zap.employee_age >= starost_od && zap.employee_age <= starost_do)
                {
                    sez.Add(zap);
                }
            }
            //dodatek
            //2.način
            //p_seznam.ForEach(zap => { if (zap.employee_age >= starost_od && zap.employee_age <= starost_do)  sez.Add(zap);  });
            //3.način
            //return p_seznam.Where(zap => (zap.employee_age >= starost_od && zap.employee_age <= starost_do)).ToList();

            return sez;
        }


        //TODO35 ustvarite metodo izpisi_seznam, ki izpiše seznam tipa List<Zaposleni>
        //TODO35 za izpis posameznega zapis uprabite metodo, ki ste jo ustvarili v razredu Zaposleni
        static void izpisi_seznam(List<Zaposleni> p_seznam)
        {
            foreach (Zaposleni zap in p_seznam)
            {
                zap.izpisi();
                //Console.WriteLine($"{zap.id},  {zap.employee_name}, {zap.employee_salary}, {zap.employee_age }");
            }
        }
    }


}
