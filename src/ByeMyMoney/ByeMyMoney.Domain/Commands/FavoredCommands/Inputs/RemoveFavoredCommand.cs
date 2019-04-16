using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.FavoredCommands.Inputs
{
    public class RemoveFavoredCommand: ICommand
    {
        public RemoveFavoredCommand() { }
        public RemoveFavoredCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
