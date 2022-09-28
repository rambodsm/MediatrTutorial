namespace MediatrTutorial.Features.Customers.Commands.CreateCustomer;

public sealed record CreateCustomerCommand : IRequest
{
    public string FullName { get; init; }

    public string MobileNumber { get; init; }

    public string EmailAddress { get; init; }
}

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
{
    private readonly MediatrTutorialDbContext _context;
    private readonly IMediator _mediator;

    public CreateCustomerCommandHandler(MediatrTutorialDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = request.Adapt<Customer>();

        await _context.Customers.AddAsync(customer, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new CreatedCustomerEvent(customer), cancellationToken);

        return new();
    }
}