using ByeMyMoney.Domain.Commands.ExpenseCommands.Inputs;
using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.Repository;
using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Commands;
using ByeMyMoney.Shared.Transactions;
using Flunt.Notifications;
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
        private readonly IExpenseRepository _expenseRepository;
        private readonly IAccountantRepository _accountantRepository;
        private readonly IFavoredRepository _favoredRepository;
        private readonly IPaymentTypeRepository _paymentTypeRepository;

        public ExpenseCommandHandler(IUnitOfWork uow,  IExpenseRepository expenseRepository, IAccountantRepository accountantRepository, IFavoredRepository favoredRepository, IPaymentTypeRepository paymentRepository)
        {
            _uow = uow;
            _expenseRepository = expenseRepository;
            _accountantRepository = accountantRepository;
            _favoredRepository = favoredRepository;
            _paymentTypeRepository = paymentRepository;
        }

        public Task<bool> Handle(RegisterNewExpenseCommand command)
        {
            var entity = new Expense(
                    _accountantRepository.Get(command.Owner),
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
            _expenseRepository.Delete(command.Id);
            _uow.Commit();
            return Task.FromResult(true);
        }

        public Task<bool> Handle(PaymentExpenseCommand command)
        {
            var entity = _expenseRepository.Get(command.Id);

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

            entity.CancelPayment();

            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _expenseRepository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }
    }
}
