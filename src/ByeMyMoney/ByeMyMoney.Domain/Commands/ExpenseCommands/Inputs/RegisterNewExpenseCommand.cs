using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.ExpenseCommands.Inputs
{
    public class RegisterNewExpenseCommand: ICommand
    {
        public RegisterNewExpenseCommand() { }
        public RegisterNewExpenseCommand(Guid owner, Guid account, string description, Guid favored, decimal value)
        {
            Owner = owner;
            Account = account;
            Description = description;
            Favored = favored;
            Value = value;
        }

        public Guid Owner { get; set; }
        public Guid Account { get; set; }
        public string Description { get; set; }
        public Guid Favored { get; set; }
        public decimal Value { get; set; }
    }
}
