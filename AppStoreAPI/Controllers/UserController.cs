using System.Collections.Generic;
using System.Threading.Tasks;
using AppStoreAPI.Data;
using AppStoreAPI.Dtos;
using AppStoreAPI.Dtos.UpdateDtos;
using AppStoreAPI.Models;
using AppStoreAPI.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppStoreDbContext _context;
        private IUserRepo _repo;
        private readonly IMapper _mapper;

        public UserController(AppStoreDbContext ctx, IUserRepo repo, IMapper mapper)
        {
            _context = ctx;
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/User
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        // {
        //     var users = await _context.Users.ToListAsync();

            
        //     return Ok(_mapper.Map<IEnumerable<GetUsersDto>>(users));
        // }
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _repo.Users;
        }


        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GetUsersDto>(user));
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult> PostUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);
            await _repo.SaveUser(userModel);

            var userReadDto = _mapper.Map<GetUsersDto>(userModel);

            return CreatedAtAction(nameof(GetUser), new { id = userModel.Id }, userReadDto);
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _repo.DeleteUser(id);

            return NoContent();
        }

        // PATCH: api/User/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PutUser(int id, JsonPatchDocument<UserUpdateDto> userUpdateDto)
        {
            var userModelFromCtx = await _context.Users.FindAsync(id);

            if (userModelFromCtx == null)
            {
                return NotFound();
            }

            var userToPatch = _mapper.Map<UserUpdateDto>(userModelFromCtx);
            userUpdateDto.ApplyTo(userToPatch, ModelState);

            if (!TryValidateModel(userToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userToPatch, userModelFromCtx);

            await _repo.UpdateUser(userModelFromCtx);

            return NoContent();
        }
        
    }
}