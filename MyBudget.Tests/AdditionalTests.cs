using MyBudget.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyBudget.Tests
{
    public class AdditionalTests
    {
        [Fact]
        public void OneTimeExpense_MonthlyImpact_EqualsAmount()
        {
            var expense = ExpenseFactory.CreateOneTime(
                "Groceries",
                120m,
                ExpenseCategory.Food,
                new DateOnly(2026, 6, 7));

            Assert.Equal(120m, expense.MonthlyImpact);
        }

        [Fact]
        public void RecurringExpense_MonthlyImpact_MultipliesByTimesPerMonth()
        {
            var expense = ExpenseFactory.CreateRecurring(
                "FIFA",
                15m,
                ExpenseCategory.Entertainment,
                new DateOnly(2026, 6, 7),
                4);

            Assert.Equal(60m, expense.MonthlyImpact);
        }

        [Fact]
        public void BudgetService_ReturnsAlmostOut_WhenLimitAlmostExceeded()
        {
            var budget = new BudgetService();
            budget.SetMonthlyLimit(1300m);

            var status = budget.Evaluate(1200m);

            Assert.Equal(BudgetStatus.AlmostOut, status);
        }


        [Fact]
        public void BudgetService_ReturnsOverBudget_WhenLimitExceeded()
        {
            var budget = new BudgetService();
            budget.SetMonthlyLimit(1000m);

            var status = budget.Evaluate(1200m);

            Assert.Equal(BudgetStatus.OverBudget, status);
        }

        [Fact]
        public void BudgetService_ReturnsOnTrack_WhenLimitNotExceeded()
        {
            var budget = new BudgetService();
            budget.SetMonthlyLimit(1000m);
            var status = budget.Evaluate(800m);
            Assert.Equal(BudgetStatus.OnTrack, status);
        }

    }
}
