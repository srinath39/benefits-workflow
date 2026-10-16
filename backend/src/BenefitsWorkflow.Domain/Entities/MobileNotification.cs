

namespace BenefitsWorkflow.Domain.Entities;

public class MobileNotification : INotification
{
    public void NotificationDevice()
    {
        Console.WriteLine("I am mobile device");
    }
}