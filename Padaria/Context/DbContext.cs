using Padaria.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;

namespace Estagio.Contexto
{
    public class Context : DbContext
    {
        public Context() : base("Pedidos") { }

        public DbSet<pedidos> Pedidos { get; set; }

    }
}