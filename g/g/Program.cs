using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;

using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.IO;
using System.Data;

namespace ав
{


    internal class Program
    {

        public float Ur = 1;
        public int krit = 5;
        static int numMob;
        public bool life = true;
        public static int posY = 1;
        public static int posX = 5;
        public static int AposY;
        public static int AposX;
        public static int IposY;
        public static int IposX;
        public static int DposX;
        public static int DposY;
        static float playerHp;
        static float playerDamage;
        static float artemHp;
        static float artemDamage;
        static float duckDamage;
        static float duckHp;
        static float iskaDamage;
        static float iskaHp;
        static void Main(string[] args)
        {

            Player player = new Player();
            Artem artem = new Artem();
            Iska iska = new Iska();
            Duck duck = new Duck();
            Program program = new Program();
            string trip = Directory.GetCurrentDirectory() + @"\\Map.txt";
            string[] StringMap = File.ReadAllLines(trip);
            string[,] Map = GenerateMap(StringMap, 10, 20);
            RandomItem(ref Map);
            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.Write(Map[i, j]);
                }
                Console.WriteLine();
            }
            

            
            
            while (true)
            {
                if (program.life == true)
                {
                    playerHp = player.Hp * program.Ur;
                    playerDamage = player.Damage * program.Ur;
                    artemHp = artem.Hp * program.Ur;
                    artemDamage = artem.Damage * program.Ur;
                    iskaHp = iska.Hp * program.Ur;
                    iskaDamage = iska.Damage * program.Ur;
                    duckHp = duck.Hp * program.Ur;
                    duckDamage = duck.Damage * program.Ur;
                    PrintMap(ref Map);
                    Console.WriteLine("вы: " + player.name + "\nВаши характеристики: \n дамаг:" + playerDamage + "\n хп:" + playerHp + "\nуровень игрока:" + program.Ur);

                    Console.WriteLine("Враги: ");
                    Console.WriteLine(artem.name + "\n  Damage " + artemDamage + "\n  HP " + artemHp + "\n  Описание: " + artem.opis);
                    Console.WriteLine(iska.name + "\n  Damage " + iskaDamage + "\n  HP " + iskaHp);
                    Console.WriteLine(duck.name + "\n  Damage" + duckDamage + "\n  HP" + duckHp);

                    
                    Console.WriteLine("B: АРТЕМ \nE: Иска \ne: Гусь с Байкала");
                   
                    ////switch (numMob)
                    ////{
                    ////   case 1:
                    ////        Battle(playerHp, artemHp, playerDamage, artemDamage, ref program.Ur);
                    ////        break;
                    ////    case 2:
                    ////        Battle(playerHp, iskaHp, playerDamage, iskaDamage, ref program.Ur);
                    ////        break;
                    ////    case 3:
                    ////        Battle(playerHp, duckHp, playerDamage, duckDamage, ref program.Ur);
                    ////        break;



                    //}




                }
                else if (program.life == false)
                {

                    continue;
                }



            }

        }

        private static string[,] GenerateMap(string[] map, int sizeX, int sizeY)
        {
            var temp = new string[sizeX, sizeY];
            for (int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    switch (map[i][j])
                    {
                        case '#':
                            temp[i, j] = "#";
                            break;
                        case ' ':
                            temp[i, j] = " ";
                            break;
                        case '@':
                            temp[i, j] = "@";
                            break;
                        case 'E':
                            temp[i,j] = "E";
                            break;
                        case 'B':
                            temp[i, j] = "B";
                            break;
                        case 'D':
                            temp[i, j] = "D";
                            break;
                        case 'S':
                            temp[i, j] = "S";
                            break;
                        case 'P':
                            temp[i, j] = "P";
                            break;
                        case 'G':
                            temp[i, j] = "G";
                            break;
                    }
                }
            }
            return temp;
            
        }

        static float Battle(float hpP, float hpM, float damageP, float damageM, ref float Ur)
        {
            Program program = new Program();

            while (true)
            {
                float uronP = Bang();
                float uronM = BangM(numMob);
                hpM = hpM - uronP;
                Thread.Sleep(2000);
                Console.WriteLine("Хп врага" + hpM);
                hpP = hpP - uronM;
                Thread.Sleep(2000);
                Console.WriteLine("Хп игрока" + hpP);
                if (hpM <= 0)
                {
                    Console.WriteLine("ПОБЕДА");
                    Ur++;
                    Console.WriteLine("нажмите клавишу для следующего хода");
                    Console.ReadKey();
                    Console.Clear();
                    break;


                }
                else if (hpP <= 0)
                {
                    Console.WriteLine("ПРОИГРЫШ");
                    program.life = false;
                    Ur = 1;
                    Console.WriteLine("нажмите клавишу для следующего хода");
                    Console.ReadKey();
                    Console.Clear();
                    break;

                }
            }


            return 1;


        }
        static float Bang()
        {
            Player player = new Player();
            Random rnd = new Random();

            Console.WriteLine("Куда бить будем?");
            List<string> organs = new List<string>();
            organs.Add("1 Печень");
            organs.Add("2 Лицо");
            organs.Add("3 Душа");
            organs.Add("4 Нервы");
            Console.WriteLine(organs[0]);
            Console.WriteLine(organs[1]);
            Console.WriteLine(organs[2]);
            Console.WriteLine(organs[3]);
            int num = int.Parse(Console.ReadLine());
            float DamP;
            int an;
            int krit;
            float damage = 1;
            switch (num)
            {
                case 1:
                    Console.WriteLine("Давай тяпнем");
                    DamP = 3;
                    an = rnd.Next(1, 10);
                    krit = rnd.Next(1, 2);
                    if (an == 1)
                    {
                        if (krit == 1)
                        {
                            damage = player.Damage * DamP * 10;
                            Console.WriteLine("КРИТ Х10");
                        }
                        else
                        {
                            damage = player.Damage * DamP;
                        }

                    }
                    else
                    {
                        Console.WriteLine("ПРОМАХ");
                        damage = 0;
                    }
                    break;

                case 2:
                    Console.WriteLine("Хрясь");
                    DamP = 1;
                    an = rnd.Next(1, 10);
                    krit = rnd.Next(1, 2);
                    if (an < 8)
                    {
                        if (krit == 1)
                        {
                            damage = player.Damage * DamP * 10;
                            Console.WriteLine("КРИТ Х10");
                        }
                        else
                        {
                            damage = player.Damage * DamP;
                        }
                    }
                    else
                    {
                        Console.WriteLine("ПРОМАХ");
                        damage = 0;
                    }
                    break;

                case 3:
                    Console.WriteLine("Ты плохой");
                    krit = rnd.Next(1, 2);
                    DamP = 1 / 2;
                    an = rnd.Next(1, 10);


                    if (krit == 1)
                    {
                        damage = player.Damage * DamP * 10;
                        Console.WriteLine("КРИТ Х10");
                    }
                    else
                    {
                        damage = player.Damage * DamP;
                    }

                    break;
                case 4:
                    Console.WriteLine("BRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBRBBRBRBBRBRBRBRBBRBRRRBRBRBRBRBRBRRBRBBRBRBRBRBRRBRBRBR");
                    DamP = 99999;
                    an = rnd.Next(1, 10);
                    krit = rnd.Next(1, 2);
                    if (an == 1)
                    {
                        if (krit == 1)
                        {
                            damage = player.Damage * DamP * 10;
                            Console.WriteLine("КРИТ Х10");
                        }
                        else
                        {
                            damage = player.Damage * DamP;
                        }
                    }
                    else
                    {
                        Console.WriteLine("ПРОМАХ");
                        damage = 0;
                    }
                    break;
            }
            return damage;

        }
        static float BangM(int numMob)
        {
            Random rnd = new Random();
            Artem artem = new Artem();
            Iska iska = new Iska();
            Duck duck = new Duck();
            bool kritB = false;

            int an = rnd.Next(1, 4);
            int orgasn = rnd.Next(1, 2);
            float damage = 1;

            switch (numMob)
            {
                case 1:
                    if (an < 4)
                    {
                        int krit = rnd.Next(1, 5);
                        if (krit == 2)
                        {
                            kritB = true;
                        }
                        switch (orgasn)
                        {
                            case 1:

                                Console.WriteLine("Монср бьет в голову");
                                damage = artem.Damage * (3 / 2);
                                break;
                            case 2:
                                Console.WriteLine("Монстр бьет в тело");
                                damage = artem.Damage * (3 / 4);
                                break;
                        }
                        if (kritB)
                        {
                            damage = damage * 5;
                            Console.WriteLine("Монстр критует Х5");
                        }
                    }
                    break;
                case 2:
                    if (an < 4)
                    {
                        int krit = rnd.Next(1, 5);
                        if (krit == 2)
                        {
                            kritB = true;
                        }
                        switch (orgasn)
                        {
                            case 1:
                                Console.WriteLine("Монср бьет в голову");
                                damage = iska.Damage * (3 / 2);
                                break;
                            case 2:
                                Console.WriteLine("Монстр бьет в тело");
                                damage = iska.Damage * (3 / 4);
                                break;
                        }
                        if (kritB)
                        {
                            damage = damage * 5;
                            Console.WriteLine("Монстр критует Х5");
                        }
                    }
                    break;
                case 3:
                    if (an < 4)
                    {
                        int krit = rnd.Next(1, 5);
                        if (krit == 2)
                        {
                            kritB = true;
                        }
                        switch (orgasn)
                        {
                            case 1:
                                Console.WriteLine("Монср бьет в голову");
                                damage = duck.Damage * (3 / 2);
                                break;
                            case 2:
                                Console.WriteLine("Монстр бьет в тело");
                                damage = duck.Damage * (3 / 4);
                                break;
                        }
                        if (kritB)
                        {
                            damage = damage * 5;
                            Console.WriteLine("Монстр критует Х5");
                        }
                    }
                    break;
            }
            return damage;
        }

        static void PrintMap(ref string[,] Map)
        {
            Player player = new Player();
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (Map[posX - 1, posY] != "#")
                    {
                        Map[posX - 1, posY] = "P";
                        posX--;
                        if (Map[posX+1, posY] == "P")
                        {
                            Map[posX + 1, posY] = " ";
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (Map[posX + 1, posY] != "#")
                    {
                        Map[posX + 1, posY] = "P";
                        posX++;
                        if (Map[posX - 1, posY] == "P")
                        {
                            Map[posX - 1, posY] = " ";
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (Map[posX, posY-1] != "#")
                    {
                        Map[posX, posY-1] = "P";
                        posY--;
                        if (Map[posX, posY+1] == "P")
                        {
                            Map[posX, posY+1] = " ";
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (Map[posX, posY + 1] != "#")
                    {
                        
                        Map[posX, posY + 1] = "P";
                        posY++;

                        if (Map[posX, posY - 1] == "P")
                        {
                            Map[posX, posY - 1] = " ";
                        }
                    }
                    break;


            }
            Console.Clear();

            for (int i = 0; i < Map.GetLength(0); i++)
            {
                for (int j = 0; j < Map.GetLength(1); j++)
                {
                    Console.Write(Map[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void RandomItem(ref string[,] Map)
        {
            Random rnd = new Random();
            string E1 = "e";
            string E2 = "E";
            string G = "G";
            string S = "S";
            while (true)
            {
                // гусь на рандом
                int a = rnd.Next(1,8);
                int b = rnd.Next(1,18);
                if (Map[a,b] != "#")
                {
                    Map[a,b] = E1;
                    break;
                }
            }
            while (true)
            {
                // гусь на рандом
                int a = rnd.Next(1, 8);
                int b = rnd.Next(1, 18);
                if (Map[a, b] != "#")
                {
                    Map[a, b] = E2;
                    break;
                }
            }
            while (true)
            {
                // Isca на рандом
                int a = rnd.Next(1, 8);
                int b = rnd.Next(1, 18);
                int fart = rnd.Next(1, 4);
                if(fart == 1)
                {
                    if (Map[a, b] != "#")
                    {
                        Map[a, b] = G;
                        break;
                    }
                    break;
                }
                break;
            }
            while (true)
            {
                // Isca на рандом
                int a = rnd.Next(1, 8);
                int b = rnd.Next(1, 18);
                int fart = rnd.Next(1,4);
                if (fart == 3)
                {
                    if (Map[a, b] != "#")
                    {
                        Map[a, b] = S;
                        break;
                    }
                    break;
                }
                break;
            }

        }
    }

}
abstract class Legends
{
    string opis;
    string name;
    float Damage;
    float Hp;
}

class Nikita
{
    public string opis = "Имба чел, легенда нумбер ту";
    public string name = "Никита";
    public float Damage = 10000;
    public float Hp = 50;


}

class Artem : Legends
{
    public Artem()
    {
        Damage = Damage * 5;
    }
    public string opis = "АРТЕМ - великий воин которому противостоит его же вебка";
    public string name = "АРТЕМ";
    public float Damage = 25;
    public float Hp = 1000;
    public int posX = 5;
    public int posY= 8;
}
class Iska
{
    public string name = "Иска";
    public float Damage = 1;
    public float Hp = 200;
    public int posX;
    public int posY;
}
class Duck
{
    public string name = "ГУСЬ с Байкала";
    public float Damage = 5;
    public float Hp = 10;
    public int posX;
    public int posY;
}
class Player
{
    public string name = "Вебка АРТЕМА";
    public float Damage = 10;
    public float Hp = 100;
    public int posX = 5;
    public int posY = 1;
}