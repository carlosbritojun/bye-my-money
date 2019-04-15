using System.Linq;
using System.Threading.Tasks;
using ByeMyMoney.Domain.Commands.AccountantCommands.Inputs;
using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.Repository;
using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Commands;
using ByeMyMoney.Shared.Transactions;
using Flunt.Notifications;

namespace ByeMyMoney.Domain.Commands.AccountantCommands.Handlers
{
    public class AccountantCommandHandler : Notifiable,
        ICommandHandler<RegisterNewAccountantCommand>,
        ICommandHandler<UpdateAccountantCommand>,
        ICommandHandler<RemoveAccountantCommand>,
        ICommandHandler<ChangeCredentialsCommand>,
        ICommandHandler<AddBankAccountCommand>,
        ICommandHandler<UpdateBankAccountCommand>,
        ICommandHandler<RemoveBankAccountCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IAccountantRepository _repository;

        public AccountantCommandHandler(IUnitOfWork uow, IAccountantRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public Task<bool> Handle(RegisterNewAccountantCommand command)
        {
           if (_repository.GetByEmail(command.Email) != null)
            {
                AddNotification("E-mail", "E-mail já cadastrado");
                return Task.FromResult(false);
            }

            var entity = new Accountant(
                    new Name(command.Name),
                    new User(new Email(command.Email), command.Password, command.ConfirmPassword)
                );
            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _repository.Create(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateAccountantCommand command)
        {
            var entity = _repository.Get(command.Id);

            entity.Update(new Name(command.Name));
            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _repository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveAccountantCommand command)
        {
            _repository.Delete(command.Id);
            _uow.Commit();
            return Task.FromResult(true);
        }

        public Task<bool> Handle(ChangeCredentialsCommand command)
        {
            var entity = _repository.Get(command.Id);
            var entityEmail = _repository.GetByEmail(command.Email);

            if (entity != entityEmail)
            {
                AddNotification("E-mail", "E-mail já cadastrado para outro corretista");
                return Task.FromResult(false);
            }

            entity.ChangeCredentials(
                    new Email(command.Email),
                    command.Password,
                    command.ConfirmPassord
                );
            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _repository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(AddBankAccountCommand command)
        {
            var entity = _repository.Get(command.Id);

            entity.AddAccount(new BankAccount(
                    new Name(command.BankName),
                    command.Number
                ));
            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _repository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateBankAccountCommand command)
        {
            var entity = _repository.Get(command.Id);
            var bankAccount = entity.Accounts.SingleOrDefault(n => n.Id == command.AccountId);

            if (bankAccount == null)
            {
                AddNotification("bank-account", "Conta não localizada"); ;
                return Task.FromResult(false);
            }

            bankAccount.Update(
                    new Name(command.BankName),
                    command.Number
                );

            AddNotifications(entity, bankAccount);

            if (Invalid) Task.FromResult(false);

            _repository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveBankAccountCommand command)
        {
            var entity = _repository.Get(command.Id);
            var bankAccount = entity.Accounts.SingleOrDefault(n => n.Id == command.AccountId);

            if (bankAccount == null)
            {
                AddNotification("bank-account", "Conta não localizada"); ;
                return Task.FromResult(false);
            }

            entity.RemoveAccount(bankAccount);

            _repository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }
    }
}
