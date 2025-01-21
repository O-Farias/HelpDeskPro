using HelpDeskPro.Models;
using HelpDeskPro.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // 1. Listar todos os usuários
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }

        // 2. Buscar usuário por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // 3. Buscar usuário por email
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // 4. Criar um novo usuário
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        // 5. Atualizar um usuário
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);

            if (existingUser == null)
                return NotFound();

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.Role = user.Role;

            await _userRepository.UpdateAsync(existingUser);

            return NoContent();
        }

        // 6. Deletar um usuário
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
                return NotFound();

            await _userRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
