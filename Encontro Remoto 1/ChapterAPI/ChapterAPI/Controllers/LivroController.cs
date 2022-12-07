using ChapterAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterAPI.Controllers
{
    [Produces("application/json")]//formato de reposta da api : json
    [Route("api/[controller]")]//rota para acesso do controller : api/livro
    [ApiController]//identificação que é uma classe controladora
    public class LivroController : ControllerBase//herança da classe ControllerBase
    {
        //variável privada criada para armazenar os dados do repositório
        private readonly LivroRepository _livroRepository;

        //injeção de dependência: o controller depende do repository
        public LivroController(LivroRepository livro)
        {
            _livroRepository = livro; 
        }

        /// <summary>
        /// método controlador para controlar o acesso ao método de listar 
        /// </summary>
        /// <returns>status code Ok e a lista obtida</returns>
        /// <exception cref="Exception">mensagem de erro</exception>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_livroRepository.Ler());
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }        
        }

    }
}
