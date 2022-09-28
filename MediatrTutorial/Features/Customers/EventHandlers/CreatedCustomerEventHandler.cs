namespace MediatrTutorial.Features.Customers.EventHandlers;

public sealed class CreatedCustomerEventHandler : INotificationHandler<CreatedCustomerEvent>
{
    public Task Handle(CreatedCustomerEvent notification, CancellationToken cancellationToken)
    {
        //you can do any thing ie log or ...
        return Task.CompletedTask;
    }
}