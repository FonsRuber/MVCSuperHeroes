//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCSuperHeroes.Z_Capa3_Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class SuperHeroe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuperHeroe()
        {
            this.ProfesionesHeroicas = new HashSet<ProfesionesHeroicas>();
            this.SuperHumanos = new HashSet<SuperHumanos>();
        }
    
        public long Id { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        public int Peso { get; set; }
        public int Altura { get; set; }
        public string SuperPoder { get; set; }
        public bool Borrado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProfesionesHeroicas> ProfesionesHeroicas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuperHumanos> SuperHumanos { get; set; }
    }
}