using Microsoft.AspNetCore.Mvc;
using api.Interfaces;
using api.Dtos.VisitItem;
using api.Interface;
using api.Mapper;

namespace api.Controllers
{
    [Route("api/visititem")]
    [ApiController]
    public class VisitItemController : ControllerBase
    {
        private readonly IVisitItemRepository _repo;

        public VisitItemController(IVisitItemRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVisitItemDto dto)
        {
            var item = dto.ToVisitItemFromCreateDto();
            await _repo.CreateAsync(item);
            return Ok(item);
        }

        [HttpGet("{visitId}")]
        public async Task<IActionResult> GetByVisitId(int visitId)
        {
            var items = await _repo.GetByVisitIdAsync(visitId);
            return Ok(items);
        }
    }
}