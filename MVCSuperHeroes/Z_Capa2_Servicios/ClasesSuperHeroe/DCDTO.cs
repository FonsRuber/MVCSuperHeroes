using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSuperHeroes.Z_Capa2_Servicios.ClasesSuperHeroe
{
    public class DCDTO : SuperHumanosDTO
    {
        public bool ligaDeLaJusticia { get; set; }
        public DCDTO() : base() 
        {
            ligaDeLaJusticia = false;
        }
        //public void EsJusticiero()
        //{
        //    if (ligaDeLaJusticia == true)
        //    {
        //        Console.WriteLine("1 - Avengers: Es un Justiciero");
        //    }
        //    else
        //    {
        //        Console.WriteLine("1 - Avengers: No es un Justiciero");
        //    }
        //}
        //public void MostrarMenuAtributosAModificar()
        //{
        //    Console.WriteLine("¿Que atributo desea modificar? (tenga en cuenta que no todos los atributos son modificables)");
        //    EsJusticiero();
        //    Console.WriteLine($"2 - DNI del Justiciero: {dni}");
        //    Console.WriteLine($"3 - Nombre del Justiciero: {nombre}");
        //    Console.WriteLine($"4 - Apellidos del Justiciero: {apellidos}");
        //    Console.WriteLine($"5 - Edad del Justiciero: {edad}");
        //    Console.WriteLine($"6 - Peso del Justiciero: {peso}");
        //    Console.WriteLine($"7 - Altura del Justiciero: {altura}");
        //    Console.WriteLine($"8 - SuperPoder del Justiciero: {superPoder}");
        //    Console.WriteLine($"9 - Fecha de Nacimiento del Justiciero: {fechaNacimiento}");
        //    Console.WriteLine("Seleccione el indice del atributo a Justiciero: ");
        //    string indiceAtributo = Console.ReadLine();
        //}
        //public void Modificar()
        //{
        //    MostrarMenuAtributosAModificar();
        //    Console.WriteLine("Seleccione el indice del atributo a modificar: ");
        //    string indiceAtributo = Console.ReadLine();

        //    switch (indiceAtributo)
        //    {
        //        case "1":
        //            ModificarLigaDeLaJusticia();
        //            break;
        //        case "2":
        //            ModificarDni();
        //            break;
        //        case "3":
        //            ModificarNombre();
        //            break;
        //        case "4":
        //            ModificarApellidos();
        //            break;
        //        case "5":
        //            ModificarEdad();
        //            break;
        //        case "6":
        //            ModificarPeso();
        //            break;
        //        case "7":
        //            ModificarAltura();
        //            break;
        //        case "8":
        //            ModificarSuperPoder();
        //            break;
        //        case "9":
        //            ModificarFechaNacimiento();
        //            break;
        //        default:
        //            Console.WriteLine("El indice introducido es incorrecto");
        //            break;
        //    }
        //}
        //public void ModificarLigaDeLaJusticia()
        //{
        //    Console.WriteLine("¿Es vengador? Pulse s o n: ");
        //    string str_leido;
        //    str_leido = Convert.ToString(Console.ReadLine()).ToLower();
        //    if (str_leido == "s")
        //    {
        //        ligaDeLaJusticia = true;
        //    }
        //    else { ligaDeLaJusticia = false; }
        //}
        //public void ModificarDni()
        //{
        //    Console.WriteLine("Nuevo DNI: ");
        //    dni = Console.ReadLine();
        //}
        //public void ModificarNombre()
        //{
        //    Console.WriteLine("Nuevo Nombre: ");
        //    nombre = Console.ReadLine();
        //}
        //public void ModificarApellidos()
        //{
        //    Console.WriteLine("Nuevos Apellidos: ");
        //    apellidos = Console.ReadLine();
        //}
        //public void ModificarEdad()
        //{
        //    Console.WriteLine("Nueva Edad: ");
        //    edad = Convert.ToInt32(Console.ReadLine());
        //}
        //public void ModificarPeso()
        //{
        //    Console.WriteLine("Nuevo Peso: ");
        //    peso = Convert.ToInt32(Console.ReadLine());
        //}
        //public void ModificarAltura()
        //{
        //    Console.WriteLine("Nueva Altura: ");
        //    altura = Convert.ToInt32(Console.ReadLine());
        //}
        //public void ModificarSuperPoder()
        //{
        //    Console.WriteLine("Nuevo SuoerPoder: ");
        //    superPoder = Console.ReadLine();
        //}
        //public void ModificarFechaNacimiento()
        //{
        //    Console.WriteLine("Nueva Fecha de Nacimiento (dd-MM-yyyy): ");
        //    fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
        //}
        public void PedirPorPantallaDatosDelHeroeDC()
        {
            base.PedirPorPantallaDatosDelSuperHeroeSuperHumanos();
            Console.Write("¿Pertenece a la liga de la justicia? Escriba s o n: ");
            string str_leido;
            str_leido = Convert.ToString(Console.ReadLine()).ToLower();
            if (str_leido == "s")
            {
                ligaDeLaJusticia = true;
            }
            else { ligaDeLaJusticia = false; }
        }

        public override void MostrarPorPantalla()
        {
            base.MostrarPorPantallaDatosDelSuperHeroeSuperHumanos();
            if (ligaDeLaJusticia == true)
            {
                Console.WriteLine($"Este superheroe pertenece a la liga de la justicia");
            }
            else
            {
                Console.WriteLine($"Este superheroe no pertenece a la liga de la justicia");
            }
        }

        public override void PedirPorPantalla()
        {
            base.PedirPorPantallaDatosDelSuperHeroeSuperHumanos();
            Console.Write("¿Pertenece a la liga de la justicia? Escriba s o n: ");
            string str_leido;
            str_leido = Convert.ToString(Console.ReadLine()).ToLower();
            if (str_leido == "s")
            {
                ligaDeLaJusticia = true;
            }
            else { ligaDeLaJusticia = false; }
        }


    }
}
