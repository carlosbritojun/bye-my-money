using ByeMyMoney.Domain.Commands.ExpenseCommands.Results;
using ByeMyMoney.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ByeMyMoney.Domain.Repository
{
    public interface IExpenseRepository
    {
        void Create(Expense entity);
        void Update(Expense entity);
        void Delete(Expense entit);

        Expense Get(Guid id);

        GetExpenseCommandResult GetCommandResult(Guid id);
        IEnumerable<GetExpenseListCommandResult> GetListCommandResult(Guid account);
    }
}
