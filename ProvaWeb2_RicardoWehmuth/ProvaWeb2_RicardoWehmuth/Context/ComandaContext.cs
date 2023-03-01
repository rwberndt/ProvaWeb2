using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProvaWeb2_RicardoWehmuth.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaWeb2_RicardoWehmuth.Context
{
    public class ComandaContext : DbContext
    {

        public ComandaContext(DbContextOptions<ComandaContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<UserModel> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userConfig = modelBuilder.Entity<Usuario>();
            userConfig.HasKey(x => x.Id);

            var produtoConfig = modelBuilder.Entity<Produto>();
            produtoConfig.HasKey(x => x.Id);

            var comandaConfig = modelBuilder.Entity<Comanda>();

            comandaConfig.HasKey(x => x.Id);
            comandaConfig.HasMany(x => x.Produtos);
            comandaConfig.HasOne(x => x.Usuario);

            var userModelConfig = modelBuilder.Entity<UserModel>();

            userModelConfig.HasKey(x => x.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
