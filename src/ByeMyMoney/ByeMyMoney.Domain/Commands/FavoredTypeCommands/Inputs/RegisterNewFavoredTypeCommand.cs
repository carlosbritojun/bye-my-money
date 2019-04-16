using ByeMyMoney.Shared.Commands;

namespace ByeMyMoney.Domain.Commands.FavoredTypeCommands.Inputs
{
    public class RegisterNewFavoredTypeCommand: ICommand
    {
        public RegisterNewFavoredTypeCommand() { }
        public RegisterNewFavoredTypeCommand(string description)
        {
            Description = description;
        }

        public string Description { get; set; }
    }
}
