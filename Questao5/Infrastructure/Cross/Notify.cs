using Questao5.Domain.Enumerators;

namespace Questao5.Infrastructure.Cross
{
    public class Notify
    {
        public Priority PriorityEnum { get; set; }
        public Notification TypeNotify { get; set; }
        public string Message { get; set; }
        public List<string> PropertsErrors { get; set; }

        public Notify()
        {
            PriorityEnum = Priority.Average;
            TypeNotify = Notification.Error;
            PropertsErrors = new List<string>();
        }
    }
}
