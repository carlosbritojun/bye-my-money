using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.FavoredCommands.Inputs
{
    public class UpdateFavoredCommand: ICommand
    {
        public UpdateFavoredCommand() { }
        public UpdateFavoredCommand(Guid id, string name, Guid favoredType)
        {
            Id = id;
            Name = name;
            FavoredType = favoredType;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid FavoredType { get; set; }
    }
}
