using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zero.Core.Entities;
using Zero.Core.IServices;

namespace Zero.Controllers
{
    [ApiController]
    [Route("Api/[controller]/[action]")]

    public class UsersController : Controller
    {
        private readonly IUserServer _IUserServer;


        public UsersController(IUserServer userServer)
        {
            _IUserServer = userServer ?? throw new ArgumentNullException(nameof(userServer));
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetUsers(string Code = "")
        {
            return await _IUserServer.Users(Code);
        }

        [HttpGet]
        public async Task<User> GetUser(string Code = "")
        {
            return await _IUserServer.User(Code);
        }

        [HttpPut]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            return await _IUserServer.Update(id, user) > 0 ? Ok() : Ok();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await _IUserServer.Add(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(List<string> Code)
        {
           
            await _IUserServer.Delete(Code);

            return NoContent();
        }

    }
}
