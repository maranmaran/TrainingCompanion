using Backend.Domain;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Users.UsersRequests.UpdateUser
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserRequestValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(15)
                .Must(UniqueUsername)
                .WithMessage("Username must be unique"); ;

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .EmailAddress()
                .Must(UniqueEmail)
                .WithMessage("Email must be unique");

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(15);

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(15);
        }

        private bool UniqueUsername(UpdateUserRequest request, string username)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            return user == null; // no user with that username
        }

        private bool UniqueEmail(UpdateUserRequest request, string email)
        {
            var user = _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            return user == null; // no user with that email
        }
    }
}