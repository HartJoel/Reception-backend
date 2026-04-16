using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Dtos.Visit;
using api.Mapper;

namespace api.Controllers
{
    [Route("api/visit")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IVisitRepository _repo;

        public VisitController(IVisitRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var visits = await _repo.GetAllAsync();
            var dto = visits.Select(v => v.ToVisitDto());
            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var visit = await _repo.GetByIdAsync(id);
            if(visit == null)
            {
                return NotFound();
            }

            return Ok(visit.ToVisitDto());
        }

        [HttpPost("{VisitorId}")]
        public async Task<IActionResult> Create([FromRoute] int VisitorId, CreateVisitDto dto)
        {
            var visit = dto.ToVisitFromCreateDto(VisitorId); 
            await _repo.CreateAsync(visit);
            return Ok(visit);
        }
    }
}