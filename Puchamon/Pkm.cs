using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puchamon
{
    internal class Pkm
    {
        //propiedades
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Vel { get; set; }
        public int ID_Type { get; set; }
        public string Tipo { get; set; }
        public string Name_PKM { get; set; }

        //constructor
        public Pkm (int hp, int atk, int def, int vel, int ID_Type, string tipo, string name_PKM)
        {
            Hp = hp;
            Atk = atk;
            Def = def;
            Vel = vel;
            this.ID_Type = ID_Type;
            Tipo = tipo;
            Name_PKM = name_PKM;
        }

        //metodos
        public int CalcDgm( float pow, float boni, int efec)
        {
            Random rnd = new Random();

            int varia = rnd.Next(85, 101);

            int ret = Convert.ToInt32(0.01 * boni * efec * varia * ((1 * Atk * pow / 25 * Def) + 2));//Usa esta forma para convertir double a int

            return ret;
        }

        public void Daño (int dgm)
        {
            int hp_final;

            hp_final = Hp - dgm;

            if (hp_final < 0)
                hp_final = 0;

            Hp = hp_final;
        }

    }
}
