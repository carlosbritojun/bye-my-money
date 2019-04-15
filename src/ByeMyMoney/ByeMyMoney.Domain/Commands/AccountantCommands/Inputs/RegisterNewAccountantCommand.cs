using ByeMyMoney.Shared.Commands;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Inputs
{
    public class RegisterNewAccountantCommand: ICommand
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
