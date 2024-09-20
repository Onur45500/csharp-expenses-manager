using csharp_expenses_manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace csharp_expenses_manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExpensesContext _context;

        public HomeController(ILogger<HomeController> logger, ExpensesContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            return View(allExpenses);
        }

        public IActionResult CreateOrEdit(int? id)
        {
            if(id != null)
            {
                var expense = _context.Expenses.SingleOrDefault(Expense => Expense.Id == id);

                return View(expense);
            }
            
            return View();
        }

        public IActionResult DeleteExpense(int id)
        {
            var expense = _context.Expenses.SingleOrDefault(Expense => Expense.Id == id);

            _context.Expenses.Remove(expense);

            _context.SaveChanges();

            return RedirectToAction("Expenses");
        }

        public IActionResult CreateOrEditForm(Expense model)
        {
            if(model.Id == 0)
            {
                _context.Expenses.Add(model);

                _context.SaveChanges();
            }
            else
            {
                _context.Expenses.Update(model);

                _context.SaveChanges();
            }
            
            return RedirectToAction("Expenses");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
