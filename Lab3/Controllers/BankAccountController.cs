using Application.IServices;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    [ApiController]
    [Route("api/bankaccounts")]
    public class BankAccountController(IBankAccountService bankAccountService) : Controller
    {
        private readonly IBankAccountService _bankAccountService = bankAccountService;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return BadRequest("Please login first");
            }
            return Ok(_bankAccountService.GetByUserId(int.Parse(HttpContext.Session.GetString("User"))));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return BadRequest("Please login first");
            }
            List<BankAccount> bankAccounts = _bankAccountService.GetByUserId(int.Parse(HttpContext.Session.GetString("User")));
            if (bankAccounts.Find(bankAccount => bankAccount.Id == id) == null)
            {
                return BadRequest("You do not have permission to access this account");
            }
            return Ok(bankAccounts.Find(bankAccount => bankAccount.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BankAccountRequest request)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User"))){
                return BadRequest("Please login first");
            }
            var userid = int.Parse(HttpContext.Session.GetString("User"));
            var newBankAccount = new BankAccount
            {
                AccountName = request.AccountName,
                Balance = request.Balance,
                UserId = userid
            };
            var createdBankAccount = await _bankAccountService.Add(newBankAccount);
            return CreatedAtAction(nameof(Get), new { id = createdBankAccount.Id }, createdBankAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] BankAccountRequest request)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return BadRequest("Please login first");
            }
            var userid = int.Parse(HttpContext.Session.GetString("User"));

            BankAccount bankAccountUpdate = await _bankAccountService.GetById(id) ?? throw new Exception("Not Found");
            if(bankAccountUpdate.UserId != userid)
            {
                return BadRequest("You do not have permission to access this account");
            }

            var updateBankAccount = new BankAccount
            {
                AccountName = request.AccountName,
                Balance = request.Balance,
                UserId = userid
            };
            return Ok(await _bankAccountService.Update(id, updateBankAccount));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("User")))
            {
                return BadRequest("Please login first");
            }
            List<BankAccount> bankAccounts = _bankAccountService.GetByUserId(int.Parse(HttpContext.Session.GetString("User")));
            if (bankAccounts.Find(bankAccount => bankAccount.Id == id) == null)
            {
                return BadRequest("You do not have permission to access this account");
            }
            await _bankAccountService.Delete(id);
            return NoContent();
        }
    }
    public class BankAccountRequest
    {
        public string AccountName { get; set; }
        public double Balance { get; set; }
    }
}
