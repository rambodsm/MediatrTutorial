namespace MediatrTutorial.Features.Customers.Commands.DeleteCustomer;

public sealed record DeleteCustomerCommand : IRequest
{
    public string Id { get; init; }
}

public sealed class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
{
    private readonly MediatrTutorialDbContext _context;

    public DeleteCustomerCommandHandler(MediatrTutorialDbContext context) => _context = context;

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers
            .Where(customer => customer.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        _context.Customers.Remove(customer!);

        await _context.SaveChangesAsync(cancellationToken);

        return new();
    }
}