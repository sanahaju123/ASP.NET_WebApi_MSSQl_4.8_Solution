using ExpenseTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerApp.DAL.Services.Repository
{
    public interface IExpenseRepository
    {
        List<Expense> GetAllExpenses();
        Task<Expense> CreateExpense(Expense expense);
        Task<Expense> GetExpenseById(long id);
        Task<bool> DeleteExpenseById(long id);
        Task<Expense> UpdateExpense(Expense model);
    }
}

