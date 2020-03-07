using System;
using System.Collections.Generic;
using System.Text;
using Registro_Persona.Entidad;
using Microsoft.EntityFrameworkCore;

namespace Registro_Persona.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Database/PersonaDb.db");
        }
    }
}
