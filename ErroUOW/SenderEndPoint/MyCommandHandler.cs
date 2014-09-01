﻿namespace ErrorUOW.SenderEndPoint
{
    using System;
    using Messages.Commands;
    using NServiceBus;

    public class MyCommandHandler : IHandleMessages<MyCommand>
    {
        public DateTime? MyDateTime { get; set; }

        public void Handle(MyCommand message)
        {
            Console.WriteLine("Handeling a MyCommand of message type: {1} with Id {0}.", message.IdGuid,
                message.GetType());

            Console.WriteLine("==========================================================================");

            if (message.Throw)
            {
                try
                {
                    // this should throw with stack trace
                    DateTime date = MyDateTime.Value.Date;
                }
                catch (Exception e)
                {
                    throw new Exception("Ho nos, MyCommand, we have an issue..." + DateTime.UtcNow, e);
                }
            }
        }
    }
}