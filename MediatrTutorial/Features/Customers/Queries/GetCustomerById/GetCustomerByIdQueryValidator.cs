namespace MediatrTutorial.Features.Customers.Queries.GetCustomerById;

public sealed class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(customer => customer.Id).NotNull().WithMessage("Id can't be null");

        RuleFor(customer => customer.Id).NotEmpty().WithMessage("Id can't be empty");
    }
}