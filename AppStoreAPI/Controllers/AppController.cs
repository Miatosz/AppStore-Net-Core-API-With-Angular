using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AppStoreAPI.Data;
using AppStoreAPI.Dtos;
using AppStoreAPI.Dtos.UpdateDtos;
using AppStoreAPI.Models;
using AppStoreAPI.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly AppStoreDbContext _context;
        private IAppRepo _repo;
        private readonly IMapper _mapper;
        private IHostingEnvironment _environment;

        public AppController(AppStoreDbContext ctx, IAppRepo repo, IMapper mapper, IHostingEnvironment environment)
        {
            _context = ctx;
            _repo = repo;
            _mapper = mapper;
            _environment = environment;
        }

        // GET: api/App
        [HttpGet]
        //public IEnumerable<App> GetApps() => _repo.Apps;
        public async Task<ActionResult<IEnumerable<App>>> GetApps()
        {
            var apps = await _context.Apps
                        .Include(c => c.Developer)
                        .Include(c => c.Platform)
                        .Include(c => c.AgeClassification)
                        .ToListAsync();

            
            return Ok(_mapper.Map<IEnumerable<GetAppsDto>>(apps));
        }
            

        // GET: api/App/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<App>> GetApp(int id)
        {
            var app = await _context.Apps
                .Include(c => c.Developer)
                .Include(c => c.Platform)
                .Include(c => c.AgeClassification)
                .FirstOrDefaultAsync(c => c.Id == id);
                
            if (app == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<GetAppsDto>(app));
        }    

        // GET: api/App/Platform{id}
        [Route("/PlatformId={id}")]
        [HttpGet("PlatformId={id}")]  
        public ActionResult<IEnumerable<App>> GetAppByPlatform(int id)
        {
            Console.WriteLine(id + "xd");
            var apps = _repo.Apps.Where(c => c.PlatformId == id);
            return Ok(apps);
        }  

        // GET: api/App/{id}/Download
        [HttpGet("{id}/Download")]
        [Route("{id}/Download")]
        public async Task<IActionResult> Download([FromQuery]string file, int id)
        {
            var files = Path.Combine(_environment.WebRootPath, "Apps");
            // var filePath = Path.Combine(files, id);
            var filePath = "wwwroot/Apps/test.txt";

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            return File(memory, "application/txt", "app");

        }

        // POST :api/App/{id}/Upload
        // [Route("{id}/SaveFile")]
        // [HttpPost("{id}/SaveFile")]
        // public JsonResult SaveFile()
        // {
        //     try
        //     {                
        //         var httpRequest = Request.Form;
        //         var postedFile = httpRequest.Files[0];
        //         string filename = postedFile.FileName;
        //         var physicalPath = "wwwroot/Photos/" + filename;

        //         using(var stream = new FileStream(physicalPath, FileMode.Create))
        //         {
        //             postedFile.CopyTo(stream);
        //         }
                
        //         return new JsonResult(filename);

        //     }
        //     catch (System.Exception)
        //     {                
        //         return new JsonResult("anonymous.png");
        //     }
        // }

        // GET: api/App/{id}/Download
        // [Route("{id}/Download")]
        // [HttpGet("{id}/Download")]
        // public ActionResult<string> GetAppFilePath(int id)
        // {
        //    var appFilePath = _context.Apps.Find(id);
        //    if (appFilePath == null || appFilePath.AppFileUrl == null)
        //    {
        //        return NotFound();
        //    }           

        //     return appFilePath.AppFileUrl;
        // }


        // DELETE: api/App/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApp(int id)
        {
            var app = await _context.Apps.FindAsync(id);
            if (app == null)
            {
                return NotFound();
            }

            await _repo.DeleteApp(id);

            return NoContent();
        }

        // POST: api/App
        [HttpPost]
        public async Task<ActionResult<App>> PostApp(AppCreateDto appCreateDto)
        {
            var appModel = _mapper.Map<App>(appCreateDto);
            await _repo.SaveApp(appModel);

            appModel = await _context.Apps
                    .Include(c => c.Developer)
                    .Include(c => c.AgeClassification)
                    .Include(c => c.Platform)
                    .FirstOrDefaultAsync(c => c.Id == appModel.Id);

            var appReadDto = _mapper.Map<GetAppsDto>(appModel);

            return CreatedAtAction(nameof(GetApp), new { id = appModel.Id}, appReadDto);
        }

        // PATCH: api/App/{id}
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchApp(int id, JsonPatchDocument<AppUpdateDto> appUpdateDto)
        {
            // var app = _mapper.Map<App>(appUpdateDto);

            // if (id != app.Id)
            // {
            //     return BadRequest();
            // }
            // await _repo.SaveApp(app);

            // return CreatedAtAction(nameof(GetApp), new { id = app.Id }, app);
            var appModelFromCtx =  await _context.Apps.FindAsync(id);
            if (appModelFromCtx == null)
            {
                return NotFound();
            }

            var appToPatch = _mapper.Map<AppUpdateDto>(appModelFromCtx);
            appUpdateDto.ApplyTo(appToPatch, ModelState);

            if (!TryValidateModel(appToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(appToPatch, appModelFromCtx);

            await _repo.UpdateApp(appModelFromCtx);

            return NoContent();
        }

    }
}