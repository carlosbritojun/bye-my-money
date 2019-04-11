using ByeMyMoney.Domain.Enums;
using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Models;
using Flunt.Validations;
using System;

namespace ByeMyMoney.Domain.Entities
{
    public class Expense: Entity
    {
        public Expense(Accountant owner, Description description, Favored favored, Money value)
        {
            Owner = owner;
            Update(description, favored, value);
            State = EExpenseState.Opened;
            CreatedDate = DateTime.Now;
            PaidDate = null;
        }

        public Accountant Owner { get; private set; }
        public Description Description { get; private set; }
        public Favored Favored { get; private set; }
        public PaymentType Type { get; private set; }
        public string Number { get; private set; }
        public EExpenseState State { get; private set; }
        public Money Value { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? PaidDate { get; private set; }

        public void Update(Description description, Favored favored, Money value)
        {
            AddNotifications(description, favored, value);

            if (Invalid) return;

            Description = description;
            Favored = favored;
            Value = value;
        }

        public void Pay(PaymentType type, string number)
        {
            AddNotifications(type, new Contract()
                    .IsNullOrEmpty(number, "número", "Número da conta corrente não informada")
                );

            if (Invalid) return;

            Type = type;
            Number = number;
            PaidDate = DateTime.Now;
            State = EExpenseState.Paid;
        }

        public void CancelPayment()
        {
            AddNotifications(new Contract()
                    .IsTrue(State == EExpenseState.Opened, "status", "Pagamento em aberto não pode ser cancelado")
                );

            if (Invalid) return;

            Type = null;
            Number = null;
            PaidDate = null;
            State = EExpenseState.Opened;
        }
    }
}
