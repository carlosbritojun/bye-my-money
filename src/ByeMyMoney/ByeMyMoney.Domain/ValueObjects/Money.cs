using ByeMyMoney.Shared.Models;
using Flunt.Validations;

namespace ByeMyMoney.Domain.ValueObjects
{
    public class Money: ValueObject<Money>
    {
        public Money(decimal value)
        {
            Value = value;

            AddNotifications(new Contract()
                    .IsGreaterThan(value, 0, "valor", "Valor deve ser maior que zero")
                );
        }

        public decimal Value { get; private set; }
    }
}
