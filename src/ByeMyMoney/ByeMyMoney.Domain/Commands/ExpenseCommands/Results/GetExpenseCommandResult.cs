using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.ExpenseCommands.Results
{
    public class GetExpenseCommandResult: ICommandResult
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string Favored { get; set; }
        public string Payment { get; set; }
        public decimal Value { get; set; }
    }
}
