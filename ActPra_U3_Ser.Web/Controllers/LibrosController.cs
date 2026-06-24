using ApiBiblioteca_P3.Data;
using ApiBiblioteca_P3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca_P3.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController : ControllerBase
    {
        // Contexto de base de datos utilizado para acceder y manipular la información.
        private readonly AppDbContext _context;

        public LibrosController(AppDbContext context)
        {
            // Inyección de dependencias del contexto de base de datos.
            // Se asigna la instancia recibida al campo privado para usarla
            // en los métodos del controlador.
            _context = context;
        }


        // ENDPOINT 1: Obtener todos los libros
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos() 
        {
            // Recupera todos los libros almacenados en la base de datos.
            var libros = await _context.Libros.ToListAsync();

            // Devuelve los datos en formato JSON con código de estado 200 (OK).
            return Ok(libros);
        }


    }
}
