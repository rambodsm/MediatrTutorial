namespace MediatrTutorial.Domain;

public sealed class Customer
{
    public Customer()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }

    public string FullName { get; set; }

    public string MobileNumber { get; set; }

    public string EmailAddress { get; set; }
}