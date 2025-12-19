using AspNetApp10.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApp10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // In-memory store for demo purposes
        internal static readonly List<UserDto> Users = [];

        // CREATE: POST /api/users
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto user)
        {
            user.Id = Users.Count + 1;
            Users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // READ ALL: GET /api/users
        [HttpGet]
        public IActionResult GetUsers() => Ok(Users);

        // READ ONE: GET /api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return user is null ? NotFound() : Ok(user);
        }

        // UPDATE: PUT /api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto updated)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user is null) return NotFound();

            user.Name = updated.Name;
            user.Email = updated.Email;
            return Ok(user);
        }

        // PATCH: Partial update
        [HttpPatch("{id}")]
        public IActionResult PatchUser(int id, [FromBody] JsonPatchDocument<UserDto> patchDoc)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user is null) return NotFound();

            patchDoc.ApplyTo(user, ModelState);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(user);
        }

        // DELETE: DELETE /api/users/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user is null) return NotFound();

            Users.Remove(user);
            return NoContent();
        }
    }
}

