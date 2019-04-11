using ByeMyMoney.Shared.Models;
using Flunt.Validations;

namespace ByeMyMoney.Domain.ValueObjects
{
    public class Email: ValueObject<Email>
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new Contract()
                    .IsEmail(Address, "e-mail", "E-email inválido")
                );
        }

        public string Address { get; private set; }
    }
}
