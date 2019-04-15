using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Helpers;
using ByeMyMoney.Shared.Models;
using Flunt.Validations;
using System;

namespace ByeMyMoney.Domain.Entities
{
    public class User: Entity
    {
        public User(Guid id, Email email, string password, string confirmPassword)
            :base(id)
        {
            Update(email, password, confirmPassword);

            //Email = email;
            //Password = EncryptPassword(password);

            //AddNotifications(Email);

            //if (Valid)
            //    AddNotifications(new Contract()
            //        .IsTrue(Password == EncryptPassword(confirmPassword), "password", "As senhas não coincidem")
            //    );
        }

        public Email Email { get; private set; }
        public string Password { get; private set; }

        public void Update(Email email, string password, string confirmPassword)
        {
            Email = email;
            Password = EncryptPassword(password);

            AddNotifications(email);

            if (Valid)
                AddNotifications(new Contract()
                    .IsTrue(Password == EncryptPassword(confirmPassword), "password", "As senhas não coincidem")
                );
        }

        public bool Authenticate(Email email, string password)
        {
            AddNotifications(email);
            if (Invalid) return false;

            if (Email.Address == email.Address && Password == EncryptPassword(password))
                return true;

            AddNotification("User", "Usuário ou senha inválidos");
            return false;
        }

        private string EncryptPassword(string pass)
        {
            return EncryptHelper.Cypher(pass, "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
        }
    }
}
