using FluentValidation;
using PhoneBook.Application.Commands.CreateContact;

namespace PhoneBook.Application.Validators
{
    public class CreateContactValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(100).WithMessage("Nome não pode exceder 100 caracteres");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefone é obrigatório")
                .Matches(@"^\d{10,15}$").WithMessage("Telefone deve conter entre 10 e 15 dígitos");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email é obrigatório")
                .EmailAddress().WithMessage("Email inválido");

            RuleFor(x => x.Addresses)
                .NotEmpty().WithMessage("Pelo menos um endereço é obrigatório");

            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
        }
    }

    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Street).NotEmpty().WithMessage("Rua é obrigatória");
            RuleFor(x => x.City).NotEmpty().WithMessage("Cidade é obrigatória");
            RuleFor(x => x.State).NotEmpty().WithMessage("Estado é obrigatório");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("CEP é obrigatório");
            RuleFor(x => x.Country).NotEmpty().WithMessage("País é obrigatório");
        }
    }
}