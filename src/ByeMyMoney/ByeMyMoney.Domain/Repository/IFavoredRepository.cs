using ByeMyMoney.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ByeMyMoney.Domain.Repository
{
    public interface IFavoredRepository
    {
        void Create(Favored entity);
        void Update(Favored entity);
        void Delete(Guid id);

        Favored Get(Guid id);
        IList<Favored> Get();
    }
}
