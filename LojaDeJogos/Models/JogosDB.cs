using lojaJogos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace LojaDeJogos.Models {
    public class JogosDB : DbContext{

        // construtor da classe
        public JogosDB() : base("JogosDbConnectionString")
        { }

        // identificar as tabelas da base de dados
        public virtual DbSet<Jogos> Jogos { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }

        // configura a forma como as tabelas são criadas
        protected override void OnModelCreating(DbModelBuilder modelBuilder){
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}