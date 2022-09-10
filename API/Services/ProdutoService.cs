using API.Entities;
using API.Infra;

namespace API.Services
{
    public class ProdutoService
    {
        private readonly IMongoRepository<Produto> _mongoProduto;
        public ProdutoService(IMongoRepository<Produto> mongoProduto)
        {
            _mongoProduto = mongoProduto;
        }

        public async Task<List<Produto>> GetAll(int page, int qtd)
        {
            var produto = new List<Produto>();
            var lstprodutos = await Task.Run(() => _mongoProduto.GetAll(page,qtd));
            var lstproduto = _mongoProduto.GetAll(page, qtd);
            return produto;
        }

        public async Task<Produto> GetById(string Id)
        {
            var produto = await Task.Run(() => _mongoProduto.GetById(Id));
            return produto;
        }

        public async Task<Produto> Create(Produto produto)
        {
            var result =_mongoProduto.Create(produto);
            return await GetById(produto.Id);
        }
    }
}
