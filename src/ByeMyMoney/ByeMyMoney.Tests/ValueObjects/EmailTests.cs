using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ByeMyMoney.Domain.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void GivenAInvalidEmailShouldReturnNotification()
        {
            var wrong = new Email("carlos@teste");
            Assert.IsFalse(wrong.Valid);
        }

        [TestMethod]
        public void GivenAValidEmailShouldReturnOk()
        {
            var fine = new Email("carlosbrito@livrariagalileu.com.br");
            Assert.IsTrue(fine.Valid);
        }
    }
}
