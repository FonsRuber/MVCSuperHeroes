﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SuperHeroesDBEntities : DbContext
    {
        public SuperHeroesDBEntities()
            : base("name=SuperHeroesDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bombero> Bombero { get; set; }
        public virtual DbSet<DC> DC { get; set; }
        public virtual DbSet<Marvel> Marvel { get; set; }
        public virtual DbSet<ProfesionesHeroicas> ProfesionesHeroicas { get; set; }
        public virtual DbSet<Sanitario> Sanitario { get; set; }
        public virtual DbSet<SuperHeroe> SuperHeroe { get; set; }
        public virtual DbSet<SuperHumanos> SuperHumanos { get; set; }
    }
}
