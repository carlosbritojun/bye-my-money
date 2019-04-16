using ByeMyMoney.Domain.Commands.AccountantCommands.Handlers;
using ByeMyMoney.Domain.Commands.AccountantCommands.Inputs;
using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.Repository;
using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;

namespace ByeMyMoney.Domain.Tests.CommandHandlers
{
    [TestClass]
    public class AccountantCommandHandlerTests
    {
        private Guid _id;
        private Guid _idUser;
        private Guid _idBankAccount;
        private string _email;
        private AccountantCommandHandler _handler;
        private Mock<IAccountantRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUoW;

        [TestInitialize]
        public void Init()
        {
            _id = Guid.NewGuid();
            _idUser = Guid.NewGuid();
            _idBankAccount = Guid.NewGuid();

            _email = "carlosbrito@livrariagalileu.com.br";

            var entity = new Accountant(_id, new Name("Carlos Alberto"), new User(_idUser, new Email(_email), "1234", "1234"));
            entity.AddAccount(new BankAccount(_idBankAccount, new Name("Itaú"), "144116"));

            _mockRepository = new Mock<IAccountantRepository>();
            _mockRepository.Setup(n => n.Get(_id)).Returns(entity);
            _mockUoW = new Mock<IUnitOfWork>();
            _mockUoW.Setup(n => n.Commit()).Returns(true);

            _handler = new AccountantCommandHandler(_mockUoW.Object, _mockRepository.Object);
        }

        #region Fail Tests
        [TestMethod]
        public void RegisterNewAccountantCommandFail()
        {
            var cmdEmail = new RegisterNewAccountantCommand("Carlos Alberto", "carlosbrito", "1234", "1234");
            _handler.Handle(cmdEmail);
            Assert.IsFalse(_handler.Valid, _handler.Notifications.FirstOrDefault().Message);
        }

        [TestMethod]
        public void UpdateAccountantCommandFail()
        {
            var cmd = new UpdateAccountantCommand(_id, string.Empty);
            _handler.Handle(cmd);
            Assert.IsFalse(_handler.Valid, _handler.Notifications.FirstOrDefault().Message);
        }

        [TestMethod]
        public void RemoveAccountantCommandFail()
        {
            var invalidId = Guid.NewGuid();
            var cmd = new RemoveAccountantCommand(invalidId);
            _handler.Handle(cmd);
            Assert.IsFalse(_handler.Valid, _handler.Notifications.FirstOrDefault().Message);
        }

        [TestMethod]
        public void AddBankAccountCommandFail()
        {
            var cmd = new AddBankAccountCommand(_id, string.Empty, string.Empty);
            _handler.Handle(cmd);
            Assert.IsFalse(_handler.Valid, _handler.Notifications.FirstOrDefault().Message);
        }

        [TestMethod]
        public void UpdateBankAccountCommandFail()
        {
            var cmd = new UpdateBankAccountCommand(_id, Guid.NewGuid(), string.Empty, string.Empty);
            _handler.Handle(cmd);
            Assert.IsFalse(_handler.Valid, _handler.Notifications.FirstOrDefault().Message);
        }

        [TestMethod]
        public void RemoveBankAccountCommandFail()
        {
            var cmd = new RemoveBankAccountCommand(_id, Guid.NewGuid());
            _handler.Handle(cmd);
            Assert.IsFalse(_handler.Valid, _handler.Notifications.FirstOrDefault().Message);
        }
        #endregion

        #region Tests Ok
        [TestMethod]
        public void RegisterNewAccountantCommandOk()
        {
            var cmd = new RegisterNewAccountantCommand("Carlos Alberto", _email, "1234", "1234");
            _handler.Handle(cmd);
            Assert.IsTrue(_handler.Valid);
        }

        [TestMethod]
        public void UpdateAccountantCommandOk()
        {
            var cmd = new UpdateAccountantCommand(_id, "Carlos Alberto de Brito Júnior");
            _handler.Handle(cmd);
            Assert.IsTrue(_handler.Valid);
        }

        [TestMethod]
        public void RemoveAccountantCommandOk()
        {
            var cmd = new RemoveAccountantCommand(_id);
            _handler.Handle(cmd);
            Assert.IsTrue(_handler.Valid);
        }

        [TestMethod]
        public void AddBankAccountCommandOk()
        {
            var cmd = new AddBankAccountCommand(_id, "Itaú", "144116");
            _handler.Handle(cmd);
            Assert.IsTrue(_handler.Valid);
        }

        [TestMethod]
        public void UpdateBankAccountCommandOk()
        {
            var cmd = new UpdateBankAccountCommand(_id, _idBankAccount, "Santander", "123456");
            _handler.Handle(cmd);
            Assert.IsTrue(_handler.Valid);
        }
        #endregion
    }
}
