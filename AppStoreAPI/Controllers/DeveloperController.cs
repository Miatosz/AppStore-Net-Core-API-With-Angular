using System;
using System.Collections.Generic;
using System.Linq;
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
    public class DeveloperController : ControllerBase
    {
        private readonly AppStoreDbContext _context;
        private IDeveloperRepo _repo;
        private readonly IMapper _mapper;

        public DeveloperController(AppStoreDbContext ctx, IDeveloperRepo repo, IMapper mapper)
        {
            _context = ctx;
            _repo = repo;
            _mapper = mapper;
        }
    
        // GET: api/Developer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> GetDevelopers()
        {
            var developers = await _context.Developers.ToListAsync();

            var developerGetDto = _mapper.Map<IEnumerable<GetDevelopersDto>>(developers);

            
            
            return Ok(developerGetDto);
        }
            

        // GET: api/Developer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloper(int id)
        {
            var developer = await _context.Developers
                                    .FirstOrDefaultAsync(c => c.Id == id);

            if (developer == null)
            {
                return NotFound();
            }

            var developerGetDto = _mapper.Map<GetDevelopersDto>(developer);

            developerGetDto.Apps = new List<App>();

            developerGetDto.Apps.AddRange(_context.Apps
                                            .Include(c => c.Platform)
                                            .Include(c => c.AgeClassification)
                                            .Include(c => c.Developer)
                                            .Where(c => c.DeveloperId == developer.Id)
                                            .ToList());
            return Ok(developerGetDto);
        }

        // GET: api/Developer/{id}/Apps
        [Route("{id}/Apps")]
        [HttpGet("{id}/Apps")]
        public async Task<ActionResult> GetDeveloperApps(int id)
        {
            var developerAppsList = await _context.Apps
                                                .Include(c => c.Developer)
                                                .Include(c => c.Platform)
                                                .Include(c => c.AgeClassification)
                                                .Where(c => c.DeveloperId == id)
                                                .ToListAsync();

            if (developerAppsList == null)
            {
                return NoContent();
            }

            return Ok(_mapper.Map<IEnumerable<GetAppsDto>>(developerAppsList));
            //return Ok(developerAppsList);
        }


        // POST: api/Developer
        [HttpPost]
        public async Task<ActionResult<Developer>> PostDeveloper(DeveloperCreateDto developerCreateDto)
        {
            var developerModel = _mapper.Map<Developer>(developerCreateDto);
            await _repo.SaveDeveloper(developerModel);

            var developerReadDto = _mapper.Map<GetDevelopersDto>(developerModel);
            
            return CreatedAtAction(nameof(GetDeveloper), new { id = developerModel.Id }, developerReadDto);
        }

        // DELETE: api/Developer/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDeveloper(int id)
        {
            var developer = await _context.Developers.FindAsync(id);

            if (developer == null)
            {
                return NotFound();
            }

            await _repo.DeleteDeveloper(developer.Id);

            return NoContent();
        }

        // PATCH: api/Developer/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult<Developer>> PatchDeveloper(int id, JsonPatchDocument<DeveloperUpdateDto> developerUpdateDto)
        {
            var developerModelFromCtx = await _context.Developers.FindAsync(id);
            if (developerModelFromCtx == null)
            {
                return NotFound();
            }

            var developerToPatch = _mapper.Map<DeveloperUpdateDto>(developerModelFromCtx);
            developerUpdateDto.ApplyTo(developerToPatch, ModelState);

            if (!TryValidateModel(developerToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(developerToPatch, developerModelFromCtx);

            await _repo.UpdateDeveloper(developerModelFromCtx);

            return NoContent();


        }


    }
}