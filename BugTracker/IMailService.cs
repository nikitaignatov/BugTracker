﻿using System.Net.Mail;

namespace BugTracker
{
    public interface IMailService
    {
        void Send(MailMessage message);
    }
}