using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySql.Data.EntityFramework;

namespace MetierSharedMemory.Model
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class BdSharedMemoryContext:DbContext
    {
        public BdSharedMemoryContext() : base("connSharedMemory") { }
        public DbSet<Personne> personnes { get; set; }
        public DbSet<test> test { get; set; }
        public DbSet<Encadreur> encadreur { get; set; }
        public DbSet<Memoire> memoire { get; set; }
        public DbSet<Td_Erreur> Td_Erreur { get;set; }
       
    }
}