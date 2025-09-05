using Microsoft.AspNetCore.Mvc;
using livros.Models;
using livros.Services;

namespace livros.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : Controller
    {
        private readonly ServicoLivros _servico; 

        public LivrosController(ServicoLivros servico)
        {
            _servico = servico;
        }


        [HttpGet]
        public async Task<ActionResult<List<Livro>>> ObterTodos() =>
            await _servico.ObterTodosAsync(); 

        [HttpGet("{id:length(24)}", Name = "ObterLivro")] 
        public async Task<ActionResult<Livro>> ObterPorId(string id)
        {
            var livro = await _servico.ObterPorIdAsync(id);
            return livro is null ? NotFound() : livro; 
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> Criar(Livro livro)
        {
            await _servico.CriarAsync(livro);
            return CreatedAtRoute("ObterLivro", new { id = livro.Id }, livro);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Atualizar(string id, Livro livroAtualizado)
        {
            var livroExistente = await _servico.ObterPorIdAsync(id);
            if (livroExistente is null) return NotFound();

            livroAtualizado.Id = livroExistente.Id;
            var atualizado = await _servico.AtualizarAsync(id, livroAtualizado);

            return atualizado ? NoContent() : NotFound();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Remover(string id)
        {
            var livroExistente = await _servico.ObterPorIdAsync(id);
            if (livroExistente is null) return NotFound();

            var removido = await _servico.RemoverAsync(id);
            return removido ? NoContent() : NotFound();
        }

    }
}
