//Full Name - Mohammed Zubair Mohammed Salman
//Student Id - N01795248
//Humber Polytechnic - Software Development Bridging Program Back-End
//Assignment 3 



/**********************************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using MyBudget.Core;
using System.Text.Json;

namespace MyBudget.Data
{

    public sealed class JsonExpenseStore : IExpenseStore
    {
        private string fileName = "expenses.json";

        public JsonExpenseStore(string filePath)
        {
            fileName = filePath;
        }

        private readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };

        public IReadOnlyList<Expense> Load()
        {
            if (!File.Exists(fileName))
                return new List<Expense>();

            string json = File.ReadAllText(fileName);

            return JsonSerializer.Deserialize<List<Expense>>(json, options)
                   ?? new List<Expense>();
        }

        public void Save(IEnumerable<Expense> expenses)
        {
            string json = JsonSerializer.Serialize(expenses, options);

            File.WriteAllText(fileName, json);
        }
    }
}
