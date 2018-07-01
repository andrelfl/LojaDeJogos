using lojaJogos.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LojaDeJogos.Models {
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
            // identificar as tabelas da base de dados
            public virtual DbSet<Media> Media { get; set; }
            public virtual DbSet<Jogos> Jogos { get; set; }
            public virtual DbSet<Cliente> Cliente { get; set; }
            public virtual DbSet<Categorias> Categoria { get; set; }
            public virtual DbSet<Compra> Compra { get; set; }

            /// <summary>
            /// configura a forma como as tabelas são criadas
            /// </summary>
            /// <param name="modelBuilder"> objeto que referencia o gerador de base de dados </param>      
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                base.OnModelCreating(modelBuilder);
        }
    }
}
