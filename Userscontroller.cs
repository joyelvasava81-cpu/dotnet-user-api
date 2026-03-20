using Microsoft.AspNetCore.Mvc;
using UserApi.Models;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // Static list to simulate a database for the project
        private static List<User> _users = new List<User>();

        [HttpGet] // READ (All)
        public ActionResult<IEnumerable<User>> GetUsers() => Ok(_users);

        [HttpGet("{id}")] // READ (Single)
        public ActionResult<User> GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost] // CREATE
        public ActionResult<User> CreateUser(User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            user.Id = _users.Count + 1;
            _users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")] // UPDATE
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            return NoContent();
        }

        [HttpDelete("{id}")] // DELETE
        public IActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();

            _users.Remove(user);
            return NoContent();
        }
    }
}