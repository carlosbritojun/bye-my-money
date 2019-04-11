using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Models;
using Flunt.Validations;

namespace ByeMyMoney.Domain.Entities
{
    public class BankAccount: Entity
    {
        public BankAccount(Name bankName, string number)
        {
            Update(bankName, number);
        }

        public Accountant Owner { get; private set; }
        public Name BankName { get; private set; }
        public string Number { get; private set; }

        public void SetOwner(Accountant owner)
        {
            this.Owner = owner;
        }

        public void Update(Name bankName, string number)
        {
            AddNotifications(bankName, 
                new Contract()
                    .IsNullOrEmpty(Number, "número", "Número de conta corrente não informado")
                );

            if (Invalid) return;

            BankName = bankName;
            Number = number;
        }
    }
}
