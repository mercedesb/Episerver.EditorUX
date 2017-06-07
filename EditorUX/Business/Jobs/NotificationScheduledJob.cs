using EPiServer.Notification;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace EditorUX.Business.Jobs
{
    [ScheduledPlugIn(DisplayName = "Notification Job")]
    public class NotificationScheduledJob : ScheduledJobBase
    {
        private bool stopSignaled;

        public NotificationScheduledJob()
        {
            this.IsStoppable = true;
        }

        protected Injected<INotifier> Notifier { get; set; }

        /// <summary>
        ///     Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            this.stopSignaled = true;
        }

        /// <summary>
        ///     Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            this.OnStatusChanged(string.Format("Starting execution of {0}", this.GetType()));

            //For long running jobs periodically check if stop is signaled and if so stop execution
            if (this.stopSignaled)
            {
                //this.SendMessage("Stop of job was called");
                return "Stop of job was called";
            }

            this.SendMessage("Notification job completed with no errors.");
            return "Completed";
        }

        private async void SendMessage(string message)
        {
            string[] usersInRole = Roles.GetUsersInRole("Administrators");

            INotificationUser notificationSender = new NotificationUser("admin");

            List<INotificationUser> notificationReceivers = usersInRole.Select(u => Membership.GetUser(u)).Where(u => u != null).Select(u => new NotificationUser(u.UserName)).ToList<INotificationUser>();


            await this.Notifier.Service.PostNotificationAsync(new NotificationMessage
            {
                ChannelName = "Default",
                Content = message,
                Subject = "Scheduled job",
                Recipients = notificationReceivers,
                Sender = notificationSender
            });
        }
    }
}