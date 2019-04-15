using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ByeMyMoney.Domain.Entities
{
    public class Accountant: Entity
    {
        public Accountant(Guid id, Name name, User user)
            : base(id)
        {
            Name = name;
            User = user;
            Accounts = new List<BankAccount>();

            AddNotifications(name, user);
        }

        public Name Name { get; private set; }
        public User User { get; private set; }
        public IList<BankAccount> Accounts { get; private set; }

        public void Update(Name name)
        {
            AddNotifications(name);
            if (Invalid) return;

            Name = name;
        }

        public void ChangeCredentials(Email email, string password, string confirmPassword)
        {
            User.Update(email, password, confirmPassword);
            AddNotifications(User);
        }

        public void AddAccount(BankAccount account)
        {
            AddNotifications(account);
            if (Invalid) return;

            this.Accounts.Add(account);
        }

        public BankAccount GetAccount(Guid id)
        {
            return Accounts.FirstOrDefault(n => n.Id == id);
        }

        public void RemoveAccount(BankAccount account)
        {
            this.Accounts.Remove(account);
        }
    }
}
