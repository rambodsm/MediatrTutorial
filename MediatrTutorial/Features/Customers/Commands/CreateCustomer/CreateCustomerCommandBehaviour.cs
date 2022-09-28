using MediatR.Pipeline;

namespace MediatrTutorial.Features.Customers.Commands.CreateCustomer;

public sealed class CreateCustomerCommandBehaviour : IRequestPreProcessor<CreateCustomerCommand>
{
    private readonly MediatrTutorialDbContext _context;

    public CreateCustomerCommandBehaviour(MediatrTutorialDbContext context) => _context = context;

    public Task Process(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        //this function will be execute before 'CreateCustomerCommandHandler'
        //you can do any validation or ...
        
        return Task.FromResult(true);
    }
}