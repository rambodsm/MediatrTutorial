namespace MediatrTutorial.Features.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdQueryBehavour : IRequestPreProcessor<GetCustomerByIdQuery>
{
    private readonly MediatrTutorialDbContext _context;

    public GetCustomerByIdQueryBehavour(MediatrTutorialDbContext context) => _context = context;

    public async Task Process(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var isExist = await _context.Customers
            .Where(customer => customer.Id == request.Id)
            .AnyAsync(cancellationToken);

        if (isExist is false)
            throw new CustomerNotFoundException();
    }
}