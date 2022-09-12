namespace API.Token
{
    public class TokenManagement
    {
        public string Secret { get; set; }
        public string issuer { get; set; }
        public string audince { get; set; }
        public int acessExpiration { get; set; }
    }
}
