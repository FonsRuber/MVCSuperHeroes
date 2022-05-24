using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVCSuperHeroes.Z_Capa2_Servicios.ClasesSuperHeroe
{
    public abstract class SuperHeroeDTO
    {
        public long idSuperHeroe { get; set; }
        [DisplayName("DNI:")]
        public string dni { get; set; }
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [DisplayName("Apellidos")]
        public string apellidos { get; set; }
        [DisplayName("Edad")]
        public int edad { get; set; }
        [DisplayName("Peso")]
        public int peso { get; set; }
        [DisplayName("Altura")]
        public int altura { get; set; }
        [DisplayName("Superpoder")]
        public string superPoder { get; set; }
        //public DateTime fechaNacimiento { get; set; }
        //public DateTime fechaBaja { get; set; }
        //public static int cont { get; set; }
        public bool borrado { get; set; }
        public string ImagenPath { get; set; }
        [DisplayName("Imagen")]
        public HttpPostedFileBase ImageFile { get; set; }
        public SuperHeroeDTO()
        {
            //cont++;
            //idSuperHeroe = cont;
            dni = "";
            nombre = "";
            apellidos = "";
            edad = 0;
            peso = 0;
            altura = 0;
            superPoder = "";
            //fechaNacimiento = new DateTime(1,1,1);
            //fechaBaja = new DateTime(1,1,1);
        }

        public void MostrarPorPantallaDatosDelSuperHeroe()
        {
            Console.WriteLine($"ID: {idSuperHeroe}");
            Console.WriteLine($"Dni: {dni}");
            Console.WriteLine($"Nombre: {nombre}");
            Console.WriteLine($"Apellidos: {apellidos}");
            Console.WriteLine($"Edad: {edad}");
            Console.WriteLine($"Peso: {peso}");
            Console.WriteLine($"Altura: {altura}");
            Console.WriteLine($"SuperPoder: {superPoder}");
            //Console.WriteLine($"Fecha de Nacimiento: {fechaNacimiento:dd-MM-yyyy}");

            //if (fechaBaja != new DateTime(1, 1, 1))
            //{
            //    Console.WriteLine($"Fecha de baja: {fechaBaja:dd-MM-yyyy}");
            //}
        }

        public void MostrarInformacionEnUnaLinea()
        {
            Console.WriteLine($"{idSuperHeroe}: {nombre} {apellidos}");
        }

        public void PedirPorPantallaDatosDelSuperHeroe()
        {
            Console.Write("Dni:");
            dni = Console.ReadLine();
            Console.Write("Nombre:");
            nombre = Console.ReadLine();
            Console.Write("Apellidos:");
            apellidos = Console.ReadLine();
            Console.Write("Edad:");
            edad = int.Parse(Console.ReadLine());
            Console.Write("Peso:");
            peso = int.Parse(Console.ReadLine());
            Console.Write("Altura:");
            altura = int.Parse(Console.ReadLine());
            Console.Write("SuperPoder:");
            superPoder = Console.ReadLine();
            //Console.Write("Fecha de Nacimiento (dd-MM-yyy):");
            //fechaNacimiento = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null); 
        }

        public abstract void MostrarPorPantalla();

        public abstract void PedirPorPantalla();
    }
}
