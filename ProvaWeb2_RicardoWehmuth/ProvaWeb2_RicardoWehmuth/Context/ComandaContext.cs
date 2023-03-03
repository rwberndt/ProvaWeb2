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
        public DbSet<ComandaProduto> ComandaProdutos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var comandaConfig = modelBuilder.Entity<Comanda>();

            comandaConfig.HasKey(x => x.Id);
            comandaConfig.HasOne(x => x.Usuario);
            comandaConfig.HasMany(x => x.Produtos);

            var userConfig = modelBuilder.Entity<Usuario>();
            userConfig.HasKey(x => x.Id);

            var produtoConfig = modelBuilder.Entity<Produto>();
            produtoConfig.HasKey(x => x.Id);


            var userModelConfig = modelBuilder.Entity<UserModel>();

            userModelConfig.HasKey(x => x.Id);

            var comandaProdutoModelConfig = modelBuilder.Entity<ComandaProduto>();
            comandaProdutoModelConfig.HasKey(x => x.Id);
            comandaProdutoModelConfig.HasOne(x => x.Produto);

            base.OnModelCreating(modelBuilder);
        }
    }
}
