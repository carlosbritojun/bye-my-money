using System;
using System.Threading.Tasks;
using ByeMyMoney.Domain.Commands.FavoredCommands.Inputs;
using ByeMyMoney.Domain.Entities;
using ByeMyMoney.Domain.Repository;
using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Commands;
using ByeMyMoney.Shared.Transactions;
using Flunt.Notifications;

namespace ByeMyMoney.Domain.Commands.FavoredCommands.Handlers
{
    public class FavoredCommandHandler : Notifiable,
        ICommandHandler<RegisterNewFavoredCommand>,
        ICommandHandler<UpdateFavoredCommand>,
        ICommandHandler<RemoveFavoredCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IFavoredRepository _favoredRepository;
        private readonly IFavoredTypeRepository _favoredTypeRepository;

        public FavoredCommandHandler(IUnitOfWork uow, IFavoredRepository favoredRepository, IFavoredTypeRepository favoredTypeRepository)
        {
            _uow = uow;
            _favoredRepository = favoredRepository;
            _favoredTypeRepository = favoredTypeRepository;
        }

        public Task<bool> Handle(RegisterNewFavoredCommand command)
        {
            var entity = new Favored(
                    Guid.NewGuid(),
                    new Name(command.Name),
                    _favoredTypeRepository.Get(command.FavoredType)
                );
            AddNotifications(entity);

            if (Invalid) return Task.FromResult(true);

            _favoredRepository.Create(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateFavoredCommand command)
        {
            var entity = _favoredRepository.Get(command.Id);
            if (entity == null)
            {
                AddNotification("favorecido", "Favorecido não localizado");
                return Task.FromResult(false);
            }

            entity.Update(
                    new Name(command.Name),
                    _favoredTypeRepository.Get(command.FavoredType)
                );
            AddNotifications(entity);

            if (Invalid) return Task.FromResult(true);

            _favoredRepository.Update(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }

        public Task<bool> Handle(RemoveFavoredCommand command)
        {
            var entity = _favoredRepository.Get(command.Id);
            if (entity == null)
            {
                AddNotification("favorecido", "Favorecido não localizado");
                return Task.FromResult(false);
            }

            _favoredRepository.Delete(entity);
            _uow.Commit();

            return Task.FromResult(true);
        }
    }
}
