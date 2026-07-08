//Full Name - Mohammed Zubair Mohammed Salman
//Student Id - N01795248
//Humber Polytechnic - Software Development Bridging Program Back-End
//Assignment 3 



/**********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudget.Core
{ 

    public static class ExpenseFactory
    {
        public static OneTimeExpense CreateOneTime(string description, decimal amount, 
            ExpenseCategory category, DateOnly date)
        {
            Validate(description, amount);

            return new OneTimeExpense(Guid.NewGuid(), description.Trim(),
                amount, category, date);
        }

        public static RecurringExpense CreateRecurring(string description, decimal amount,
            ExpenseCategory category, DateOnly date, int timesPerMonth)
        {
            Validate(description, amount);
            if (timesPerMonth <= 0)
                throw new InvalidExpenseException("Times per month must be greater than zero.");

            return new RecurringExpense( Guid.NewGuid(), description.Trim(),
                amount, category, date, timesPerMonth);
        }

        private static void Validate(string description, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new InvalidExpenseException("Description cannot be empty.");

            if (amount <= 0)
                throw new InvalidExpenseException("Amount must be greater than zero.");
        }
        public static decimal ValidateAmount(decimal amount)
        {
            if (amount <= 0 || amount > 1000000)
                throw new InvalidExpenseException("Amount must be greater than zero.");
            return Math.Round(amount, 2);            
        }
    }
}
