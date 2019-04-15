using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByeMyMoney.Domain.Tests.Entities
{
    [TestClass]
    public class FavoredTests
    {
        [TestMethod]
        public void GivenAInvalidFavoredShouldReturnNotification()
        {
            var empty = new Favored(new Name(string.Empty), null);
            var minLen = new Favored(new Name("1"), new FavoredType(new Description("Descrição de Teste")));
            var maxLen = new Favored(new Name("12345678910123456789101234567891012345678910123456789101234567891012345678910"), new FavoredType(new Description("Descrição de Teste")));

            Assert.IsFalse(empty.Valid);
            Assert.IsFalse(minLen.Valid);
            Assert.IsFalse(maxLen.Valid);
        }

        [TestMethod]
        public void GivenAValidFavoredShouldReturnOk()
        {
            var fine = new Favored(new Name("Carlos Alberto"), new FavoredType(new Description("Descricao de teste")));
            Assert.IsTrue(fine.Valid);
        }
    }
}
