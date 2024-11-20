using FluentValidation;

namespace Hangman
{
    

    public class UserInputValidator : AbstractValidator<string>
    {
        public UserInputValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Input can't be empty.")
                .Length(1, 1).WithMessage("Please enter one character.")
                .Matches(@"^[a-zA-Z]+$").WithMessage("Only letters are allowed.");
        }
    }

}
