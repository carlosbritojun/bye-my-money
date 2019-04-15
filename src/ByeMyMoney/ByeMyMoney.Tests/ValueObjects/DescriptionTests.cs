using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByeMyMoney.Domain.Tests.ValueObjects
{
    [TestClass]
    public class DescriptionTests
    {
        [TestMethod]
        public void GivenAInvalidDescriptionShouldReturnNotifications()
        {
            var nullOrEmpty = new Description(string.Empty);
            var hasMinLen = new Description("1");
            var hasMaxLen = new Description("12345678910123456789101234567891012345678910123456789101234567891012345678910");

            Assert.IsFalse(nullOrEmpty.Valid);
            Assert.IsFalse(hasMinLen.Valid);
            Assert.IsFalse(hasMaxLen.Valid);
        }

        [TestMethod]
        public void GivenAValidDescriptionShouldReturnOk()
        {
            var isOk = new Description("Descrição de teste");
            Assert.IsTrue(isOk.Valid);
        }
    }
}
