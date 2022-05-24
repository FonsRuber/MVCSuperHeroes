using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSuperHeroes.Z_Capa2_Servicios.ClasesSuperHeroe
{
    public class SuperHumanosDTO : SuperHeroeDTO
    {
        public bool volar { get; set; }
        public bool superFuerza { get; set; }

        public SuperHumanosDTO() : base() 
        {
            volar = false;
            superFuerza = false;
        }

        public void MostrarPorPantallaDatosDelSuperHeroeSuperHumanos()
        {
            base.MostrarPorPantallaDatosDelSuperHeroe();
            if ( volar == true)
            {
                Console.WriteLine($"Este SuperHumano puede volar");
            }
            else
            {
                Console.WriteLine($"Este SuperHumano no puede volar");
            }
            if ( superFuerza == true)
            {
                Console.WriteLine($"Este SuperHumano tiene SuperFuerza");
            }
            else
            {
                Console.WriteLine($"Este SuperHumano no tiene SuperFuerza");
            }
        }


        public void PedirPorPantallaDatosDelSuperHeroeSuperHumanos()
        {
            base.PedirPorPantallaDatosDelSuperHeroe();
            Console.Write("¿Puede volar? Pulse s o n: ");
            string str_leido1;
            str_leido1 = Convert.ToString(Console.ReadLine()).ToLower();
            if (str_leido1 == "s")
            {
                volar = true;
            }
            else { volar = false; }

            Console.Write("¿Tiene SuperFuerza? Pulse s o n: ");
            string str_leido2;
            str_leido2 = Convert.ToString(Console.ReadLine()).ToLower();
            if (str_leido2 == "s")
            {
                superFuerza = true;
            }
            else { superFuerza = false; }
        }

        public override void MostrarPorPantalla()
        {
            base.MostrarPorPantallaDatosDelSuperHeroe();
            if (volar == true)
            {
                Console.WriteLine("Este superheroe puede volar");
            }
            else
            {
                Console.WriteLine("Este superheroe no puede volar");
            }
            if (superFuerza == true)
            {
                Console.WriteLine("Este superheroe tiene superfuerza");
            }
            else
            {
                Console.WriteLine("Este superheroe no tiene superfuerza");
            }
        }

        public override void PedirPorPantalla()
        {
            base.PedirPorPantallaDatosDelSuperHeroe();
            Console.Write("¿Tiene el poder de Volar? Escriba s o n: ");
            string str_leido1;
            str_leido1 = Convert.ToString(Console.ReadLine()).ToLower();
            if (str_leido1 == "s")
            {
                volar = true;
            }
            else { volar = false; }
            Console.Write("¿Tiene el poder de SuperFuerza? Escriba s o n: ");
            string str_leido2;
            str_leido2 = Convert.ToString(Console.ReadLine()).ToLower();
            if (str_leido2 == "s")
            {
                volar = true;
            }
            else { volar = false; }
        }

        //public void MostrarPorPantallaDatosDelSuperHeroeSuperHumanoPuedeVolar()
        //{
        //    if (volar == true)
        //    {
        //        base.MostrarPorPantallaDatosDelSuperHeroe();
        //        Console.WriteLine($"Puede volar");
        //    }
        //    else
        //    {
        //        base.MostrarPorPantallaDatosDelSuperHeroe();
        //        Console.WriteLine($"No puede volar");
        //    }

        //}
        //public void MostrarPorPantallaDatosDelSuperHeroeSuperHumanoTieneSuperFuerza()
        //{
        //    base.MostrarPorPantallaDatosDelSuperHeroe();
        //    Console.WriteLine($"Tiene Superfuerza");
        //}

        //public void PedirPorPantallaDatosDelSuperHeroeSuperHumanoPuedeVolar()
        //{
        //    base.PedirPorPantallaDatosDelSuperHeroe();

        //        Console.Write("¿Puede volar este SuperHeroe? (pulse s o n (Si/No)): ");
        //        string str_volar = Console.ReadLine();
        //        if (str_volar.ToLower() == "s")
        //        {
        //            volar = true;
        //        }
        //        if (str_volar.ToLower() == "n")
        //        {
        //            volar = false;
        //        }
        //        if (!((str_volar.ToLower() == "s") || (str_volar.ToLower() == "s")))
        //        {
        //            Console.Write("Caracter introducido incorrecto, vuelva a intentarlo");
        //        }
        //}

    }
}
