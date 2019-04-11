using ByeMyMoney.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ByeMyMoney.Domain.Repository
{
    public interface IFavoredTypeRepository
    {
        void Create(FavoredType entity);
        void Update(FavoredType entity);
        void Delete(Guid id);

        FavoredType Get(Guid id);
        IList<FavoredType> Get();
    }
}
