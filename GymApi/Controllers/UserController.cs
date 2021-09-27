using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymApi.Models;
using GymApi.Data;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly GymDbContext gymDbContext;
        public UserController(GymDbContext _gymDbContext)
        {
            gymDbContext = _gymDbContext;
        }
        // GET: /ejercicios/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetAll()
        {
            return await gymDbContext.Usuarios.ToListAsync();

        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> Get(int id)
        {

            var usuarios = await gymDbContext.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                //devuelve una respuesta de que no encuentra ejercicios o algo así.
                return NotFound();
            }
            return usuarios;


        }
        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<Ejercicios>> Post(Usuarios usuario)
        {
            //usuario.Password = 
            //int numEjercicios = gymDbContext.Ejercicios.Count();
            var usuarioExist = await gymDbContext.Usuarios.AddAsync(usuario);
            await gymDbContext.SaveChangesAsync();
            //return object 
            return CreatedAtAction(nameof(GetAll), new { id = usuario.Id }, usuario);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuarios usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            gymDbContext.Entry(usuario).State = EntityState.Modified;
            try
            {
                await gymDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExiste(id))
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

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await gymDbContext.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            gymDbContext.Usuarios.Remove(usuario);
            await gymDbContext.SaveChangesAsync();

            return NoContent();
        }
        private bool UsuarioExiste(int id)
        {
            return gymDbContext.Usuarios.Any(e => e.Id == id);
        }
        
    }
}
