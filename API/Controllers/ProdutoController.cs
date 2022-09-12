using API.Application.InterfacesApp;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApp _produtoApp;
        public ProdutoController(IProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;
        }

        [HttpGet]
        public async Task<List<Produto>> GetAll(int page, int qtd)
        {
            return await _produtoApp.GetAll(page, qtd);
        }

        [HttpGet("{Id}")]
        public async Task<Produto> GetById(string Id)
        {
            return await _produtoApp.GetById(Id);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Create(Produto produto)
        {
            try
            {
                return Ok(await _produtoApp.Create(produto));
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro ao criar produto" + ex.Message);
            }
        }
    }
}
