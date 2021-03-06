﻿using ByeMyMoney.Shared.Commands;
using System;

namespace ByeMyMoney.Domain.Commands.FavoredTypeCommands.Results
{
    public class GetFavoredTypeCommandResult: ICommandResult
    {
        public GetFavoredTypeCommandResult(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public Guid Id { get; }
        public string Description { get; }
    }
}
