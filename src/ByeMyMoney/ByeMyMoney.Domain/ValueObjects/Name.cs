using ByeMyMoney.Shared.Models;
using Flunt.Validations;

namespace ByeMyMoney.Domain.ValueObjects
{
    public class Name: ValueObject<Name>
    {
        public Name(string value)
        {
            Value = value;

            AddNotifications(new Contract()
                    .IsNotNullOrEmpty(Value, "nome", "Nome não preenchido")
                );

            if (Valid)
                AddNotifications(new Contract()
                    .HasMaxLen(Value, 60, "nome", "Nome deve ter no máximo 60 caracteres")
                    .HasMinLen(Value, 3, "nome", "Nome deve ter no mínimo 3 caracteres")
                );
        }

        public string Value { get; private set; }
    }
}
