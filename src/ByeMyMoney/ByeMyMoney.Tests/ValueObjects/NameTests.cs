using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByeMyMoney.Domain.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void GivenAInvalidNameShouldReturnNotification()
        {
            var isNull = new Name(string.Empty);
            var hasMinLen = new Name("1");
            var hasMaxLen = new Name("12345678910123456789101234567891012345678910123456789101234567891012345678910");

            Assert.IsFalse(hasMinLen.Valid);
            Assert.IsFalse(isNull.Valid);
            Assert.IsFalse(hasMaxLen.Valid);
        }

        [TestMethod]
        public void GivenAValidNameShouldReturnOk()
        {
            var fine = new Name("Carlos Alberto de Brito Júnior");
            Assert.IsTrue(fine.Valid);
        }
    }
}
