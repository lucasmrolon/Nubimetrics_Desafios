using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Modelo;

namespace Desafio_3.Controllers
{
    [Route("Usuarios")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly Desafio3DbContext dbContext;

        public UsersController(Desafio3DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var userList = dbContext.Users.ToList();

            return Ok(userList);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody]User newUser)
        {
            if (newUser == null)
                return BadRequest("Usuario nulo");
            dbContext.Add(newUser);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser([FromRoute] int id,[FromBody] User newUser)
        {
            if (newUser == null)
                return BadRequest("Datos incorrectos");

            var userInDb = dbContext.Users.Find(id);
            if(userInDb == null)
            {
                return BadRequest("El usuario no existe");
            }
            if (newUser.Name != null)
                userInDb.Name = newUser.Name;
            if(newUser.LastName != null)
                userInDb.LastName = newUser.LastName;
            if(newUser.Email != null)
                userInDb.Email = newUser.Email;
            if (newUser.Password != null)
                userInDb.Password = newUser.Password;

            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser([FromRoute] int id)
        {

            var userInDb = dbContext.Users.Find(id);
            if (userInDb == null)
            {
                return BadRequest("El usuario no existe");
            }

            dbContext.Remove(userInDb);

            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
