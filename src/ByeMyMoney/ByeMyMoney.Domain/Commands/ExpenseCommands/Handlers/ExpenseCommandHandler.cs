using ByeMyMoney.Domain.Commands.ExpenseCommands.Inputs;
using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.Repository;
using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Commands;
using ByeMyMoney.Shared.Transactions;
using Flunt.Notifications;
using System;
using System.Threading.Tasks;

namespace ByeMyMoney.Domain.Commands.ExpenseCommands.Handlers
{
    public class ExpenseCommandHandler : Notifiable,
        ICommandHandler<RegisterNewExpenseCommand>,
        ICommandHandler<UpdateExpenseCommand>,
        ICommandHandler<RemoveExpenseCommand>,
        ICommandHandler<PaymentExpenseCommand>,
        ICommandHandler<CancelPaymentExpenseCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IAccountantRepository _accountantRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IFavoredRepository _favoredRepository;
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public ExpenseCommandHandler(IUnitOfWork uow, IAccountantRepository accountantRepository, IExpenseRepository expenseRepository, IFavoredRepository favoredRepository, IPaymentTypeRepository paymentRepository)
        {
            _uow = uow;
            _accountantRepository = accountantRepository;
            _expenseRepository = expenseRepository;
            _favoredRepository = favoredRepository;
            _paymentTypeRepository = paymentRepository;
        }

        public Task<bool> Handle(RegisterNewExpenseCommand command)
        {
            var owner = _accountantRepository.Get(command.Owner);
            if (owner == null)
            {
                AddNotification("correntista", "Correntista não localizado");
                return Task.FromResult(false);
            }

            var bankAccount = owner.GetAccount(command.Account);
            if (bankAccount == null)
            {
                AddNotification("conta-corrente", "Conta corrente não localizada");
                return Task.FromResult(false);
            }

            var entity = new Expense(
                    Guid.NewGuid(),
                    bankAccount,
                    new Description(command.Description),
                    _favoredRepository.Get(command.Favored),
                    new Money(command.Value)
                );

            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _expenseRepository.Create(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateExpenseCommand command)
        {
            var entity = _expenseRepository.Get(command.Id);
            if (entity == null)
            {
                AddNotification("despesa", "Despesa não localizada");
                return Task.FromResult(false);
            }

            entity.Update(
                    new Description(command.Description),
                    _favoredRepository.Get(command.Favored),
                    new Money(command.Value)
                );

            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _expenseRepository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveExpenseCommand command)
        {
            var entity = _expenseRepository.Get(command.Id);
            if (entity == null)
            {
                AddNotification("despesa", "Despesa não localizada");
                return Task.FromResult(false);
            }

            _expenseRepository.Delete(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(PaymentExpenseCommand command)
        {
            var entity = _expenseRepository.Get(command.Id);
            if (entity == null)
            {
                AddNotification("despesa", "Despesa não localizada");
                return Task.FromResult(false);
            }

            entity.Pay(
                    _paymentTypeRepository.Get(command.PaymentType),
                    command.Number
                );

            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _expenseRepository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(CancelPaymentExpenseCommand command)
        {
            var entity = _expenseRepository.Get(command.Id);
            if (entity == null)
            {
                AddNotification("despesa", "Despesa não localizada");
                return Task.FromResult(false);
            }

            entity.CancelPayment();

            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _expenseRepository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }
    }
}
