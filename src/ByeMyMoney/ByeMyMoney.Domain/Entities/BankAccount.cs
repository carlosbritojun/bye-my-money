using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Models;
using Flunt.Validations;
using System;

namespace ByeMyMoney.Domain.Entities
{
    public class BankAccount: Entity
    {
        public BankAccount(Guid id, Name bankName, string number)
            :base(id)
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
                    .IsNotNullOrEmpty(number, "número", "Número de conta corrente não informado")
                );

            if (Invalid) return;

            BankName = bankName;
            Number = number;
        }
    }
}
