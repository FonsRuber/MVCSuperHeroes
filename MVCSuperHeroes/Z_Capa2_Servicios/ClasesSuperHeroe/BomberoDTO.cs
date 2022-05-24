using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSuperHeroes.Z_Capa2_Servicios.ClasesSuperHeroe
{
    public class BomberoDTO : ProfesionesHeroicasDTO
    {
        [DisplayName("¿Tiene la habilidad de apagar fuegos?")]
        public bool apagarFuego { get; set; }
        public BomberoDTO() : base() 
        {
            apagarFuego = false;
        }

        public void PedirPorPantallaDatosDelBombero()
        {
            base.PedirPorPantallaDatosDelSuperHeroeProfesionHeroica();
            Console.Write("¿Puede apagar fuego? Escriba s o n: ");
            string str_leido;
            str_leido = Convert.ToString(Console.ReadLine()).ToLower();
            if (str_leido == "s")
            {
                apagarFuego = true;
            }
            else { apagarFuego = false; }
        }

        public override void MostrarPorPantalla()
        {
            base.MostrarPorPantallaDatosDelSuperHeroeProfesionHeroica();
            if (apagarFuego == true)
            {
                Console.WriteLine($"Este superheroe puede apagar fuego");
            }
            else
            {
                Console.WriteLine($"Este superheroe no puede apagar fuego");
            }
        }

        public override void PedirPorPantalla()
        {
            base.PedirPorPantallaDatosDelSuperHeroeProfesionHeroica();
            Console.Write("¿Puede apagar fuego? Escriba s o n: ");
            string str_leido;
            str_leido = Convert.ToString(Console.ReadLine()).ToLower();
            if (str_leido == "s")
            {
                apagarFuego = true;
            }
            else { apagarFuego = false; }
        }
    }
}
