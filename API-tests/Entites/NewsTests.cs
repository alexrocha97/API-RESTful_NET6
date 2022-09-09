using API.Domain;
using API.Entities;
using API.Entities.Enums;
using Xunit;

namespace API_tests.Entites
{
    public class NewsTests
    {
        [Fact]
        public void News_Validate_Title_Length()
        {
            var result = Assert.Throws<DomainException>(() => new News(
            "",
            "",
            "",
            "",
            "",
            status: Status.Active));

            Assert.Equal("O título deve ter até 90 caracteres", result.Message);
        }
    }
}
