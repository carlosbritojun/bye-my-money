using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Models;
using System.Collections.Generic;

namespace ByeMyMoney.Domain.Entities
{
    public class Accountant: Entity
    {
        public Accountant(Name name, User user)
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
            var newUser = new User(email, password, confirmPassword);

            AddNotifications(newUser);
            if (Invalid) return;

            User = newUser;
        }

        public void AddAccount(BankAccount account)
        {
            AddNotifications(account);
            if (Invalid) return;

            this.Accounts.Add(account);
        }

        public void RemoveAccount(BankAccount account)
        {
            this.Accounts.Remove(account);
        }
    }
}
