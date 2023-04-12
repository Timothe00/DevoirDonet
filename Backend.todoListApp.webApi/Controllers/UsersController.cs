using Backend.todoListApp.DataAccess.Model;
using Backend.todoListApp.Logic.ModelsImage;
using Backend.todoListApp.Logic.Services.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.todoListApp.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServ _userService;

        public UsersController(IUserServ IuserService)
        {
            _userService = IuserService;
        }



        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);

        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] ImgUsers user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(_userService.CreateUserAsync(user));
            }

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ImgUsers Xuser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("error update");
            }
            else
            {
                return Ok(_userService.UpdateUserAsync(Xuser));
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _userService.DeleteUserAsync(id);
        }
    }
}
