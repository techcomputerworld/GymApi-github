using GymApi.Data;
using GymApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly GymDbContext gymDbContext;
        public TrainingController(GymDbContext _gymDbContext)
        {
            gymDbContext = _gymDbContext;
        }
        // GET: /ejercicios/
        [HttpGet]
        public async Task<ActionResult<IEnumerable< Ejercicios>>> GetAll()
        {
            return await gymDbContext.Ejercicios.ToListAsync();

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ejercicios>> Get (int id)
        {
           
            var ejercicios = await gymDbContext.Ejercicios.FindAsync(id);
            if (ejercicios == null)
            {
                //devuelve una respuesta de que no encuentra ejercicios o algo así.
                return NotFound();
            }
            return ejercicios;
            
            
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Ejercicios>> Post(Ejercicios ejercicio)
        {
            //int numEjercicios = gymDbContext.Ejercicios.Count();
            var ejercicioExist = await gymDbContext.Ejercicios.AddAsync(ejercicio);
            await gymDbContext.SaveChangesAsync();
            //return object 
            return CreatedAtAction(nameof(GetAll), new { id = ejercicio.Id }, ejercicio);
        }        

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Ejercicios ejercicio)
        {
            if (id != ejercicio.Id)
            {
                return BadRequest();
            }
            gymDbContext.Entry(ejercicio).State = EntityState.Modified;
            try
            {
                await gymDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EjercicioExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
                
            }
            return NoContent();
        }
        //dominio.com el dominio que sea tengo que verlo de publicarlo en Internet
        //Delete: https://gymapi.com/ejercicios/4 
        
        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            var ejercicio = await gymDbContext.Ejercicios.FindAsync(id);
            if (ejercicio == null)
            {
                return NotFound();
            }
            gymDbContext.Ejercicios.Remove(ejercicio);
            await gymDbContext.SaveChangesAsync();

            return NoContent();
        }
        private bool EjercicioExiste(int id)
        {
            return gymDbContext.Ejercicios.Any(e => e.Id == id);
        }
    }
}
