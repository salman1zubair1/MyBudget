using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudget.Core
{ 
    public sealed class ExpenseRepository : IExpenseRepository
    {
        private readonly IExpenseStore store;
        private readonly List<Expense> expenses;

        public ExpenseRepository(IExpenseStore store)
        {
            this.store = store;
            expenses = store.Load().ToList();
        }

        public IReadOnlyList<Expense> GetAll()
        {
            return expenses.AsReadOnly();
        }

        public void Add(Expense expense)
        {
            expenses.Add(expense);
        }

        public decimal Total()
        {
            return expenses.Sum(e => e.MonthlyImpact);
        }

        public IReadOnlyDictionary<ExpenseCategory, decimal> TotalsByCategory()
        {
            return expenses.GroupBy(e => e.Category).ToDictionary( g => g.Key, 
                g => g.Sum(e => e.MonthlyImpact));
        }

        public IReadOnlyList<Expense> InCategory(ExpenseCategory category)
        {
            return expenses.Where(e => e.Category == category).ToList().AsReadOnly();
        }

        public void Save()
        {
            store.Save(expenses);
        }
    }
}
