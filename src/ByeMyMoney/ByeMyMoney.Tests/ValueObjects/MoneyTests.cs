using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByeMyMoney.Domain.Tests.ValueObjects
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void GivenAInvalidMoneyShouldReturnNotification()
        {
            var moneyZero = new Money(decimal.Zero);
            var moneyNegative = new Money(-10M);

            Assert.IsFalse(moneyZero.Valid);
            Assert.IsFalse(moneyNegative.Valid);
        }

        [TestMethod]
        public void GivenAValidMoneyShouldReturnOk()
        {
            var fine = new Money(10M);
            Assert.IsTrue(fine.Valid);
        }
    }
}
