using ByeMyMoney.Domain.Commands.PaymentTypeCommands.Results;
using ByeMyMoney.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ByeMyMoney.Domain.Repository
{
    public interface IPaymentTypeRepository
    {
        void Create(PaymentType entity);
        void Update(PaymentType entity);
        void Delete(Guid id);

        PaymentType Get(Guid id);

        GetPaymentTypeCommandResult GetCommandResult();
        IEnumerable<GetPaymentTypeListCommandResult> GetListCommandResult();
    }
}
