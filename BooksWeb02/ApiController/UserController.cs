using ConceptArchitect.BookManagement;
using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.ApiController
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : Controller
    {
        IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<List<User>> GetAllUsers()
        {
            var users = await userService.GetAllUsers();
            return users;
        }
        [HttpGet("{emailId}", Name = "SelectedUserRoute")]
        public async Task<IActionResult> GetUserByEmailId(string email)
        {
            var user = await userService.GetUserByEmailId(email);



            if (user != null)
                return Ok(user); //Status 200
            else
                return NotFound(user);  //Status 404
        }
        /*[HttpGet("{id}", Name = "SelectedUserRoute")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await userService.GetById(id);

 

            if (user != null)
                return Ok(user); //Status 200
            else
                return NotFound(user);  //Status 404
        }*/
        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await userService.AddUser(user);



            return CreatedAtAction(nameof(GetUserByEmailId), new { Id = user.Email }, user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await userService.DeleteUser(id);



            return NoContent(); //204
        }
    }
}
