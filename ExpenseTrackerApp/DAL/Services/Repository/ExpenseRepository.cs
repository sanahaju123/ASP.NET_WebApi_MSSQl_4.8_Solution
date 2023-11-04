using ExpenseTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ExpenseTrackerApp.DAL.Services.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly DatabaseContext _dbContext;
        public ExpenseRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Expense> CreateExpense(Expense expense)
        {
            try
            {
                var result =  _dbContext.Expenses.Add(expense);
                await _dbContext.SaveChangesAsync();
                return expense;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteExpenseById(long id)
        {
            try
            {
                _dbContext.Expenses.Remove(_dbContext.Expenses.Single(a => a.Id == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Expense> GetAllExpenses()
        {
            try
            {
                var result = _dbContext.Expenses.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Expense> GetExpenseById(long id)
        {
            try
            {
                return await _dbContext.Expenses.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

      
        

        public async Task<Expense> UpdateExpense(Expense model)
        {
            var ex = await _dbContext.Expenses.FindAsync(model.Id);
            try
            {
                ex.Amount = model.Amount;
                ex.Date = model.Date;
                ex.Description = model.Description;
                ex.Id = model.Id;

                await _dbContext.SaveChangesAsync();
                return ex;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
    }
}