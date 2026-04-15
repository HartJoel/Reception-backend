using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Dtos.Visitor;
using api.Interface;
using api.Mapper;

namespace api.Controllers
{
    [Route("api/visitor")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository _repo;

        public VisitorController(IVisitorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var visitors = await _repo.GetAllAsync();
            return Ok(visitors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVisitorDto dto)
        {
            var visitor = dto.ToVisitorFromCreateDto();
            await _repo.CreateAsync(visitor);
            return Ok(visitor);
        }
    }
}