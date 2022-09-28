namespace MediatrTutorial.Features.Customers.Queries.GetCustomerById;

public sealed record GetCustomerByIdQuery : IRequest<GetCustomerByIdResponse>
{
    public string Id { get; init; }
}

public sealed class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdResponse>
{
    private readonly MediatrTutorialDbContext _context;

    public GetCustomerByIdQueryHandler(MediatrTutorialDbContext context) => _context = context;

    public async Task<GetCustomerByIdResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _context.Customers
            .Where(customer => customer.Id == request.Id)
            .ProjectToType<GetCustomerByIdResponse>()
            .SingleOrDefaultAsync(cancellationToken);

        return response!;
    }
}