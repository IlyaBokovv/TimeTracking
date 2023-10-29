using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TimeTracking.Data;
using TimeTracking.Data.DTOs;
using TimeTracking.Data.Models;
using TimeTracking.Data.Repository.Interfaces;

namespace TimeTracking.API.Validation;

public class ReportCreateAndUpdateValidator : AbstractValidator<ReportCreateAndUpdateDTO>
{
    public ReportCreateAndUpdateValidator()
    {
        RuleFor(r => r.Date).
            NotNull()
            .NotEmpty()
            .WithMessage("Date field should not be empty");

        RuleFor(r => r.Description).
            NotNull()
            .NotEmpty()
            .WithMessage("Description field should not be empty");

        RuleFor(r => r.WorkedHours).
            NotNull()
            .NotEmpty()
            .WithMessage("Worked Hours field should not be empty");

    }
}


