﻿using System;
using System.Collections.Generic;
using System.Text;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;

namespace Backend.Domain.Entities.Notification
{
    public class Notification
    {
        public Guid Id { get; set; }

        public NotificationType Type { get; set; }
        public string Payload { get; set; }
        public DateTime SentAt { get; set; }

        public bool Read { get; set; }
        public string RedirectUrl { get; set; }

        public Guid SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        public Guid? ReceiverId { get; set; }
        public virtual ApplicationUser Receiver { get; set; }
    }
}
