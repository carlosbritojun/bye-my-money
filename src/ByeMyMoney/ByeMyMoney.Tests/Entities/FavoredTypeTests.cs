using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByeMyMoney.Domain.Tests.Entities
{
    [TestClass]
    public class FavoredTypeTests
    {
        [TestMethod]
        public void GivenAInvalidFavoredTypeShouldReturnNotification()
        {
            var empty = new FavoredType(new Description(string.Empty));
            var minLen = new FavoredType(new Description("1"));
            var maxLen = new FavoredType(new Description("12345678910123456789101234567891012345678910123456789101234567891012345678910"));

            Assert.IsFalse(empty.Valid);
            Assert.IsFalse(minLen.Valid);
            Assert.IsFalse(maxLen.Valid);
        }

        [TestMethod]
        public void GivenAValidFavoredTypeShouldReturnOk()
        {
            var fine = new FavoredType(new Description("Família"));
            Assert.IsTrue(fine.Valid);
        }
    }
}
