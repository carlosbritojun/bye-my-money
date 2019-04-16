using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.PaymentTypeCommands.Results
{
    public class GetPaymentTypeCommandResult: ICommandResult
    {
        public GetPaymentTypeCommandResult(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public Guid Id { get; }
        public string Description { get; }
    }
}
