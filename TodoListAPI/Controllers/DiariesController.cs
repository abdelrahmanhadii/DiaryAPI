using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.ServiceContracts;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    //[Authorize(Roles = "test")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class DiariesController : ControllerBase
    {
        private readonly IDiaryService _diaryService;
        public DiariesController(IDiaryService diaryService)
        {
            _diaryService = diaryService;
        }
        [HttpGet]
        public IEnumerable<ListDiaryDTO> Get()
        {
            return  _diaryService.List(User.Claims.FirstOrDefault(a => a.Type.Contains("sid")).Value);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDiaryDTO entity)
        {
            entity.EnteredBy = entity.UserId = User.Claims.FirstOrDefault(a => a.Type.Contains("sid")).Value;
            if(await _diaryService.Create(entity) > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("completed/{id}")]
        public void Put([FromRoute] int id)
        {
            _diaryService.Completed(id);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(await _diaryService.SoftDelete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}