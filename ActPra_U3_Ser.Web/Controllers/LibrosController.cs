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


        // -------------------------------------------------------
        // ENDPOINT 2: Obtener un libro por Id
        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound("No se encontró un libro con el Id " + id);
            }

            return Ok(libro);
        }

        // -------------------------------------------------------
        // ENDPOINT 3: Crear un nuevo libro
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] Libro libro)
        {
            if (libro == null)
            {
                return BadRequest("Los datos del libro no son válidos.");
            }

            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            // Retorna una respuesta 201 (Created) indicando que el recurso fue creado.
            // Además, incluye la ubicación del nuevo recurso mediante el método ObtenerPorId.
            return CreatedAtAction(nameof(ObtenerPorId), new { id = libro.Id }, libro);
        }


        // -------------------------------------------------------
        // ENDPOINT 4: Actualizar un libro completo
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Libro libroActualizado)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound("No se encontró un libro con el Id " + id);
            }

            // Reemplazar todos los campos
            libro.Titulo = libroActualizado.Titulo;
            libro.Autor = libroActualizado.Autor;
            libro.AnioPublicacion = libroActualizado.AnioPublicacion;
            libro.Genero = libroActualizado.Genero;
            libro.NumeroPaginas = libroActualizado.NumeroPaginas;
            libro.Precio = libroActualizado.Precio;
            libro.Disponible = libroActualizado.Disponible;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // -------------------------------------------------------
        // ENDPOINT 5: Eliminar un libro
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var libro = await _context.Libros.FindAsync(id);

            if (libro == null)
            {
                return NotFound("No se encontró un libro con el Id " + id);
            }

            _context.Libros.Remove(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
