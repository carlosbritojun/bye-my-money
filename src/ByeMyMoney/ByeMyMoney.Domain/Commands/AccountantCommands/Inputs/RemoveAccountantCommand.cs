using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Inputs
{
    public class RemoveAccountantCommand: ICommand
    {
        public RemoveAccountantCommand() { }
        public RemoveAccountantCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
