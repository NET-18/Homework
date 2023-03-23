using ApiWithEF.Dtos;
using ApiWithEF.Models;
using ApiWithEF.Persistance;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApiWithEF.Validators
{

    public class UserDtoValidator : AbstractValidator<AddUserDto>
    {
        private readonly StoreDbContext _context;
        public UserDtoValidator(StoreDbContext context)
        {
            RuleFor(u => u.BirthDate)
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(u => u.Password)
                .NotEmpty();

            RuleFor(u => u.Adress)
                .NotEmpty()
                .Must(CheckValue);
            _context = context;
        }

        public bool CheckValue(string v)
        {
            foreach (string item in _context.Users.Select(u => u.Adress).ToList())
            {
                if (v == item)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
