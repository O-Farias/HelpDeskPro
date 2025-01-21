using HelpDeskPro.Models;
using HelpDeskPro.Repositories;
using HelpDeskPro.Services;
using Moq;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskPro.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly UserService _userService;

        // Construtor para inicializar o Mock e o serviço sendo testado
        public UserServiceTests()
        {
            _mockRepo = new Mock<IUserRepository>();
            _userService = new UserService(_mockRepo.Object);
        }

        // Teste para verificar se o método GetAllUsersAsync retorna todos os usuários
        [Fact]
        public async Task GetAllUsersAsync_ShouldReturnAllUsers()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 1, Name = "John Doe", Email = "john@example.com", Role = "Client" },
                new User { Id = 2, Name = "Jane Doe", Email = "jane@example.com", Role = "Technician" }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);

            // Act
            var result = await _userService.GetAllUsersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, u => u.Name == "John Doe");
            Assert.Contains(result, u => u.Name == "Jane Doe");
        }

        // Teste para verificar se o método GetUserByIdAsync retorna o usuário correto
        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnCorrectUser()
        {
            // Arrange
            var user = new User { Id = 1, Name = "John Doe", Email = "john@example.com", Role = "Client" };

            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetUserByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result!.Id);
            Assert.Equal(user.Name, result.Name);
        }

        // Teste para verificar se o método GetUserByIdAsync retorna null quando o usuário não existe
        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnNull_WhenUserDoesNotExist()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((User?)null);

            // Act
            var result = await _userService.GetUserByIdAsync(99);

            // Assert
            Assert.Null(result);
        }
    }
}
