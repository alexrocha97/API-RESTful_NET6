namespace API.Entities
{
    public class Produto : BaseEntity
    {
        public Produto(string nome, string descricao, int qtdade)
        {
            Nome = nome;
            Descricao = descricao;
            Qtdade = qtdade;
        }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Qtdade { get; set; }
    }
}
