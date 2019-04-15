using System;
using System.Collections.Generic;
using System.Text;

namespace ByeMyMoney.Shared.Transactions
{
    public interface IUnitOfWork: IDisposable
    {
        bool Commit();
    }
}
