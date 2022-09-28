namespace MediatrTutorial.Features.Customers.Queries.GetCustomersWithPagination;

public sealed record GetCustomersWithPaginationResponse
{
    public string Id { get; init; }

    public string FullName { get; init; }

    public string MobileNumber { get; init; }

    public string EmailAddress { get; init; }
}