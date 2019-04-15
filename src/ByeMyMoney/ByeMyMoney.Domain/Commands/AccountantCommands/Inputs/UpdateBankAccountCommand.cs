using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Inputs
{
    public class UpdateBankAccountCommand: ICommand
    {
        public UpdateBankAccountCommand() { }
        public UpdateBankAccountCommand(Guid id, Guid accountId, string bankName, string number)
        {
            Id = id;
            AccountId = accountId;
            BankName = bankName;
            Number = number;
        }

        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string BankName { get; set; }
        public string Number { get; set; }
    }
}
