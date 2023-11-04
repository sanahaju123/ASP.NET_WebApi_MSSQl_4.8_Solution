

using ExpenseTrackerApp.DAL.Interrfaces;
using ExpenseTrackerApp.DAL.Services;
using ExpenseTrackerApp.DAL.Services.Repository;
using ExpenseTrackerApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace ExpenseTrackerApp.Tests.TestCases
{
    public class BoundaryTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IExpenseService _expenseService;
        public readonly Mock<IExpenseRepository> expenseservice = new Mock<IExpenseRepository>();

        private readonly Expense _expense;

        private static string type = "Boundary";

        public BoundaryTests(ITestOutputHelper output)
        {
            _expenseService = new ExpenseService(expenseservice.Object);

            _output = output;

            _expense = new Expense
            {
                Id = 1,
                Amount = 2000,
                Date = DateTime.Now,
                Description = "desc"
            };
        }

        [Fact]
        public async Task<bool> Testfor_Expense_description_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                expenseservice.Setup(repo => repo.CreateExpense(_expense)).ReturnsAsync(_expense);
                var result = await _expenseService.CreateExpense(_expense);
                var actualLength = _expense.Description.ToString().Length;
                if (result.Description.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


        [Fact]
        public async Task<bool> Testfor_Expense_Amount_NotEmpty()
        {
            //Arrange
            bool res = false;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                expenseservice.Setup(repo => repo.CreateExpense(_expense)).ReturnsAsync(_expense);
                var result = await _expenseService.CreateExpense(_expense);
                var actualLength = _expense.Amount.ToString().Length;
                if (result.Amount.ToString().Length == actualLength)
                {
                    res = true;
                }
            }
            catch (Exception)
            {
                //Assert
                status = Convert.ToString(res);
                _output.WriteLine(testName + ":Failed");
                await CallAPI.saveTestResult(testName, status, type);
                return false;
            }
            status = Convert.ToString(res);
            if (res == true)
            {
                _output.WriteLine(testName + ":Passed");
            }
            else
            {
                _output.WriteLine(testName + ":Failed");
            }
            await CallAPI.saveTestResult(testName, status, type);
            return res;
        }


    }
}