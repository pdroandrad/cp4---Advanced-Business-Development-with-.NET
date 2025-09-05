namespace livros.Models
{
    public class ConfiguracaoMongoDB
    {
        public string StringConexao { get; set; } = null!;
        public string NomeBanco { get; set; } = null!;
        public string NomeColecaoLivros { get; set; } = "Livros";
    }
}
