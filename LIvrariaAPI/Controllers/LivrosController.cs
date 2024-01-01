using LIvrariaAPI.Data;
using LIvrariaAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LIvrariaAPI.Controllers
{

    [ApiController]
    [Route("/api/[controller]")]
    public class LivrosController : Controller
    {
       private readonly LivrariaDBContext _livrariaDBContext;
        public LivrosController(LivrariaDBContext livrariaDBContext)
        {
            this._livrariaDBContext = livrariaDBContext;

        }

        [HttpGet]

        public async Task<IActionResult> GetAllLivros()
        { 

         var livros = await _livrariaDBContext.Livros.ToListAsync();
            return Ok(livros);
        }

        [HttpPost]

        public async Task<IActionResult> AddLivro([FromBody] Livro livro)
        {

            livro.Id =Guid.NewGuid();

            await _livrariaDBContext.Livros.AddAsync(livro);
            await _livrariaDBContext.SaveChangesAsync();

            return Ok(livro);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetLivro(Guid id)
        {
            var livro = await _livrariaDBContext.Livros.FirstOrDefaultAsync(x => x.Id == id);

            if (livro == null)
                return NotFound();

            return Ok(livro);
        
        }

        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> AlterarLivro([FromRoute] Guid id, Livro alterarLivroRequest)
        {
            var livro = await _livrariaDBContext.Livros.FindAsync(id);

            if (livro == null)
                return NotFound();

            livro.titulo = alterarLivroRequest.titulo;
            livro.subtitulo = alterarLivroRequest.subtitulo;
            livro.corDaCapa = alterarLivroRequest.corDaCapa;
            livro.preco = alterarLivroRequest.preco;

            await _livrariaDBContext.SaveChangesAsync();

            return Ok(livro);
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteLivro(Guid id)
        {
            var livro = await _livrariaDBContext.Livros.FindAsync(id);

            if (livro == null)
                return NotFound();

            _livrariaDBContext.Livros.Remove(livro);
            await _livrariaDBContext.SaveChangesAsync();


            return Ok(livro);

        }







    }
}
