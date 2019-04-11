using Flunt.Notifications;

namespace ByeMyMoney.Shared.Models
{
    public abstract class ValueObject<T>: Notifiable where T : ValueObject<T>
    {
    }
}
