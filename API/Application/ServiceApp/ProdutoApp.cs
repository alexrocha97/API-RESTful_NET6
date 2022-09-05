using API.Application.InterfacesApp;
using API.Entities;
using API.Services;

namespace API.Application.ServiceApp
{
    public class ProdutoApp : IProdutoApp
    {
        private readonly ProdutoService _produtoMongo;
        public ProdutoApp(ProdutoService produtoMongo)
        {
            _produtoMongo = produtoMongo;
        }

        public async Task<Produto> Create(Produto produto)
        {
            return await _produtoMongo.Create(produto);
        }

        public async Task<List<Produto>> GetAll()
        {
            return await _produtoMongo.GetAll();
        }

        public async Task<Produto> GetById(string Id)
        {
            return await _produtoMongo.GetById(Id);
        }
    }
}
