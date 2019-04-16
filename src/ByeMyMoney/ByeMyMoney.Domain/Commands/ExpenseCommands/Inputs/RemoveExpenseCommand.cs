using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.ExpenseCommands.Inputs
{
    public class RemoveExpenseCommand: ICommand
    {
        public RemoveExpenseCommand() { }
        public RemoveExpenseCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
