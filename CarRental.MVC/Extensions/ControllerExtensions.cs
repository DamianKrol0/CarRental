using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CarRental.MVC.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CarRental.MVC.Extensions
{
    public static class ControllerExtensions
    {
        public static void SetNotification(this Controller controller,string type,string message)

        {
            var notification = new Notification(type, message);
            controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);

        }
    }
}
