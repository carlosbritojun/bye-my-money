using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Inputs
{
    public class AddBankAccountCommand: ICommand
    {
        public AddBankAccountCommand() { }
        public AddBankAccountCommand(Guid id, string bankName, string number)
        {
            Id = id;
            BankName = bankName;
            Number = number;
        }

        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string Number { get; set; }
    }
}
