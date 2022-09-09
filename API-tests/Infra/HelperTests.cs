using API.Infra;
using Xunit;

namespace API_tests.Infra
{
    public class HelperTests
    {
        [Fact]
        public void Deve_retornar_Slug()
        {
            // Arrange
            // Criação e buscando informações para teste
            var title = "Fim de ano da Band traz programas especiais, filmes e shows exclusivos";
            // Act
            // Ação de executar o teste
            var result = Helper.GenerateSlug(title);
            // Assert
            // O que é esperado da execução do teste
            Assert.Equal("fim-de-ano-da-band-traz-programas-especiais-filmes-e-shows-exclusivos", result);
        }
    }
}
