using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naloga3
{

    //TODO10 dodajte razred Zaposleni
    //TODO10 vsebuje naj naslednje lastnostni:
    //TODO10    id int
    //TODO10    employee_name string
    //TODO10    employee_salary double
    //TODO10    employee_age int

    //TODO15 ustvarite metodo izpisi, ki izpiše Zaposlenega v obliki (oblika zapisa naj bo oblikovana, kot je prikazano spodaj)
    //TODO15       1234123456789012345678912345678912345678
    //             id  naziv                  plača Starost   (poravnano naj bo levo, levo, desno, desno)
    //             1   Zaposleni 1            12000      35
    //             3   Zaposleni 3           112000     125

    class Zaposleni
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public double employee_salary { get; set; }
        public int employee_age { get; set; }

        //!!!!primer konstuktorja
        //v kolikor se lastnos imenuje enako, kot parameter uporabimo rezervirano besedo this
        //  this.lastnost 
        /*   Zaposleni(int id, string name, double sala, int age)
           {
               this.id = id;
               employee_name = name;
               employee_salary = sala;
               employee_age = age;
           }
        //*/

        public void izpisi()
        {
            //formatiranje izpisa
            //-5 leva poravnava
            //+5 desna poravnava
            Console.WriteLine($"{id,-5} {employee_name,-20}{employee_salary,9}{employee_age,8}");
        }
    }


}
