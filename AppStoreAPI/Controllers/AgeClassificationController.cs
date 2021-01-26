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
    [Route("api/[controller]")]
    [ApiController]
    public class AgeClassificationController : ControllerBase
    {
        private readonly AppStoreDbContext _context;
        private IAgeClassificationRepo _repo;
        private readonly IMapper _mapper;

        public AgeClassificationController(AppStoreDbContext ctx, IAgeClassificationRepo repo, IMapper mapper)
        {
            _context = ctx;
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/AgeClassification
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgeClassification>>> GetAgeClassifications()
        {
            var ageClassifications = await _context.AgeClassifications.ToListAsync();

            return Ok(_mapper.Map<IEnumerable<GetAgeClassificationsDto>>(ageClassifications));
        }
            

        // GET: api/AgeClassification/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AgeClassification>> GetAgeClassification(int id)
        {
            var ageClassification = await _context.AgeClassifications.FindAsync(id);
            
            if (ageClassification == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GetAgeClassificationsDto>(ageClassification));
        }
            

        // POST: api/AgeClassification
        [HttpPost]
        public async Task<ActionResult<AgeClassification>> PostAgeClassification(AgeClassificationCreateDto ageClassificationCreateDto)
        {
            var ageClassificationModel = _mapper.Map<AgeClassification>(ageClassificationCreateDto);
            await _repo.SaveAgeClassification(ageClassificationModel);

            var ageClassificationReadDto = _mapper.Map<GetAgeClassificationsDto>(ageClassificationModel);

            return CreatedAtAction(nameof(GetAgeClassification), new {id = ageClassificationModel.Id}, ageClassificationReadDto);
        }

        // DELETE: api/AgeClassification/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAgeClassification(int id)
        {
            var ageClassification = await _context.AgeClassifications.FindAsync(id);
            if (ageClassification == null)
            {
                return NotFound();
            }
            
            await _repo.DeleteAgeClassification(id);

            return NoContent();
        }

        // PUT: api/AgeClassification/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgeClassification(int id, AgeClassification ageClassification)
        {
            if (id != ageClassification.Id)
            {
                return BadRequest();
            }
            await _repo.SaveAgeClassification(ageClassification);

            return NoContent();
        }


    }
}