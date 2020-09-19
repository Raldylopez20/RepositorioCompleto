using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

public class Contexto : DbContext{ 
    public DbSet<Persona> Persona {set;get;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Data\BaseDatos.db");
        }

}