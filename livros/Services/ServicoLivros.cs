using MongoDB.Driver;
using livros.Models;

namespace livros.Services
{
    public class ServicoLivros
    {
        private readonly IMongoCollection<Livro> _colecaoLivros;

        public ServicoLivros(IMongoCollection<Livro> colecaoLivros)
        {
            _colecaoLivros = colecaoLivros;
        }

        public async Task<List<Livro>> ObterTodosAsync() =>
            await _colecaoLivros.Find(_ => true).ToListAsync();

        public async Task<Livro?> ObterPorIdAsync(string id) =>
            await _colecaoLivros.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task<Livro> CriarAsync(Livro livro)
        {
            await _colecaoLivros.InsertOneAsync(livro); 
            return livro; 
        }

        public async Task<bool> AtualizarAsync(string id, Livro livroAtualizado)
        {
            var resultado = await _colecaoLivros.ReplaceOneAsync(a => a.Id == id, livroAtualizado);
            return resultado.MatchedCount > 0;
        }

        public async Task<bool> RemoverAsync(string id)
        {
            var resultado = await _colecaoLivros.DeleteOneAsync(a => a.Id == id);
            return resultado.DeletedCount > 0;
        }
    }
}

 

