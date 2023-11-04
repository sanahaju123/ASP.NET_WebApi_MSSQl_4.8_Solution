


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
    public class ExceptionalTests
    {
        private readonly ITestOutputHelper _output;
        private readonly IExpenseService _expenseService;
        public readonly Mock<IExpenseRepository> expenseservice = new Mock<IExpenseRepository>();

        private readonly Expense _expense;

        private static string type = "Exception";

        public ExceptionalTests(ITestOutputHelper output)
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
        public async Task<bool> Testfor_Validate_ifInvalidExpenseIdIsPassed()
        {
            //Arrange
            bool res = false;
            _expense.Id= 0;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                expenseservice.Setup(repo => repo.CreateExpense(_expense)).ReturnsAsync(_expense);
                var result = await _expenseService.CreateExpense(_expense);
                if (result != null || result.Id !=0)
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
        public async Task<bool> Testfor_Validate_ifInvalidExpenseAmountIsPassed()
        {
            //Arrange
            bool res = false;
            _expense.Amount = 10;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                expenseservice.Setup(repo => repo.CreateExpense(_expense)).ReturnsAsync(_expense);
                var result = await _expenseService.CreateExpense(_expense);
                if (result != null || result.Amount > 0)
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
        public async Task<bool> Testfor_Validate_ifInvalidExpenseDateIsPassed()
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
                if (result != null || result.Date <= DateTime.Now)
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
        public async Task<bool> Testfor_Validate_ifInvalidExpenseDescriptionIsPassed()
        {
            //Arrange
            bool res = false;
            _expense.Amount = 10;
            string testName; string status;
            testName = CallAPI.GetCurrentMethodName();

            //Action
            try
            {
                expenseservice.Setup(repo => repo.CreateExpense(_expense)).ReturnsAsync(_expense);
                var result = await _expenseService.CreateExpense(_expense);
                if (result != null || result.Description !=null)
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