using ProvaWeb2_RicardoWehmuth.Models;
using ProvaWeb2_RicardoWehmuth.Models.DTOs;
using ProvaWeb2_RicardoWehmuth.Repositories;

namespace ProvaWeb2_RicardoWehmuth.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IComandaProdutoRepository _comandaProdutoRepository;
        private readonly IComandaRepository _comandaRepository;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ComandaService(IComandaRepository comandaRepository, IProdutoRepository produtoRepository, IUsuarioRepository usuarioRepository, IComandaProdutoRepository comandaProdutoRepository)
        {
            _comandaRepository = comandaRepository;
            _produtoRepository = produtoRepository;
            _usuarioRepository = usuarioRepository;
            _comandaProdutoRepository = comandaProdutoRepository;
        }

        public async Task<ServiceResult> AtualizarComanda(int id, UpdateComandaDto update)
        {
            if (!ValdateId(id) && update.IsValid())
                return ServiceResult.Failure(new ArgumentException("Id inválido"));
            try
            {
                var comanda = _comandaRepository.FindById(id);
                if (comanda == null)
                    return ServiceResult.Failure();

                update.Produtos.ForEach(p =>
                {
                    _produtoRepository.Update(p);
                });

                return ServiceResult.Success(update);
            }
            catch (Exception e)
            {
                return ServiceResult.Failure(e);
            }
        }


        public async Task<ServiceResult> BuscarComandaPorId(int id)
        {
            if (!ValdateId(id))
                return ServiceResult.Failure(new ArgumentException("Id inválido"));

            var comanda = _comandaRepository.FindById(id);

            var result = new CreateCommandDto();
            if (comanda is not null)
            {

                result = new CreateCommandDto(comanda.Id, comanda.Usuario);

                var comandasProduto = _comandaProdutoRepository.BuscarComandaProdutoPorComanda(comanda.Id).ToList();
                comandasProduto.ForEach(x => result.Produtos.Add(x.Produto));
            }

            return ServiceResult<Comanda>.Success(result);
        }

        public async Task<ServiceResult> BuscarUsuarios()
        {
            try
            {
                var comandas = _comandaRepository.GetAll();

                return ServiceResult.Success(comandas);

            }
            catch (Exception e)
            {
                return ServiceResult.Failure(e);
            }
        }

        public async Task<ServiceResult> CadastrarComanda(CreateCommandDto comanda)
        {
            if (!comanda.IsValid())
                return ServiceResult.Failure(new ArgumentException("Comanda inválida"));
            try
            {
                var user = _usuarioRepository.Find(comanda.Usuario.Id);
                if (user == null)
                    _usuarioRepository.Insert(comanda.Usuario);
                else
                    comanda.Usuario = user;

                List<ComandaProduto> comandaProdutos = new List<ComandaProduto>();
                comanda.Produtos.ForEach(p =>
                {
                    var produto = _produtoRepository.Find(p.Id);

                    if (produto is null)
                    {
                        _produtoRepository.Insert(p);


                    }
                    else
                    {
                        p = produto;

                    }

                    comandaProdutos.Add(new ComandaProduto(comanda.Id, p.Id, p));
                });

                var comandaEntity = new Comanda(comanda.Id, comanda.Usuario, new List<ComandaProduto>());

                _comandaRepository.CadastrarComanda(comandaEntity);

                comandaProdutos.ForEach(x => _comandaProdutoRepository.Insert(x));

                return ServiceResult<Comanda>.Success(comanda);
            }
            catch (Exception e)
            {
                return ServiceResult.Failure(e);
            }
        }

        public async Task<ServiceResult> DeletarComanda(int id)
        {
            if (!ValdateId(id))
                return ServiceResult.Failure(new ArgumentException("Id inválido"));
            var comanda = _comandaRepository.FindById(id);

            comanda.UsuarioId = null;
            comanda.Usuario = null;
            comanda.Produtos = null;

            try
            {
                _comandaRepository.Delete(comanda);

                return ServiceResult.Success(null, "Comanda removida");
            }
            catch (Exception e)
            {
                return ServiceResult.Failure(e);
            }
        }


        public bool ValdateId(int id)
        {
            if (id <= 0)
                return false;
            return true;
        }
    }
}
