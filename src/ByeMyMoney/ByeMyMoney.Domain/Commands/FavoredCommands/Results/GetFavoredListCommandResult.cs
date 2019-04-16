using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.FavoredCommands.Results
{
    public class GetFavoredListCommandResult: ICommandResult
    {
        public GetFavoredListCommandResult(Guid id, string name, Guid favoredType, string favoredTypeDescription)
        {
            Id = id;
            Name = name;
            FavoredType = favoredType;
            FavoredTypeDescription = favoredTypeDescription;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid FavoredType { get; }
        public string FavoredTypeDescription { get; }
    }
}
