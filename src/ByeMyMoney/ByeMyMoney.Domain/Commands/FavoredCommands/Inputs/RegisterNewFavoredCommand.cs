using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.FavoredCommands.Inputs
{
    public class RegisterNewFavoredCommand: ICommand
    {
        public RegisterNewFavoredCommand() { }
        public RegisterNewFavoredCommand(string name, Guid favoredType)
        {
            Name = name;
            FavoredType = favoredType;
        }

        public string Name { get; set; }
        public Guid FavoredType { get; set; }
    }
}
