using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using UserService.Data;
using UserService.DTOs;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController  : ControllerBase
    {
        private readonly IUserRepo _repository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<UserReadDTO>> GetUsers()
        {
            Console.WriteLine("--> Getting users...");

            var userItem = _repository.GetAllUsers();

            return Ok(_mapper.Map<IEnumerable<UserReadDTO>>(userItem));
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<UserReadDTO> GetUserById(int id)
        {
            var userItem = _repository.GetUserById(id);
            if(userItem != null)
            {
                return Ok(_mapper.Map<UserReadDTO>(userItem));
            
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<UserReadDTO> CreateUser(UserCreateDTO userCreateDTO)
        {
            var userModel = _mapper.Map<User>(userCreateDTO);
            _repository.CreateUser(userModel);
            _repository.SaveChanges();

            var UserReadDTO = _mapper.Map<UserReadDTO>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new {Id = UserReadDTO.Id}, UserReadDTO);
        }
    }
}