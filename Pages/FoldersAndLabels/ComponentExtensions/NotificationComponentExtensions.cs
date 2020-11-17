using Pages.FoldersAndLabels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pages.FoldersAndLabels.ComponentExtensions
{
    public static class NotificationComponentExtensions
    {
        public static string GetNotificationText(this NotificationComponent notificationComponent)
        {
            Thread.Sleep(1000);

            return notificationComponent.Notification.Text;
        }
    }
}
