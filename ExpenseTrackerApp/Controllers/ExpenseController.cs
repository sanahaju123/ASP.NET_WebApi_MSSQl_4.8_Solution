using ExpenseTrackerApp.DAL.Interrfaces;
using ExpenseTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ExpenseTrackerApp.Controllers
{
    public class ExpenseController : ApiController
    {
        private readonly IExpenseService _service;
        public ExpenseController(IExpenseService service)
        {
            _service = service;
        }
        public ExpenseController()
        {
            // Constructor logic, if needed
        }
        [HttpPost]
        [Route("api/Expense/CreateExpense")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateExpense([FromBody] Expense model)
        {
            var leaveExists = await _service.GetExpenseById(model.Id);
            var result = await _service.CreateExpense(model);
            return Ok(new Response { Status = "Success", Message = "Expense created successfully!" });
        }


        [HttpPut]
        [Route("api/Expense/UpdateExpense")]
        public async Task<IHttpActionResult> UpdateExpense([FromBody] Expense model)
        {
            var result = await _service.UpdateExpense(model);
            return Ok(new Response { Status = "Success", Message = "Expense updated successfully!" });
        }


        [HttpDelete]
        [Route("api/Expense/DeleteExpense")]
        public async Task<IHttpActionResult> DeleteExpense(long id)
        {
            var result = await _service.DeleteExpenseById(id);
            return Ok(new Response { Status = "Success", Message = "Expense deleted successfully!" });
        }


        [HttpGet]
        [Route("api/Expense/GetExpenseById")]
        public async Task<IHttpActionResult> GetExpenseById(long id)
        {
            var expense = await _service.GetExpenseById(id);
            return Ok(expense);
        }


        [HttpGet]
        [Route("api/Expense/GetAllExpenses")]
        public async Task<IEnumerable<Expense>> GetAllExpenses()
        {
            return _service.GetAllExpenses();
        }
    }
}
