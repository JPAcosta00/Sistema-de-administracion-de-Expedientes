using System;
using Microsoft.EntityFrameworkCore;
using SGE.Aplicacion;
namespace SGE.Repositorios;

public class SGEContext : DbContext{
   public DbSet<Expediente> Expediente{ get; set; }
   public DbSet<Tramite> Tramite { get; set; }
   public DbSet<Usuario> Usuario {get; set;}
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseSqlite("data source=SGE.sqlite");
   }
}