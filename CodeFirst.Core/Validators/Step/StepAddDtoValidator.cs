using CodeFirst.Core.DTOs.Step.Request;
using CodeFirst.Core.Interfaces.Repositories;
using FluentValidation;

namespace CodeFirst.Core.Validators.Curso
{
    public class StepAddDtoValidator : AbstractValidator<StepAddDtoRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        public StepAddDtoValidator(
            IUnitOfWork unitOfWork
            )
        {
            _unitOfWork = unitOfWork;

            RuleFor(x => x.Code)
                    .NotEmpty().WithMessage("El campo {PropertyName} no puede ser vacío.")
                    .NotNull().WithMessage("El campo {PropertyName}  es requerido.")
                    .MinimumLength(2).WithMessage("El campo {PropertyName} debe  tener minimo 2 caracteres.")
                    .MaximumLength(50).WithMessage("El campo {PropertyName} debe  tener un maximo de caracteres de 50.")
                    .Must(ExisteCodeAsync).WithMessage("El campo {PropertyName} que incluye el valor {PropertyValue} ya existe en el sistemas.")
                    ;

            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("El campo {PropertyName} no puede ser vacío.")
                    .NotNull().WithMessage("El campo {PropertyName}  es requerido.")
                    .WithMessage("Ingrese la {PropertyName}.");
        }

        public bool ExisteCodeAsync(string code) => (_unitOfWork.FieldRepositoryAsync
                               .GetAsync(x => x.Code.Trim().ToUpper()
                                                             .Equals(code.Trim().ToUpper())
                                        )
                               .Result
                               ==
                               null
                   );
    }
}
