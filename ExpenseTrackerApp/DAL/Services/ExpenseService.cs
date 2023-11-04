using ExpenseTrackerApp.DAL.Interrfaces;
using ExpenseTrackerApp.DAL.Services.Repository;
using ExpenseTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExpenseTrackerApp.DAL.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repository;

        public ExpenseService(IExpenseRepository repository)
        {
            _repository = repository;
        }

        public Task<Expense> CreateExpense(Expense expense)
        {
            return _repository.CreateExpense(expense);
        }

        public Task<bool> DeleteExpenseById(long id)
        {
            return _repository.DeleteExpenseById(id);
        }

        public List<Expense> GetAllExpenses()
        {
            return _repository.GetAllExpenses();
        }

        public Task<Expense> GetExpenseById(long id)
        {
            return _repository.GetExpenseById(id); ;
        }

        public Task<Expense> UpdateExpense(Expense model)
        {
            return _repository.UpdateExpense(model);
        }
    }
}