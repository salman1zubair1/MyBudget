using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudget.Core
{ 
    public sealed class BudgetService : IBudgetService
    {
        public decimal MonthlyLimit { get; private set; }

        public void SetMonthlyLimit(decimal limit)
        {
            if (limit <= 0)
                throw new InvalidExpenseException("Budget must be greater than zero.");

            MonthlyLimit = limit;
        }

        public decimal Remaining(decimal totalSpent)
        {
            if (MonthlyLimit <= 0)
                return 0;

            return MonthlyLimit - totalSpent;
        }

        public BudgetStatus Evaluate(decimal totalSpent)
        {
            if (MonthlyLimit == 0)
                return BudgetStatus.NotSet;

            if (totalSpent > MonthlyLimit)
                return BudgetStatus.OverBudget;

            if (totalSpent > MonthlyLimit * 0.90m)
                return BudgetStatus.AlmostOut;

            return BudgetStatus.OnTrack;
        }
    }
}
