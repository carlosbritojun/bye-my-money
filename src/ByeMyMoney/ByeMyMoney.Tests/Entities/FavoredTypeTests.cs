using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ByeMyMoney.Domain.Tests.Entities
{
    [TestClass]
    public class FavoredTypeTests
    {
        [TestMethod]
        public void GivenAInvalidFavoredTypeShouldReturnNotification()
        {
            var empty = new FavoredType(Guid.NewGuid(), new Description(string.Empty));
            var minLen = new FavoredType(Guid.NewGuid(), new Description("1"));
            var maxLen = new FavoredType(Guid.NewGuid(), new Description("12345678910123456789101234567891012345678910123456789101234567891012345678910"));

            Assert.IsFalse(empty.Valid);
            Assert.IsFalse(minLen.Valid);
            Assert.IsFalse(maxLen.Valid);
        }

        [TestMethod]
        public void GivenAValidFavoredTypeShouldReturnOk()
        {
            var fine = new FavoredType(Guid.NewGuid(), new Description("Família"));
            Assert.IsTrue(fine.Valid);
        }
    }
}
