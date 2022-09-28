namespace MediatrTutorial.Features.Customers.Commands.DeleteCustomer;

public sealed class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(customer => customer.Id).NotNull().WithMessage("Id can't be null");

        RuleFor(customer => customer.Id).NotEmpty().WithMessage("Id can't be empty");
    }
}