using Flunt.Notifications;
using System;

namespace ByeMyMoney.Shared.Models
{
    public abstract class Entity: Notifiable
    {
        protected Entity(Guid id)
        {
            Id = id;
        }

        //public Entity() => Id = Guid.NewGuid();

        public Guid Id { get; protected set; }
        public static bool operator !=(Entity a, Entity b) => !(a == b);
        public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator == (Entity a, Entity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

            return a.Equals(b);
        }
    }
}
