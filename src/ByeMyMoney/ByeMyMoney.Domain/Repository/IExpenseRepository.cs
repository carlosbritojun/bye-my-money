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
        void Delete(Guid id);

        Expense Get(Guid id);
        IEnumerable<GetExpenseListCommandResult> Get();
    }
}
