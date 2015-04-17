using Microsoft.AspNet.Identity.EntityFramework;

namespace ProyectoBanco.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int? IdPersona { get; set; }
        public Persona Persona { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<ProyectoBanco.Models.Persona> Personas { get; set; }

        public System.Data.Entity.DbSet<ProyectoBanco.Models.Cuenta> Cuentas { get; set; }

        public System.Data.Entity.DbSet<ProyectoBanco.Models.TipoCuenta> TipoCuentas { get; set; }
    }
}