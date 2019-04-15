using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Inputs
{
    public class RemoveBankAccountCommand: ICommand
    {
        public RemoveBankAccountCommand() { }
        public RemoveBankAccountCommand(Guid id, Guid accountId)
        {
            Id = id;
            AccountId = accountId;
        }

        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
    }
}
