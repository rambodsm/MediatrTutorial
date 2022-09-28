namespace MediatrTutorial.Features.Customers.Commands.DeleteCustomer;

public sealed class DeleteCustomerCommandBehaviour : IRequestPreProcessor<DeleteCustomerCommand>
{
    private readonly MediatrTutorialDbContext _context;

    public DeleteCustomerCommandBehaviour(MediatrTutorialDbContext context) => _context = context;

    public async Task Process(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var isExist = await _context.Customers
            .Where(customer => customer.Id == request.Id)
            .AnyAsync(cancellationToken);

        if (isExist is false)
            throw new CustomerNotFoundException();
    }
}