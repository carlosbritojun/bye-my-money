using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Results
{
    public class GetAccountantCommandResult: ICommandResult
    {
        public GetAccountantCommandResult(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Email { get; }
    }
}
