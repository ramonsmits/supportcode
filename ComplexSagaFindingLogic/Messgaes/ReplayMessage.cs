﻿namespace Client.Messages
{
    using System;

    public class ReplayMessage
    {
        public Guid Id { get; set; }
        public Guid TransactionId { get; set; } 
    }
}