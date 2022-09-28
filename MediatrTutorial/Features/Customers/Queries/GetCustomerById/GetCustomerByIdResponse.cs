namespace MediatrTutorial.Features.Customers.Queries.GetCustomerById;

public sealed record GetCustomerByIdResponse
{
    public string Id { get; init; }

    public string FullName { get; init; }

    public string MobileNumber { get; init; }

    public string EmailAddress { get; init; }
}