using ExpenseManager.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;



namespace ExpenseManager.Controllers
{
    
    public class ExpenseController : Controller
    {
        private static IList<ExpenseModel> expenses = new List<ExpenseModel>()
        {
            new ExpenseModel(){ExpenseId = 1, Name = "batonik", Description = "Snickers z żabki", Amount = 2.99M, Date = new DateTime(2021, 5, 1, 8, 30, 52), Category = 0},
            new ExpenseModel(){ExpenseId = 2, Name = "Telefon", Description = "samsung galaxy", Amount = 2999, Date = new DateTime(2021, 5, 1, 8, 30, 52), Category = 1}
        };
        // GET: ExpenseController
        public ActionResult Index()
        {
            return View(expenses);
        }

        // GET: ExpenseController/Details/5
        public ActionResult Details(int id)
        {
            return View(expenses.FirstOrDefault(x => x.ExpenseId == id)); //dzieki metodzie FirstOrDefault wyszukuje element o podanym id
        }

        // GET: ExpenseController/Create
        public ActionResult Create()
        {
            return View(new ExpenseModel());
        }

        // POST: ExpenseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExpenseModel expenseModel)
        {
            expenseModel.ExpenseId = expenses.Count + 1; //"tworzenie" kolejnych identyfikatorów (dodaję 1 w liście) przeliczenie wszystkich elementów +1
            expenses.Add(expenseModel);                  //do listy expenses dodaje obiekt przesłany w parametrze expenseModel
            return RedirectToAction(nameof(Index));
            
        }

        // GET: ExpenseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(expenses.FirstOrDefault(x => x.ExpenseId == id));
        }

        // POST: ExpenseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ExpenseModel expenseModel)
        {
            ExpenseModel expense = expenses.FirstOrDefault(x => x.ExpenseId == id);
            expense.Name = expenseModel.Name;
            expense.Description = expenseModel.Description;
            expense.Date = expenseModel.Date;
            expense.Amount = expenseModel.Amount;
            expense.Category = expenseModel.Category;
            return RedirectToAction(nameof(Index));
            
        }

        // GET: ExpenseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(expenses.FirstOrDefault(x => x.ExpenseId == id));
        }

        // POST: ExpenseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ExpenseModel expenseModel)
        {
            ExpenseModel expense = expenses.FirstOrDefault(x => x.ExpenseId == id);
            expenses.Remove(expense);
            return RedirectToAction(nameof(Index));
        }
            
    }
}
