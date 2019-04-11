using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.ExpenseCommands.Inputs
{
    public class RemoveExpenseCommand: ICommand
    {
        public Guid Id { get; set; }
    }
}
