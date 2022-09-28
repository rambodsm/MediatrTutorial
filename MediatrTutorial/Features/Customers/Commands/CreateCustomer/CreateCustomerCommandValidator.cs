namespace MediatrTutorial.Features.Customers.Commands.CreateCustomer;

public sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(customer => customer.EmailAddress).NotNull().WithMessage("Email address can't be null");
        
        RuleFor(customer => customer.EmailAddress).NotEmpty().WithMessage("Email address can't be empty");
        
        RuleFor(customer => customer.EmailAddress).Length(5,500).WithMessage("Email address can't be smaller than 5 or greater than 500");
        
        RuleFor(customer => customer.EmailAddress).EmailAddress().WithMessage("Email address isn't correct");
        
        RuleFor(customer => customer.FullName).NotNull().WithMessage("FullName can't be null");
        
        RuleFor(customer => customer.FullName).NotEmpty().WithMessage("FullName can't be empty");
        
        RuleFor(customer => customer.FullName).Length(3,500).WithMessage("FullName can't be smaller than 5 or greater than 500");
        
        RuleFor(customer => customer.MobileNumber).NotNull().WithMessage("MobileNumber can't be null");
        
        RuleFor(customer => customer.MobileNumber).NotEmpty().WithMessage("MobileNumber can't be empty");
        
        RuleFor(customer => customer.MobileNumber).Length(3,12).WithMessage("MobileNumber can't be smaller than 3 or greater than 12");
    }
}