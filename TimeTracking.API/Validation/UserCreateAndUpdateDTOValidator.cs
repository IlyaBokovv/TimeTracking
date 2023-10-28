using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Data;
using TimeTracking.Data.DTOs;
using TimeTracking.Data.Models;
using TimeTracking.Data.Repository.Interfaces;

namespace TimeTracking.API.Validation;

public class UserCreateAndUpdateDTOValidator : AbstractValidator<UserCreateAndUpdateDTO>
{
    public UserCreateAndUpdateDTOValidator(IUserRepository userRepository)
    {
        RuleFor(u => u.Email)
            .NotNull()
            .EmailAddress()
            .WithMessage("The email must be a valid email")
            .MustAsync(async (email, _) =>
        {
            return await userRepository.IsEmailUniqueAsync(email);
        }).WithMessage("The email must me unique");

        RuleFor(u => u.FirstName).
            NotNull()
            .NotEmpty()
            .WithMessage("First Name field should not be empty");

        RuleFor(u => u.LastName).
            NotNull()
            .NotEmpty()
            .WithMessage("Last Name field should not be empty");

        RuleFor(u => u.MiddleName).
            NotNull()
            .NotEmpty()
            .WithMessage("Middle Name field should not be empty");


    }
}


