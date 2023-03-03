using ProvaWeb2_RicardoWehmuth.Context;
using ProvaWeb2_RicardoWehmuth.Models;
using System.Runtime.CompilerServices;

namespace ProvaWeb2_RicardoWehmuth
{
    public static class DbInitializer
    {


        public static void Initialize(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ComandaContext>();


            context.Database.EnsureCreated();

            if (context.Comandas.Any())
                return;

            var usuarios = new Usuario[]
            {
                new Usuario(1,"Joao","74328149"),
                new Usuario(2,"Amanda","4799321534"),
                new Usuario(3,"Ana Luiza","99743247932"),
                new Usuario(4,"Maria","983471204"),
                new Usuario(5,"Jose","39081724")
            };
            foreach (var usuario in usuarios)
            {
                var added = context.Usuarios.Add(usuario);

            }

            context.SaveChanges();
            var produtos = new Produto[]
            {
                new Produto(1,"Monitor",990),
                new Produto(2,"Placa de Video",2200),
                new Produto(3,"Mouse",250),
                new Produto(4,"Teclado", 500)
            };
            foreach (var produto in produtos)
            {
                var id = context.Produtos.Add(produto);
            }

            context.SaveChanges();

            var comandas = new Comanda[]
            {
                new Comanda(1,usuarios[0]),
                new Comanda(2,usuarios[0]),
                new Comanda(3,usuarios[0])
            };
            foreach (var comanda in comandas)
            {
                context.Comandas.Add(comanda);
            }
            context.SaveChanges();


            var comandasProdutos = new ComandaProduto[]
            {
                new ComandaProduto(comandas[0].Id,produtos[2].Id,produtos[2]),
                new ComandaProduto(comandas[2].Id,produtos[1].Id,produtos[1]),
                new ComandaProduto(comandas[2].Id,produtos[3].Id,produtos[3]),
                new ComandaProduto(comandas[1].Id,produtos[2].Id,produtos[2]),
            };

            foreach (var comandaProduto in comandasProdutos)
            {
                context.ComandaProdutos.Add(comandaProduto);
            }

            context.SaveChanges();
        }
    }
}
