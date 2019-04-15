using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Inputs
{
    public class UpdateAccountantCommand: ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
