namespace MediatrTutorial.Common.Events;

public sealed class CreatedCustomerEvent : INotification
{
    public Customer Customer { get; set; }

    public CreatedCustomerEvent(Customer customer)
    {
        Customer = customer;
    }
}