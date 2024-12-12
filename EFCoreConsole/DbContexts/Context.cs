using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreConsole.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreConsole.DbContexts
{
    public class Context :  DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Diretor> Diretores { get; set; }       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        =>optionsBuilder.UseSqlite("Data Source=EFCoreConsole.db");
    }
}