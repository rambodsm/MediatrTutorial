using MediatrTutorial.Common.Mapper;

namespace MediatrTutorial.Features.Customers.Queries.GetCustomersWithPagination;

public sealed record GetCustomersWithPaginationQuery : IRequest<PaginatedList<GetCustomersWithPaginationResponse>>
{
    public int Page { get; init; }

    public int PageSize { get; init; }
}

public sealed class GetCustomersWithPaginationQueryHandler
    : IRequestHandler<GetCustomersWithPaginationQuery, PaginatedList<GetCustomersWithPaginationResponse>>
{
    private readonly MediatrTutorialDbContext _context;

    public GetCustomersWithPaginationQueryHandler(MediatrTutorialDbContext context) => _context = context;

    public async Task<PaginatedList<GetCustomersWithPaginationResponse>> Handle(GetCustomersWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        var response = await _context.Customers
            .ProjectToType<GetCustomersWithPaginationResponse>()
            .PaginatedListAsync(request.Page, request.PageSize);

        return response;
    }
}