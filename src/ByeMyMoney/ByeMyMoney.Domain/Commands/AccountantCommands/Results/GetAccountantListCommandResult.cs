﻿using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Results
{
    public class GetAccountantListCommandResult: ICommandResult
    {
        public GetAccountantListCommandResult(Guid id, string name, string email, int bankAccounts)
        {
            Id = id;
            Name = name;
            Email = email;
            BankAccounts = bankAccounts;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
        public int BankAccounts { get; }
    }
}
