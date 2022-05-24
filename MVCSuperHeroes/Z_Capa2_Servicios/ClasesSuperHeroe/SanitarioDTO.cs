using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSuperHeroes.Z_Capa2_Servicios.ClasesSuperHeroe
{
    public class SanitarioDTO : ProfesionesHeroicasDTO
    {
        [DisplayName("¿Tiene la habilidad de curar?")]
        public bool curar { get; set; }
        public SanitarioDTO() : base()
        {
            curar = false;
        }

        public void PedirPorPantallaDatosDelSanitario()
        {
            base.PedirPorPantallaDatosDelSuperHeroeProfesionHeroica();
            Console.Write("¿Tiene el poder de Curar? Escriba s o n: ");
            string str_leido;
            str_leido = Convert.ToString(Console.ReadLine()).ToLower();
            if (str_leido == "s")
            {
                curar = true;
            }
            else { curar = false; }

        }
        public override void MostrarPorPantalla()
        {
            base.MostrarPorPantallaDatosDelSuperHeroeProfesionHeroica();
            if (curar == true)
            {
                Console.WriteLine($"Este superheroe puede curar");
            }
            else
            {
                Console.WriteLine($"Este superheroe no puede curar");
            }

        }
        public override void PedirPorPantalla()
        {
            base.PedirPorPantallaDatosDelSuperHeroeProfesionHeroica();
            Console.Write("¿Tiene el poder de Curar? Escriba s o n: ");
            string str_leido;
            str_leido = Convert.ToString(Console.ReadLine()).ToLower();
            if (str_leido == "s")
            {
                curar = true;
            }
            else { curar = false; }
        }
    }
}
