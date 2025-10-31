using FluentValidation;
using PhoneBook.Application.Commands.UpdateContact;
using PhoneBook.Application.DTOs;
using PhoneBook.Application.Validators;

namespace PhoneBook.Application.Validators
{
    public class UpdateContactValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID é obrigatório");

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

            // Corrigindo o validador para usar o tipo correto
            RuleForEach(x => x.Addresses).SetValidator(new AddressValidatorForUpdate());
        }
    }
    
    public class AddressValidatorForUpdate : AbstractValidator<AddressDto>
    {
        public AddressValidatorForUpdate()
        {
            RuleFor(x => x.Street).NotEmpty().WithMessage("Rua é obrigatória");
            RuleFor(x => x.City).NotEmpty().WithMessage("Cidade é obrigatória");
            RuleFor(x => x.State).NotEmpty().WithMessage("Estado é obrigatório");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("CEP é obrigatório");
            RuleFor(x => x.Country).NotEmpty().WithMessage("País é obrigatório");
        }
    }
}