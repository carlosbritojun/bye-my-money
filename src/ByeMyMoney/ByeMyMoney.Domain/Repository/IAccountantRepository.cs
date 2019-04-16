using ByeMyMoney.Domain.Commands.AccountantCommands.Results;
using ByeMyMoney.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ByeMyMoney.Domain.Repository
{
    public interface IAccountantRepository
    {
        void Create(Accountant entity);
        void Update(Accountant entity);
        void Delete(Accountant entity);

        Accountant Get(Guid id);
        Accountant GetByEmail(string email);

        GetAccountantCommandResult GetCommandResult(Guid id);
        IEnumerable<GetAccountantListCommandResult> GetListCommandResult();
    }
}
