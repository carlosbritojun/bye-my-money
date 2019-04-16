using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.FavoredTypeCommands.Inputs
{
    public class UpdateFavoredTypeCommand: ICommand
    {
        public UpdateFavoredTypeCommand() { }
        public UpdateFavoredTypeCommand(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
    }
}
