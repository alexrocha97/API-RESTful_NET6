using API.Entities;
using API.Entities.ViewModels;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _serviceUser;
        public UserController(UserService serviceUser)
        {
            _serviceUser = serviceUser;
        }

        [HttpGet]
        public ActionResult<List<UserViewModel>> GetAll()
        {
            return _serviceUser.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<UserViewModel> GetById(string id)
        {
            return _serviceUser.Get(id);
        }

        [HttpPost]
        public ActionResult<UserViewModel> Create(UserViewModel user)
        {
            try
            {
                return Ok(_serviceUser.Create(user));
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
