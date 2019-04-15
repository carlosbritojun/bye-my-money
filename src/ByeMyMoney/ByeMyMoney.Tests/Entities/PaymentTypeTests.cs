using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ByeMyMoney.Domain.Tests.Entities
{
    [TestClass]
    public class PaymentTypeTests
    {
        [TestMethod]
        public void GivenAInvalidPaymentTypeShouldReturnNotification()
        {
            var empty = new PaymentType(Guid.NewGuid(), new Description(string.Empty));
            var minLen = new PaymentType(Guid.NewGuid(), new Description("1"));
            var maxLen = new PaymentType(Guid.NewGuid(), new Description("12345678910123456789101234567891012345678910123456789101234567891012345678910"));

            Assert.IsFalse(empty.Valid);
            Assert.IsFalse(minLen.Valid);
            Assert.IsFalse(maxLen.Valid);
        }

        [TestMethod]
        public void GivenAValidPaymentTypeShouldReturnOk()
        {
            var fine = new PaymentType(Guid.NewGuid(), new Description("Cheque"));
            Assert.IsTrue(fine.Valid);
        }
    }
}
