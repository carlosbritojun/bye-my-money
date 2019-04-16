using ByeMyMoney.Domain.Commands.FavoredTypeCommands.Inputs;
using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.Repository;
using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Commands;
using ByeMyMoney.Shared.Transactions;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ByeMyMoney.Domain.Commands.FavoredTypeCommands.Handlers
{
    public class FavoredTypeCommandHandler : Notifiable,
        ICommandHandler<RegisterNewFavoredTypeCommand>,
        ICommandHandler<UpdateFavoredTypeCommand>,
        ICommandHandler<RemoveFavoredTypeCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IFavoredTypeRepository _repository;

        public FavoredTypeCommandHandler(IUnitOfWork uow, IFavoredTypeRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public Task<bool> Handle(RegisterNewFavoredTypeCommand command)
        {
            var entity = new FavoredType(
                    Guid.NewGuid(),
                    new Description(command.Description)
                );
            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _repository.Create(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateFavoredTypeCommand command)
        {
            var entity = _repository.Get(command.Id);
            if (entity == null)
            {
                AddNotification("tipo-favorecido", "Tipo de favorecido não localizado");
                return Task.FromResult(false);
            }

            entity.Update(new Description(command.Description));
            AddNotifications(entity);

            if (Invalid) return Task.FromResult(false);

            _repository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveFavoredTypeCommand command)
        {
            var entity = _repository.Get(command.Id);
            if (entity == null)
            {
                AddNotification("tipo-favorecido", "Tipo de favorecido não localizado");
                return Task.FromResult(false);
            }

            _repository.Delete(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }
    }
}
