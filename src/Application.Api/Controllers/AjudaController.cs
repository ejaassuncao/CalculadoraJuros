using Microsoft.AspNetCore.Mvc;
using System;

namespace Application.Api.Controllers
{
    [Route("/api/ajuda")]
    [ApiController]    
    public class AjudaController : ControllerBase
    {
       /// <summary>
       /// Metodo responsável por retornar a URL do meu projeto no github
       /// </summary>      
        [HttpGet("showmethecode")]
        public IActionResult Showmethecode()
        {
            return Ok("https://github.com/ejaassuncao/CalculadoraJuros");
        }
        
    }
}
