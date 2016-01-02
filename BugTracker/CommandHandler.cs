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
        IHandle<AssignResourceCommand>,
        IHandle<NotifyDevelopersAboutMissingEstimateCommand>,
        IHandle<NotifyManagementAboutMissingDeveloperCommand>,
        IHandle<NotifyManagementAboutChangedEstimateCommand>
    {
        private readonly IMailService mail;
        private readonly ISessionFactory ruleFactory;
        private readonly MailAddress fromEmail = new MailAddress("contact@company");

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

        public void Handle(AssignResourceCommand cmd)
        {
            cmd.Bug.Resources.Add(cmd.Resource);
            cmd.Bug.Events.Add(new AssignedResourceEvent(cmd.Bug, cmd.Resource, cmd.AssignedBy, DateTime.Now));

            // TODO: store in repo.

            var session = ruleFactory.CreateSession();
            session.Insert(cmd.Bug);
            session.Fire();
        }

        public void Handle(NotifyDevelopersAboutMissingEstimateCommand cmd)
        {
            foreach (var resource in cmd.Bug.Resources.Where(x => x.Type == ResourceType.Developer).ToList())
            {
                Send(resource.User.Email, "missing_estimate",
                    message => cmd.Bug.Events.Add(new NotifiedDevelopersAboutMissingEstimateEvent(cmd.Bug, DateTime.Now)),
                    ex => cmd.Bug.Events.Add(new FailedToNotifyResourceEvent(resource, cmd, ex, DateTime.Now)));
            }
        }

        public void Handle(NotifyManagementAboutChangedEstimateCommand cmd)
        {
            foreach (var resource in cmd.Bug.Resources.Where(x => x.Type == ResourceType.Manager).ToList())
            {
                Send(resource.User.Email, "changed_estimate",
                    message => cmd.Bug.Events.Add(new NotifiedManagerAboutChangedEstimateEvent(cmd.Bug, DateTime.Now)),
                    ex => cmd.Bug.Events.Add(new FailedToNotifyResourceEvent(resource, cmd, ex, DateTime.Now)));
            }
        }

        public void Handle(NotifyManagementAboutMissingDeveloperCommand cmd)
        {
            foreach (var resource in cmd.Bug.Resources.Where(x => x.Type == ResourceType.Manager).ToList())
            {
                Send(resource.User.Email, "missing_developer",
                    message => cmd.Bug.Events.Add(new NotifiedManagerAboutMissingDeveloperEvent(cmd.Bug, DateTime.Now)),
                    ex => cmd.Bug.Events.Add(new FailedToNotifyResourceEvent(resource, cmd, ex, DateTime.Now)));
            }
        }

        private void Send(string email, string template, Action<MailMessage> success, Action<Exception> failure)
        {
            try
            {
                var message = new MailMessage();
                message.To.Add(new MailAddress(email));
                message.From = fromEmail;
                message.Subject = "";// TDOD based on template
                message.Body = "";// TDOD based on template
                mail.Send(message);
                success(message);
            }
            catch (Exception ex)
            {
                failure(ex);
            }
        }
    }
}
