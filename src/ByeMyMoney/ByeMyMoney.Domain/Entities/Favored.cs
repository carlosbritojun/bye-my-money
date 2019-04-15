using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Models;
using System;

namespace ByeMyMoney.Domain.Entities
{
    public class Favored: Entity
    {
        public Favored(Guid id, Name name, FavoredType type)
            :base(id)
        {
            Update(name, type);
        }

        public Name Name { get; private set; }
        public FavoredType Type { get; private set; }

        public void Update(Name name, FavoredType type)
        {
            AddNotifications(name);
            if (type == null) AddNotification("type", "Tipo de favorecido não informado");

            if (Invalid) return;

            Name = name;
            Type = type;
        }
    }
}
