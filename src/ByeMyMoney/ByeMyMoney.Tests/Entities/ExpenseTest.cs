﻿using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ByeMyMoney.Domain.Tests.Entities
{
    [TestClass]
    public class ExpenseTest
    {
        private Accountant _owner;
        private Guid _account;
        

        [TestInitialize]
        public void Init()
        {
            _owner = new Accountant(Guid.NewGuid(), new Name("Carlos Alberto de Brito"), new User(Guid.NewGuid(), new Email("carlosbrito@gmail.com"), "123", "123"));
            _account = Guid.NewGuid();
            var account = new BankAccount(
                    _account,
                    new Name("Itaú"),
                    "14411-6"
                );
            _owner.AddAccount(account);

        }

        [TestMethod]
        public void GivenAInvalidExpenseShouldReturnNotification()
        {
            var empty = new Expense(
                Guid.NewGuid(),
                _owner.GetAccount(_account),
                new Description(string.Empty), 
                new Favored(Guid.NewGuid(), new Name(string.Empty), new FavoredType(Guid.NewGuid(), new Description(string.Empty))), 
                new Money(decimal.Zero));

            var minLen = new Expense(
                Guid.NewGuid(),
                _owner.GetAccount(_account),
                new Description("1"),
                new Favored(Guid.NewGuid(), new Name("1"), new FavoredType(Guid.NewGuid(), new Description("1"))),
                new Money(decimal.Zero));

            var maxLen = new Expense(
                Guid.NewGuid(),
               _owner.GetAccount(_account),
                new Description("12345678910123456789101234567891012345678910123456789101234567891012345678910"),
                new Favored(Guid.NewGuid(), new Name("Nome qualquer"), new FavoredType(Guid.NewGuid(), new Description("Descricao qualquer"))),
                new Money(10M));

            Assert.IsFalse(empty.Valid);
            Assert.IsFalse(minLen.Valid);
            Assert.IsFalse(maxLen.Valid);
        }

        [TestMethod]
        public void GivenAValidExpenseShouldReturnOk()
        {
            var fine = new Expense(
               Guid.NewGuid(),
               _owner.GetAccount(_account),
               new Description("Despesar com empregada"),
               new Favored(Guid.NewGuid(), new Name("Filha"), new FavoredType(Guid.NewGuid(), new Description("Família"))),
               new Money(1200M));

            Assert.IsTrue(fine.Valid);
        }
    }
}
