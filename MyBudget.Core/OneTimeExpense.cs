//Full Name - Mohammed Zubair Mohammed Salman
//Student Id - N01795248
//Humber Polytechnic - Software Development Bridging Program Back-End
//Assignment 3 



/**********************************************************************************************/

using MyBudget.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBudget.Core
{
    public sealed record OneTimeExpense(Guid Id, string Description, decimal Amount,
        ExpenseCategory Category, DateOnly Date)
        : Expense(Id, Description, Amount, Category, Date)
    {
        public override decimal MonthlyImpact => Amount;
    }
}
