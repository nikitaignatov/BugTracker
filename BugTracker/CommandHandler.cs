using System;
using System.Linq;
using System.Net.Mail;
using BugTracker.Commands;
using BugTracker.Events;
using BugTracker.Model;
using NRules;

namespace BugTracker
{
    public class CommandHandler :
        IHandle<CreateBugCommand>,
        IHandle<ChangeEstimateCommand>,
        IHandle<NotifyDeveloperAboutMissingEstimateCommand>,
        IHandle<NotifyManagementAboutMissingDeveloperCommand>,
        IHandle<NotifyManagementAboutChangedEstimateCommand>
    {
        private readonly IMailService mail;
        private readonly ISessionFactory ruleFactory;

        public CommandHandler(IMailService mail, ISessionFactory ruleFactory)
        {
            this.mail = mail;
            this.ruleFactory = ruleFactory;
        }

        public void Handle(CreateBugCommand cmd)
        {
            cmd.Bug.Events.Add(new BugCreatedEvent(cmd.Bug, cmd.CreatedBy, DateTime.Now));

            // TODO: store in repo.

            var session = ruleFactory.CreateSession();
            session.Insert(cmd.Bug);
            session.Fire();
        }

        public void Handle(ChangeEstimateCommand cmd)
        {
            cmd.Bug.Events.Add(new ChangedEstimateEvent(cmd.Bug, cmd.ChangedBy, DateTime.Now));

            // TODO: store in repo.

            var session = ruleFactory.CreateSession();
            session.Insert(cmd.Bug);
            session.Fire();
        }

        public void Handle(NotifyDeveloperAboutMissingEstimateCommand cmd)
        {
            try
            {
                var message = new MailMessage();
                cmd.Bug
                    .Resources
                    .Where(x => x.Type == ResourceType.Developer)
                    .Select(x => new MailAddress(x.User.Email))
                    .ToList()
                    .ForEach(message.To.Add);

                message.From = new MailAddress("contact@company");

                mail.Send(message);

                cmd.Bug.Events.Add(new NotifiedDevelopersAboutMissingEstimateEvent(cmd.Bug, DateTime.Now));
            }
            catch (Exception)
            {
                // TODO:  cmd.Bug.Events.Add(new BugTrackerEvent { Name = "Failed to notify about missing estimate", Created = DateTime.Now });
            }
        }

        public void Handle(NotifyManagementAboutChangedEstimateCommand cmd)
        {
            var message = new MailMessage();
            cmd.Bug
                .Resources
                .Where(x => x.Type == ResourceType.Manager)
                .Select(x => new MailAddress(x.User.Email))
                .ToList()
                .ForEach(message.To.Add);

            message.From = new MailAddress("contact@company");

            mail.Send(message);

            cmd.Bug.Events.Add(new NotifiedManagerAboutChangedEstimateEvent(cmd.Bug, DateTime.Now));
        }

        public void Handle(NotifyManagementAboutMissingDeveloperCommand cmd)
        {
            var message = new MailMessage();
            cmd.Bug
                .Resources
                .Where(x => x.Type == ResourceType.Manager)
                .Select(x => new MailAddress(x.User.Email))
                .ToList()
                .ForEach(message.To.Add);

            message.From = new MailAddress("contact@company");

            mail.Send(message);

            cmd.Bug.Events.Add(new NotifiedManagerAboutMissingDeveloperEvent(cmd.Bug, DateTime.Now));
        }
    }
}
