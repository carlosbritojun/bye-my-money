using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.ExpenseCommands.Inputs
{
    public class UpdateExpenseCommand: ICommand
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid Favored { get; set; }
        public decimal Value { get; set; }
    }
}
