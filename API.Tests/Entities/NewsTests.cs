

using API.Entities;
using Xunit;

namespace API.Tests.Entities
{
    public class NewsTests
    {
        [Fact]
        public void News_Validate_Title_Lenght()
        {
            //Arrange & Act
            var result = Assert.Throws<DomainException>(() => new News(
                 "Entretenimento",
                 "A Band preparou uma série de atrações para agitar o fim de ano. Nesta terça-feira (21), às 22h30, o público acompanha o MasterChef Especial de Natal com a presença de vários famosos. Na primeira prova, Adriana Birolli e Toni Garrido enfrentam Negra Li e Felipe Titto. A dupla que fizer o melhor hambúrguer com acompanhamento e molho vence a disputa.\n\nNo segundo desafio, as gêmeas nadadoras Bia e Branca Feres encaram os gêmeos lutadores Rodrigo Minotauro e Rogério Minotouro. Os irmãos terão de preparar receitas natalinas de família.\n\n",
                 "A Band preparou uma série de atrações para agitar o fim de ano. Nesta terça-feira (21), às 22h30, o público acompanha o MasterChef Especial de Natal com a presença de vários famosos. Na primeira prova, Adriana Birolli e Toni Garrido enfrentam Negra Li e Felipe Titto. A dupla que fizer o melhor hambúrguer com acompanhamento e molho vence a disputa.\n\nNo segundo desafio, as gêmeas nadadoras Bia e Branca Feres encaram os gêmeos lutadores Rodrigo Minotauro e Rogério Minotouro. Os irmãos terão de preparar receitas natalinas de família.\n\n",
                 "Da Redação",
                 "http://localhost:5005/imgs/f168c0e0-790a-4247-934e-1f9d32bf4a5e.webp",
                 status: API.Entities.Enums.Status.Active));

            //Assert
            Assert.Equal("O título deve ter até 90 caracteres!", result.Message);
        }


        [Fact]
        public void News_Validate_Hat_Lenght()
        {
            //Arrange & Act
            var result = Assert.Throws<DomainException>(() => new News(
                 "Fim de ano da Band traz programas especiais, filmes e shows exclusivos",
                 "Fim de ano da Band traz programas especiais, filmes e shows exclusivos",
                 "A Band preparou uma série de atrações para agitar o fim de ano. Nesta terça-feira (21), às 22h30, o público acompanha o MasterChef Especial de Natal com a presença de vários famosos. Na primeira prova, Adriana Birolli e Toni Garrido enfrentam Negra Li e Felipe Titto. A dupla que fizer o melhor hambúrguer com acompanhamento e molho vence a disputa.\n\nNo segundo desafio, as gêmeas nadadoras Bia e Branca Feres encaram os gêmeos lutadores Rodrigo Minotauro e Rogério Minotouro. Os irmãos terão de preparar receitas natalinas de família.\n\n",
                 "Da Redação",
                 "http://localhost:5005/imgs/f168c0e0-790a-4247-934e-1f9d32bf4a5e.webp",
                 status: API.Entities.Enums.Status.Active));

            //Assert
            Assert.Equal("O chapéu deve ter até 40 caracteres!", result.Message);
        }


        [Fact]
        public void News_Validate_Title_Empty()
        {
            //Arrange & Act
            var result = Assert.Throws<DomainException>(() => new News(
                 "Entretenimento",
                 string.Empty,
                 "A Band preparou uma série de atrações para agitar o fim de ano. Nesta terça-feira (21), às 22h30, o público acompanha o MasterChef Especial de Natal com a presença de vários famosos. Na primeira prova, Adriana Birolli e Toni Garrido enfrentam Negra Li e Felipe Titto. A dupla que fizer o melhor hambúrguer com acompanhamento e molho vence a disputa.\n\nNo segundo desafio, as gêmeas nadadoras Bia e Branca Feres encaram os gêmeos lutadores Rodrigo Minotauro e Rogério Minotouro. Os irmãos terão de preparar receitas natalinas de família.\n\n",
                 "Da Redação",
                 "http://localhost:5005/imgs/f168c0e0-790a-4247-934e-1f9d32bf4a5e.webp",
                 status: API.Entities.Enums.Status.Active));

            //Assert
            Assert.Equal("O título não pode estar vazio!", result.Message);
        }


        [Fact]
        public void News_Validate_Hat_Empty()
        {
            //Arrange & Act
            var result = Assert.Throws<DomainException>(() => new News(
                 string.Empty,
                 "Fim de ano da Band traz programas especiais, filmes e shows exclusivos",
                 "A Band preparou uma série de atrações para agitar o fim de ano. Nesta terça-feira (21), às 22h30, o público acompanha o MasterChef Especial de Natal com a presença de vários famosos. Na primeira prova, Adriana Birolli e Toni Garrido enfrentam Negra Li e Felipe Titto. A dupla que fizer o melhor hambúrguer com acompanhamento e molho vence a disputa.\n\nNo segundo desafio, as gêmeas nadadoras Bia e Branca Feres encaram os gêmeos lutadores Rodrigo Minotauro e Rogério Minotouro. Os irmãos terão de preparar receitas natalinas de família.\n\n",
                 "Da Redação",
                 "http://localhost:5005/imgs/f168c0e0-790a-4247-934e-1f9d32bf4a5e.webp",
                 status: API.Entities.Enums.Status.Active));

            //Assert
            Assert.Equal("O chapéu não pode estar vazio!", result.Message);
        }


        [Fact]
        public void News_Validate_Description_Empty()
        {
            //Arrange & Act
            var result = Assert.Throws<DomainException>(() => new News(
                 "Entretenimento",
                 "Fim de ano da Band traz programas especiais, filmes e shows exclusivos",
                 string.Empty,
                 "Da Redação",
                 "http://localhost:5005/imgs/f168c0e0-790a-4247-934e-1f9d32bf4a5e.webp",
                 status: API.Entities.Enums.Status.Active));

            //Assert
            Assert.Equal("O texto não pode estar vazio!", result.Message);
        }



    }
}
