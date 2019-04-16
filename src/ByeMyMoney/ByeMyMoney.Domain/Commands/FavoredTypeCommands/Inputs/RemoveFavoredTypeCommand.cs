using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.FavoredTypeCommands.Inputs
{
    public class RemoveFavoredTypeCommand: ICommand
    {
        public RemoveFavoredTypeCommand() { }
        public RemoveFavoredTypeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
