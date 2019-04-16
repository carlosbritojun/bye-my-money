using ByeMyMoney.Domain.Commands.FavoredTypeCommands.Results;
using ByeMyMoney.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ByeMyMoney.Domain.Repository
{
    public interface IFavoredTypeRepository
    {
        void Create(FavoredType entity);
        void Update(FavoredType entity);
        void Delete(FavoredType entity);

        FavoredType Get(Guid id);

        GetFavoredTypeCommandResult GetCommandResult(Guid id);
        IEnumerable<GetFavoredTypeListCommandResult> GetListCommandResult();
    }
}
