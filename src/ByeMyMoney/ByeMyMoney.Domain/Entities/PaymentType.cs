﻿using ByeMyMoney.Domain.ValueObjects;
using ByeMyMoney.Shared.Models;
using System;

namespace ByeMyMoney.Domain.Entities
{
    public class PaymentType: Entity
    {
        public PaymentType(Guid id, Description description)
            :base(id)
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
