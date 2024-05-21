namespace CarRental.MVC.Models
{
    public class Notification
    {
        public Notification(string type, string message)
        {
            Type = type;
            Message = message;
        }

        public string Type { get; }
        public string Message { get; }
    }
}
