using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ByeMyMoney.Domain.Tests.Entities
{
    [TestClass]
    public class FavoredTests
    {
        [TestMethod]
        public void GivenAInvalidFavoredShouldReturnNotification()
        {
            var empty = new Favored(Guid.NewGuid(), new Name(string.Empty), null);
            var minLen = new Favored(Guid.NewGuid(), new Name("1"), new FavoredType(Guid.NewGuid(), new Description("Descrição de Teste")));
            var maxLen = new Favored(Guid.NewGuid(), new Name("12345678910123456789101234567891012345678910123456789101234567891012345678910"), new FavoredType(Guid.NewGuid(), new Description("Descrição de Teste")));

            Assert.IsFalse(empty.Valid);
            Assert.IsFalse(minLen.Valid);
            Assert.IsFalse(maxLen.Valid);
        }

        [TestMethod]
        public void GivenAValidFavoredShouldReturnOk()
        {
            var fine = new Favored(Guid.NewGuid(), new Name("Carlos Alberto"), new FavoredType(Guid.NewGuid(), new Description("Descricao de teste")));
            Assert.IsTrue(fine.Valid);
        }
    }
}
