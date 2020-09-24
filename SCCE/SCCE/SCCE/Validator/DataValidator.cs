using FluentValidation;
using SCCE.Models;

namespace SCCE.Validator
{
    public class DataValidator : AbstractValidator<RegionalModel>
    {
        public DataValidator()
        {
            RuleFor(c => c.Nome).Must(n => ValidateStringEmpty(n)).WithMessage("Nome nao pode estar vazio");
            RuleFor(c => c.Codigo).NotEmpty().WithMessage("Codigo nao pode estar vazio!");
            RuleFor(c => c.CentroCusto).Must(n => ValidateStringEmpty(n)).WithMessage("CentroCrusto nao pode estar vazio");
        }

        private bool ValidateStringEmpty(string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue)) return true;

            return false;
        }
    }
}