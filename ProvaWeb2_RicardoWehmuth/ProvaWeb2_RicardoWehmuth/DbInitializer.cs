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

            return;

            var usuarios = new Usuario[]
            {
                new Usuario("Joao"),
                new Usuario("Amanda"),
                new Usuario("Ana Luiza"),
                new Usuario("Maria"),
                new Usuario("Jose")
            };
            foreach (var usuario in usuarios)
            {
                var added = context.Usuarios.Add(usuario);

            }

            context.SaveChanges();
            var produtos = new Produto[]
            {
                new Produto("Monitor",990),
                new Produto("Placa de Video",2200),
                new Produto("Mouse",250),
                new Produto("Teclado", 500)
            };
            foreach (var produto in produtos)
            {
                var id = context.Produtos.Add(produto);
            }

            context.SaveChanges();

            var comandas = new Comanda[]
            {
                new Comanda(usuarios[0],new List<Produto>{produtos[0],produtos[1]}),
                new Comanda(usuarios[0],new List<Produto>{produtos[2],produtos[1]}),
                new Comanda(usuarios[0],new List<Produto>(){produtos[3] })
            };
            foreach (var comanda in comandas)
            {
                context.Comandas.Add(comanda);
            }
            context.SaveChanges();
        }
    }
}
