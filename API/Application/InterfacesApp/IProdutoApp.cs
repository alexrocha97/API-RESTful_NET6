using API.Entities;

namespace API.Application.InterfacesApp
{
    public interface IProdutoApp
    {
        Task<List<Produto>> GetAll(int page, int qtd);
        Task<Produto> GetById(string Id);
        Task<Produto> Create(Produto produto);
    }
}
