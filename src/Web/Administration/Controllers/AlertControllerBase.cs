using Administration.Models;
using Microsoft.AspNetCore.Mvc;

namespace Administration.Controllers
{
    public class AlertControllerBase : Controller
    {
        public void Success(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Warning, message, dismissable);
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(AlertStyles.Danger, message, dismissable);
        }

        public void GenerateAlert(Alert alert)
        {
            GenerateMessage(alert.Message, alert.AlertStyle);
        }

        public void GenerateMessage(string message, string alertStyle)
        {
            switch (alertStyle)
            {
                case AlertStyles.Danger:
                    Danger(message, true);
                    break;
                case AlertStyles.Success:
                    Success(message, true);
                    break;
                case AlertStyles.Warning:
                    Warning(message, true);
                    break;
                case AlertStyles.Information:
                    Information(message, true);
                    break;
            }
        }

        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = new List<Alert>();
            if (TempData != null)
                alerts = TempData.ContainsKey(Alert.TempDataKey)
                    ? (List<Alert>)TempData[Alert.TempDataKey]
                    : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            if (TempData != null)
                TempData[Alert.TempDataKey] = alerts;
        }

        public Alert GetAlert(string alertStyle, string message, bool dismissable = false)
        {
            var alert = new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            };

            return alert;
        }

    }
}
