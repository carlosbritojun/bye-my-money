using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByeMyMoney.Domain.Tests.Entities
{
    [TestClass]
    public class ExpenseTest
    {
        public Accountant Owner
        {
            get { return new Accountant(new Name("Carlos Alberto de Brito"), new User(new Email("carlosbrito@gmail.com"), "123", "123")); }
        }
        [TestMethod]
        public void GivenAInvalidExpenseShouldReturnNotification()
        {
            var empty = new Expense(
                Owner,
                new Description(string.Empty), 
                new Favored(new Name(string.Empty), new FavoredType(new Description(string.Empty))), 
                new Money(decimal.Zero));

            var minLen = new Expense(
                Owner,
                new Description("1"),
                new Favored(new Name("1"), new FavoredType(new Description("1"))),
                new Money(decimal.Zero));

            var maxLen = new Expense(
                Owner,
                new Description("12345678910123456789101234567891012345678910123456789101234567891012345678910"),
                new Favored(new Name("Nome qualquer"), new FavoredType(new Description("Descricao qualquer"))),
                new Money(10M));

            Assert.IsFalse(empty.Valid);
            Assert.IsFalse(minLen.Valid);
            Assert.IsFalse(maxLen.Valid);
        }

        [TestMethod]
        public void GivenAValidExpenseShouldReturnOk()
        {
            var fine = new Expense(
                Owner,
               new Description("Despesar com empregada"),
               new Favored(new Name("Filha"), new FavoredType(new Description("Família"))),
               new Money(1200M));

            Assert.IsTrue(fine.Valid);
        }
    }
}
