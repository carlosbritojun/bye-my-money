using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByeMyMoney.Domain.Tests.Entities
{
    [TestClass]
    public class AccountantTests
    {
        [TestMethod]
        public void GivenAInvalidAccountantShouldReturnNotification()
        {
            var empty = new Accountant(new Name(string.Empty), new User(new Email("carlosbrito@"), "123", "123"));
            var minLen = new Accountant(new Name("1"), new User(new Email("carlosbrito@"), "123", "123"));
            var maxLen = new Accountant(new Name("12345678910123456789101234567891012345678910123456789101234567891012345678910"), new User(new Email("carlosbrito@"), "123", "123"));

            Assert.IsFalse(empty.Valid);
            Assert.IsFalse(minLen.Valid);
            Assert.IsFalse(maxLen.Valid);
        }

        [TestMethod]
        public void GivenAInvalidAddBankAccountShouldReturnNotification()
        {
            var accountant = new Accountant(new Name("Carlos Alberto de Brito"), new User(new Email("carlosbrito@gmail.com"), "123", "123"));
            Assert.IsTrue(accountant.Valid);

            var wrongBankAccount = new BankAccount(new Name("1"), string.Empty);
            accountant.AddAccount(wrongBankAccount);

            Assert.IsFalse(accountant.Valid);
        }

        [TestMethod]
        public void GivenAValidAccountantShouldReturnOk()
        {
            var fine = new Accountant(new Name("Carlos Alberto de Brito"), new User(new Email("carlosbrito@gmail.com"), "123", "123"));
            var fineBankAccount = new BankAccount(new Name("Conta Santander"), "14416");
            fine.AddAccount(fineBankAccount);

            Assert.IsTrue(fine.Valid);
        }
    }
}
