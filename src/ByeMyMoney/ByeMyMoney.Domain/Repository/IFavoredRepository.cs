using ByeMyMoney.Domain.Commands.FavoredCommands.Results;
using ByeMyMoney.Domain.Entities;
using System;
using System.Collections.Generic;

namespace ByeMyMoney.Domain.Repository
{
    public interface IFavoredRepository
    {
        void Create(Favored entity);
        void Update(Favored entity);
        void Delete(Favored entity);

        Favored Get(Guid id);

        GetFavoredCommandResult GetCommandResult(Guid id);
        IEnumerable<GetFavoredListCommandResult> GetListCommandResult();
    }
}
