using System.Collections.Generic;
using System.Threading.Tasks;
using AppStoreAPI.Data;
using AppStoreAPI.Dtos;
using AppStoreAPI.Models;
using AppStoreAPI.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformController : ControllerBase
    {
        private IPlatformRepo _repo;
        private readonly AppStoreDbContext _context;
        private readonly IMapper _mapper;

        public PlatformController(AppStoreDbContext ctx, IPlatformRepo repo, IMapper mapper)
        {
            _repo = repo;
            _context = ctx;
            _mapper = mapper;
        }

        // GET: api/Platform
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platform>>> GetPlatforms()
        {
            var platforms = await _context.Platforms.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<GetPlatformsDto>>(platforms));
        }
            

        // GET: api/Platform/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Platform>> GetPlatform(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            if (platform == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GetPlatformsDto>(platform));
        }

        

        // POST: api/Platform
        [HttpPost]
        public async Task<ActionResult> PostPlatform(PlatformCreateDto PlatformCreateDto)
        {
            var commandModel = _mapper.Map<Platform>(PlatformCreateDto);

            await _repo.SavePlatform(commandModel);

            var platformReadDto = _mapper.Map<GetPlatformsDto>(commandModel);

            return CreatedAtAction(nameof(GetPlatform), new { id = commandModel.Id}, platformReadDto);
        }

        // DELETE: api/Platform/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlatform(int id)
        {
            var platform = await _context.Platforms.FindAsync(id);
            if (platform == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // PUT: api/Platform/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPlatform(int id, Platform platform)
        {
            if (id != platform.Id)
            {
                return BadRequest();
            }

            await _repo.SavePlatform(platform);

            return CreatedAtAction(nameof(GetPlatform), new { id = platform.Id }, platform);
        }


    }
}