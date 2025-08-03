using KassaPro.Data;
using KassaPro.Data.Entities;
using KassaPro.DTOs.Accounts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KassaPro.Controllers.Api.V1;

[ApiController]
[Route("api/v1/account")]
public class AccountController : ControllerBase
{
    private readonly PosContext _context;

    public AccountController(PosContext context)
    {
        _context = context;
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetList(int limit = 10, int offset = 1)
    {
        var query = _context.Accounts.OrderByDescending(a => a.Id);

        var total = await query.CountAsync();
        var items = await query.Skip((offset - 1) * limit).Take(limit).ToListAsync();

        return Ok(new
        {
            total,
            limit,
            offset,
            accounts = items
        });
    }

    [HttpPost("save")]
    public async Task<IActionResult> Create([FromBody] AccountCreateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        bool exists = await _context.Accounts.AnyAsync(a => a.Account1 == dto.Account || a.AccountNumber == dto.AccountNumber);
        if (exists)
            return Conflict(new { message = "Account or account number already exists." });

        var account = new Account
        {
            Account1 = dto.Account,
            AccountNumber = dto.AccountNumber,
            Description = dto.Description,
            // Balance = dto.Balance,
            CreatedAt = DateTime.UtcNow
        };

        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return Ok(new { success = true, message = "Account saved successfully" });
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] AccountUpdateDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var account = await _context.Accounts.FindAsync(dto.Id);
        if (account == null) return NotFound();

        bool duplicate = await _context.Accounts
            .AnyAsync(a => (a.Account1 == dto.Account || a.AccountNumber == dto.AccountNumber) && a.Id != dto.Id);

        if (duplicate)
            return Conflict(new { message = "Account or account number already exists." });

        account.Account1 = dto.Account;
        account.AccountNumber = dto.AccountNumber;
        account.Description = dto.Description;
        account.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(new { success = true, message = "Account updated successfully" });
    }

    [HttpGet("delete")]
    public async Task<IActionResult> Delete(ulong id)
    {
        var account = await _context.Accounts
            .Where(a => a.Account1 != "Receivable" && a.Account1 != "Cash" && a.Account1 != "Payable")
            .FirstOrDefaultAsync(a => a.Id == id);

        if (account == null)
            return NotFound(new { success = false, message = "Account not found or cannot be deleted." });

        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();

        return Ok(new { success = true, message = "Account deleted successfully" });
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string? name, int limit = 10, int offset = 1)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return Ok(new
            {
                total = 0,
                limit,
                offset,
                accounts = new List<Account>()
            });
        }

        var query = _context.Accounts
            .Where(a => a.Account1.Contains(name) || a.AccountNumber.Contains(name))
            .OrderByDescending(a => a.Id);

        var total = await query.CountAsync();
        var items = await query.Skip((offset - 1) * limit).Take(limit).ToListAsync();

        return Ok(new
        {
            total,
            limit,
            offset,
            accounts = items
        });
    }
}
