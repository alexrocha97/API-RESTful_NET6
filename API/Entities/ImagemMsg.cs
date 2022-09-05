namespace API.Entities
{
    public class ImagemMsg
    {
        public ImagemMsg(string mensagem, string urlImagem)
        {
            this.mensagem = mensagem;
            this.urlImagem = urlImagem;
        }
        public string mensagem { get; set; }
        public string urlImagem { get; set; }
    }
}
