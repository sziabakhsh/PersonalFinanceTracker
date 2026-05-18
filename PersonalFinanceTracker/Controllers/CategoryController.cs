using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.DTOs.Category;
using PersonalFinanceTracker.Helpers;
using PersonalFinanceTracker.Interfaces;
using PersonalFinanceTracker.Mappers;
using PersonalFinanceTracker.Repositories;
using System.Security.Claims;
using System.Xml;

namespace PersonalFinanceTracker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.GetUserId(); // User.FindFirstValue(ClaimTypes.NameIdentifier);
            var categories = await _categoryRepository.GetAllAsync(userId);

            return Ok(categories.Select(c => c.ToCategoryDto()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var userId = User.GetUserId(); // User.FindFirstValue(ClaimTypes.NameIdentifier);
            var category = await _categoryRepository.GetByIdAsync(id, userId);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category.ToCategoryDto());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryRequestDto request)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            var userId = User.GetUserId(); // User.FindFirstValue(ClaimTypes.NameIdentifier);
            var category = request.ToCategory(userId);
            var createdCategory = await _categoryRepository.AddAsync(category);

            return CreatedAtAction(nameof(GetById), new { id = createdCategory.Id }, createdCategory.ToCategoryDto());
        }
    }
}
