using BankDataApi.Models;
using BankDataApi.Storage;
using Microsoft.AspNetCore.Mvc;

namespace BankDataApi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<UserController> _logger;
        private readonly UserCardStorage _storage;

        public UserController(ILogger<UserController> logger, IConfiguration config)
        {
            _logger = logger;
            _storage = new UserCardStorage(config["ConnectionStrings:DefaultConnection"] ?? "");
        }

        [HttpGet("user/")]
        public async Task<IEnumerable<User>?> GetUsers()
        {
            return await _storage.GetUsers();
        }

        [HttpGet("user/{id}")]
        public async Task<User?> GetUser(string id)
        {
            return await _storage.GetUser(id);
        }

        [HttpPost("user/insert")]
        public async Task<int> InsertUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
           return await _storage.InsertUser(user);
        }

        [HttpPost("user/update")]
        public async Task<int> UpdateUser(User user)
        {
            return await _storage.UpdateUser(user);
        }

        [HttpDelete("user/delete/{userid}")]
        public async Task<int> DeleteUser(string userid)
        {
            return await _storage.DeleteUser(userid);
        }

        [HttpPost("card/insert")]
        public async Task<int> InsertCard(CreditCard card)
        {
            card.Id = Guid.NewGuid().ToString();
            return await _storage.InsertCard(card);
        }

        [HttpPost("card/update")]
        public async Task<int> UpdateCard(CreditCard card)
        {
            return await _storage.UpdateCard(card);
        }

        [HttpDelete("card/delete/{cardid}")]
        public async Task<int> DeleteCard(string cardid)
        {
            return await _storage.DeleteCard(cardid);
        }
    }
}
