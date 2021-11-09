using System;

namespace Naloga2
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("S T R U C T");
            //TODO30a: ustvarimo tocS tipa TockaS
            TockaS tocS = new TockaS();

            //TODO30b: izpišemo trenutno vrednost tocS z uporabo ustvarjene metode
            Console.WriteLine($"Osnovna tocka X={tocS.X}, Y={tocS.Y}");
            tocS.izpisi();

            //TODO40: kličemo premikS za
            premakniS(tocS, 2, 2);
            //TODO40: izpišemo trenutno vrednost tocS
            Console.WriteLine($"Premaknjena tocka X={tocS.X}, Y={tocS.Y}");
            tocS.izpisi();



            Console.WriteLine($"\n\nC L A S S");
            //TODO50: ustvarimo tocC tipa TockaS
            TockaC tocC = new TockaC();

            //TODO: izpišemo trenutno vrednost tocC
            Console.WriteLine($"Premaknjena tocka X={tocC.X}, Y={tocC.Y}");
            tocC.izpisi();
            //TODO60: kličemo premikC
            premakniC(tocC, 2, 2);
            //TODO70: izpišemo trenutno vrednost tocC
             Console.WriteLine($"Premaknjena tocka X={tocC.X}, Y={tocC.Y}");
            tocC.izpisi();


            //!!! uporaba ustvarjenega operatorja + za stuct
            //primer seštevanja
            TockaS t1 = new TockaS();
            TockaS t2 = new TockaS();
            premakniS(t1, 2, 5);
            premakniS(t2, 2, 5);

            TockaS t3 = new TockaS();
            t3 = t1 + t2;

            //primer uporabe operatorja + za Class
            TockaC tC1 = new TockaC();
            TockaC tC2 = new TockaC();
            premakniC(tC1, 24, 21);
            premakniC(tC2, 5, 12);
            tC1 = tC1 + tC2;
            tC1.izpisi();

        }

        //TODO10 ustvarite TockaS tipa struct, v njem določite public spremenljivki tipa int X in Y
        //TODO10 ustvarite metodo izpisi, ki izpiše vrednost točke v obliki:  "(  X,  Y)"
        public struct TockaS
        {
            public int X;  //
            public int Y;

            public void izpisi()
            {
                Console.WriteLine($"Tocka ({X,3},{Y,3})");
            }

            //!!!!primer ustvarjanja operatorja +
            //s tem dobimo v programu možnost, da dve točki seštevamo  t1 + t2
            public static TockaS operator +(TockaS t1, TockaS t2)
            {
                TockaS t = new TockaS();
                t.X = (t1.X + t2.Y) / 2;
                t.Y = (t1.X + t2.Y) / 2;

                return t;
            }
        }


        //TODO20 ustvarite razred TockaC, v njem določite public spremenljivki tipa int X in Y
        //TODO20 ustvarite metodo izpisi, ki izpiše vrednost točke v obliki:  "(  X,  Y)"
        public class TockaC
        {
            public int X;
            public int Y;

            public void izpisi()
            {
                Console.WriteLine($"Tocka ({X,3},{Y,3})");
            }
            public static TockaC operator +(TockaC t1, TockaC t2)
            {
                TockaC t = new TockaC();
                t.X = (t1.X + t2.Y) / 2;
                t.Y = (t1.X + t2.Y) / 2;

                return t;
            }

        }


        //TODO25 ustvarite statično metodo premakniS, ki ne vrača ničesar
        //TODO25 kot vhodni parameter dobi: TockaS tocka, int premikX, int premikY
        //TODO25 vhodnemu parametru tocka.X pristeje premikX (analogono za Y)
        //TODO25 izpište vrednost tocka.X in tocka.Y
        static public void premakniS(TockaS tocka, int premikX, int premikY)
        {
            tocka.X += premikX;
            tocka.Y += premikY;
            Console.WriteLine($"premakniS X={tocka.X}, Y={tocka.Y}");
        }

        //TODO27 kot za metodo premakniS naredimo metodo premakniC, le da je vhodni parameter tocka tipa TockaC
        //TODO27 po premiku izpišite trenutno vrednost tocke
        static public void premakniC(TockaC tocka, int premikX, int premikY)
        {
            tocka.X += premikX;
            tocka.Y += premikY;
            Console.WriteLine($"premakniC X={tocka.X}, Y={tocka.Y}");
        }
    }
}
