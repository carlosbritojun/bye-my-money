using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Inputs
{
    public class RemoveAccountantCommand: ICommand
    {
        public Guid Id { get; set; }
    }
}
