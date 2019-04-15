using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ByeMyMoney.Domain.Tests.Entities
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void GivenAInvalidUserEmailShouldReturnNotification()
        {
            var invalidEmail = new User(Guid.NewGuid(), new Email("carlos@tess"), "1234", "1234");
            Assert.IsFalse(invalidEmail.Valid);
        }

        [TestMethod]
        public void GivenAInvalidUserPasswordConfirmationShouldReturnNotification()
        {
            var invalidPwdConfirm = new User(Guid.NewGuid(), new Email("carlos@gmail.com"), "1234", "123");
            Assert.IsFalse(invalidPwdConfirm.Valid);
        }

        [TestMethod]
        public void GivenAInvalidAuthenticationShouldReturnoNotification()
        {
            var user = new User(Guid.NewGuid(), new Email("carlos@gmail.com"), "1234", "1234");
            user.Authenticate(new Email("carlos@gmail.com"), "123");
            Assert.IsFalse(user.Valid);
        }

        [TestMethod]
        public void GivenAValidUserShouldReturnOk()
        {
            var user = new User(Guid.NewGuid(), new Email("carlos@gmail.com"), "1234", "1234");
            Assert.IsTrue(user.Valid);
        }

        [TestMethod]
        public void GivenAValidAuthenticationShouldReturnoOk()
        {
            var user = new User(Guid.NewGuid(), new Email("carlos@gmail.com"), "1234", "1234");
            user.Authenticate(new Email("carlos@gmail.com"), "1234");
            Assert.IsTrue(user.Valid);
        }
    }
}
