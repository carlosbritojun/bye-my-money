using ByeMyMoney.Shared.Models;
using Flunt.Validations;

namespace ByeMyMoney.Domain.ValueObjects
{
    public class Description: ValueObject<Description>
    {
        public Description(string value)
        {
            Value = value;

            AddNotifications(new Contract()
                    .IsNotNullOrEmpty(Value, "descricao", "Descrição não preenchida")
                );

            if (Valid)
                AddNotifications(new Contract()
                      .HasMaxLen(Value, 60, "descricao", "Descrição deve ter no máximo 60 caracteres")
                      .HasMinLen(Value, 3, "descricao", "Descrição deve ter no mínimo 3 caracteres")
                   );
        }

        public string Value { get; private set; }
    }
}
