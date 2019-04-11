using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.ExpenseCommands.Inputs
{
    public class PaymentExpenseCommand: ICommand
    {
        public Guid Id { get; set; }
        public Guid PaymentType { get; set; }
        public string Number { get; set; }
    }
}
