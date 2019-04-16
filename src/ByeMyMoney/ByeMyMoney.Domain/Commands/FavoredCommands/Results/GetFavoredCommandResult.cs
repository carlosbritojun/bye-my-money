using System;

namespace ByeMyMoney.Domain.Commands.FavoredCommands.Results
{
    public class GetFavoredCommandResult
    {
        public GetFavoredCommandResult(Guid id, string name, Guid favoredType)
        {
            Id = id;
            Name = name;
            FavoredType = favoredType;
        }

        public Guid Id { get; }
        public string Name { get; }
        public Guid FavoredType { get; }
    }
}
