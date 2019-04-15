﻿using ByeMyMoney.Shared.Commands;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Inputs
{
    public class RegisterNewAccountantCommand: ICommand
    {
        public RegisterNewAccountantCommand() { }
        public RegisterNewAccountantCommand(string name, string email, string password, string confirmPassword)
        {
            Name = name;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
