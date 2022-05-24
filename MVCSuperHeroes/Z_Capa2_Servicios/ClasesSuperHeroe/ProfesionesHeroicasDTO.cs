using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSuperHeroes.Z_Capa2_Servicios.ClasesSuperHeroe
{
    public class ProfesionesHeroicasDTO : SuperHeroeDTO
    {
        public int valor { get; set; }
        public decimal salario { get; set; }
        //public List<ProfesionesHeroicas> listaProfesionesHeroicas { get; set; }

        public ProfesionesHeroicasDTO() : base()
        {
            valor = 0;
            salario = 0;
        }

        public void MostrarPorPantallaDatosDelSuperHeroeProfesionHeroica()
        {
            base.MostrarPorPantallaDatosDelSuperHeroe();
            Console.WriteLine($"Nivel de Valor de 0 a 100: {valor}");
            Console.WriteLine($"Cuantía del salario: {salario}");
        }

        public void PedirPorPantallaDatosDelSuperHeroeProfesionHeroica()
        {
            base.PedirPorPantallaDatosDelSuperHeroe();
            Console.Write("Nivel de Valor de 0 a 100: ");
            valor = int.Parse(Console.ReadLine());
            Console.Write("Cualtía del salario: ");
            salario = decimal.Parse(Console.ReadLine());
        }
        public override void MostrarPorPantalla()
        {
            base.MostrarPorPantallaDatosDelSuperHeroe();
            Console.WriteLine($"Este superheroe tiene valor y un salario");
        }
        public override void PedirPorPantalla()
        {
            base.PedirPorPantallaDatosDelSuperHeroe();
            Console.WriteLine($"Nivel de Valor de 0 a 100: ");
            valor = int.Parse(Console.ReadLine());
            Console.WriteLine($"Cuantía del salario: ");
            salario = decimal.Parse(Console.ReadLine());
        }
    }
}
