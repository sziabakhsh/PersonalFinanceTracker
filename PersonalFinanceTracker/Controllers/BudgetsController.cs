using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.Services;
using PersonalFinanceTracker.Interfaces;
using System.Security.Claims;
using System.Xml;
using Microsoft.AspNetCore.Authorization;
using PersonalFinanceTracker.Entities;
using PersonalFinanceTracker.Mappers;
using PersonalFinanceTracker.DTOs.Budget;
using PersonalFinanceTracker.Helpers;

namespace PersonalFinanceTracker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetRepository _budgetRepository;
        public BudgetsController(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.GetUserId(); // User.FindFirstValue(ClaimTypes.NameIdentifier);
            var budgets = await _budgetRepository.GetAllAsync(userId);

            return Ok(budgets.Select(b => b.ToBudgetDto()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var userId = User.GetUserId(); // User.FindFirstValue(ClaimTypes.NameIdentifier);
            var budget = await _budgetRepository.GetByIdAsync(id, userId);
            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget.ToBudgetDto());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BudgetRequestDto request)
        {
            var userId = User.GetUserId(); // User.FindFirstValue(ClaimTypes.NameIdentifier);
            var budget = request.ToBudget(userId);           
            var createdBudget = await _budgetRepository.AddAsync(budget);

            return CreatedAtAction(nameof(GetById), new { id = createdBudget.Id }, createdBudget);
        }
    }
}
