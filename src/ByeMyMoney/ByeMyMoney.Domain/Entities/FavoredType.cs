using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Models;

namespace ByeMyMoney.Domain.Entities
{
    public class FavoredType: Entity
    {
        public FavoredType(Description description)
        {
            Update(description);
        }

        public Description Description { get; private set; }

        public void Update(Description description)
        {
            AddNotifications(description);
            if (Invalid) return;
            Description = description;
        }
    }
}
