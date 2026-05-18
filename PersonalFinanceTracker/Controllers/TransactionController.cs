using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceTracker.DTOs.Transaction;
using PersonalFinanceTracker.Helpers;
using PersonalFinanceTracker.Interfaces;
using PersonalFinanceTracker.Mappers;
using System.Security.Claims;
using System.Xml;

namespace PersonalFinanceTracker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.GetUserId(); // User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transactions = await _transactionRepository.GetAllAsync(userId);

            return Ok(transactions.Select(t => t.ToTransactionDto()));
        }

        [Authorize]
        [HttpGet("id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var userId = User.GetUserId(); // User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transaction = await _transactionRepository.GetByIdAsync(id, userId);
            return Ok(transaction.ToTransactionDto());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionRequestDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.GetUserId(); // User.FindFirstValue(ClaimTypes.NameIdentifier);
            var transaction = request.ToTransaction(userId);
            var createdTransaction = await _transactionRepository.AddAsync(transaction);

            return CreatedAtAction(nameof(GetById), new { id = createdTransaction.Id }, createdTransaction.ToTransactionDto());
        }
    }
}
