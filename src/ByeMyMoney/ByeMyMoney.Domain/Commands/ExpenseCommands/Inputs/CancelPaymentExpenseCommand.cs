using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.ExpenseCommands.Inputs
{
    public class CancelPaymentExpenseCommand: ICommand
    {
        public Guid Id { get; set; }
    }
}
