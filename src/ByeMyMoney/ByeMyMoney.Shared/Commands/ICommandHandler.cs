using System.Threading.Tasks;

namespace ByeMyMoney.Shared.Commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
        Task<bool> Handle(T command);
    }
}
