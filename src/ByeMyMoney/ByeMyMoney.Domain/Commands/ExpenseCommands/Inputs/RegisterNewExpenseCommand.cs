using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.ExpenseCommands.Inputs
{
    public class RegisterNewExpenseCommand: ICommand
    {
        public Guid Owner { get; set; }
        public string Description { get; set; }
        public Guid Favored { get; set; }
        public decimal Value { get; set; }
    }
}
