using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Puchamon
{
    class Program
    {
        private static string[] names_pkm = new string[]
        {
                "Firant",
                "Hydrant",
                "Eleplant",
                "Salir"
        };

        private static int x, y;
        static void Main(string[] args)
        {
            //declaraciones
            Pkm lagarto = new Pkm(27, 2, 7, 8, 1, "Fuego", "Firant  ");
            Pkm tortuga = new Pkm(26, 4, 9, 11, 2, "Agua", "Hydrant ");
            Pkm rana = new Pkm(29, 7, 7, 6, 3, "Planta", "Eleplant");

            bool turn = true, loop = true;
            int cnt = 0;

            Pkm[] p_equip_pkm = new Pkm[1];
            Pkm[] e_equip_pkm = new Pkm[1];

            //programa
            ConsoleKeyInfo tecla;

            Console.CursorVisible = false;

            Console.WriteLine("Puchamon Battle");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Selecciona tu puchamon:" + System.Environment.NewLine);

            x = Console.CursorLeft;
            y = Console.CursorTop;

            string resultado = Menu(names_pkm, cnt);

            //Elección del usuario
            while (loop)
            {
                
                while ((tecla = Console.ReadKey(true)).Key != ConsoleKey.Enter)
                {
                    switch (tecla.Key)
                    {
                        case ConsoleKey.DownArrow:
                            if (cnt == names_pkm.Length - 1) continue;
                            cnt++;
                            break;

                        case ConsoleKey.UpArrow:
                            if (cnt == 0) continue;
                            cnt--;
                            break;

                        default:
                            break;
                    }
                    Console.CursorLeft = x;
                    Console.CursorTop = y;

                    resultado = Menu(names_pkm, cnt);
                }

                switch (cnt)
                {
                    case 0:
                        Console.WriteLine("has elegido a Firant");

                        p_equip_pkm[0] = lagarto;
                        loop = false;

                        break;
                    case 1:
                        Console.WriteLine("has elegido a Hydrant");

                        p_equip_pkm[0] = tortuga;
                        loop = false;

                        break;
                    case 2:
                        Console.WriteLine("has elegido a Eleplant");

                        p_equip_pkm[0] = rana;
                        loop = false;

                        break;
                    case 3:
                        loop = false;
                        Console.WriteLine("Saliendo...");
                        break;
                }
            }


            //Elección maquina
            Random rnd = new Random();

            int varia = rnd.Next(1, 4);

            switch (varia)
                {
                case 1:
                    e_equip_pkm[0] = lagarto;
                    break;
                case 2:
                    e_equip_pkm[0] = tortuga;
                    break;
                case 3:
                    e_equip_pkm[0] = rana;
                    break;
                }

            turn = p_equip_pkm[0].Vel > e_equip_pkm[0].Vel ? true : turn = p_equip_pkm[0].Vel < e_equip_pkm[0].Vel ? false : true;

            bool battle = true;
            while (battle)
            {
                //Batalla
                if (turn == true)
                {
                    Console.Clear();
                    interfaz(p_equip_pkm, e_equip_pkm);
                    Console.ReadLine();
                    Console.WriteLine("Tu {0} ha realizado su ataque", p_equip_pkm[0].Name_PKM);
                    e_equip_pkm[0].Daño(e_equip_pkm[0].CalcDgm(1, 1, 1));

                    Console.ReadLine();
                    Console.Clear();

                    interfaz(p_equip_pkm, e_equip_pkm);
                    Console.ReadLine();

                    if (p_equip_pkm[0].Hp <= 0)
                    {
                        battle = false;
                    }
                    else if (e_equip_pkm[0].Hp <= 0)
                    {
                        battle = false;
                    }

                    turn = false;
                }
                else
                {
                    Console.Clear();
                    interfaz(p_equip_pkm, e_equip_pkm);
                    Console.ReadLine();
                    Console.WriteLine("El {0} enemigo realizó un ataque", e_equip_pkm[0].Name_PKM);
                    p_equip_pkm[0].Daño(p_equip_pkm[0].CalcDgm(1, 1, 1));

                    Console.ReadLine();
                    Console.Clear();

                    interfaz(p_equip_pkm, e_equip_pkm);
                    Console.ReadLine();

                    if (p_equip_pkm[0].Hp <= 0)
                    {
                        battle = false;
                    }
                    else if (e_equip_pkm[0].Hp <= 0)
                    {
                        battle = false;
                    }

                    turn = true;
                }
            }
            Console.WriteLine("Game Over");
           
        }
        private static string Menu(string[] items, int opcion)
        {
            string ret = string.Empty;
            int destacado = 0;

            Array.ForEach(items, elememt =>
            {
                if (destacado == opcion)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" > " + elememt + " < ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    ret = elememt;
                }
                else
                {
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.CursorLeft = 0;
                    Console.WriteLine(elememt);
                }
                destacado++;

            });

            return ret;
        }
        private static void interfaz(Pkm[] ply_e, Pkm[] evo_e)
        {
            Console.WriteLine("╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║ ┌───────────────────────┐			║");
            Console.WriteLine("║ │{0}		  │			║", evo_e[0].Name_PKM);
            Console.WriteLine("║ │			  │			║");
            Console.WriteLine("║ │		{0}	  │			║", evo_e[0].Hp);
            Console.WriteLine("║ └───────────────────────┘			║");
            Console.WriteLine("║		┌───────────────────────┐	║");
            Console.WriteLine("║		│{0}		│	║", ply_e[0].Name_PKM);
            Console.WriteLine("║		│			│	║");
            Console.WriteLine("║		│		{0}	│	║", ply_e[0].Hp);
            Console.WriteLine("║		└───────────────────────┘	║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
        }
    }
}