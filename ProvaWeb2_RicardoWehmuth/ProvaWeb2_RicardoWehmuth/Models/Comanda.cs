﻿namespace ProvaWeb2_RicardoWehmuth.Models
{
    public class Comanda : BaseEntity, IValidable
    {
        public Comanda()
        {

        }
        public Comanda(int id,Usuario usuario, IEnumerable<Produto> produtos)
        {
            Id = id;
            Usuario = usuario;
            Produtos = produtos;
        }
        public virtual Usuario Usuario { get; set; }
        public virtual IEnumerable<Produto> Produtos { get; set; }

        public bool IsValid()
        {
            if (!Usuario.IsValid() || Produtos == null)
                return false;

            return true;
        }
    }
}
