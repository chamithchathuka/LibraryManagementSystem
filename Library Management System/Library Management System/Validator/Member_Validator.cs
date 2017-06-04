using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Library_Management_System.Validator
{
    class Member_Validator : AbstractValidator<Member_Detail>
    {

        public Member_Validator() {
            
            RuleFor(member => member.first_name).NotEmpty().NotNull().WithMessage("Please insert your {PropertyName}"); 
            RuleFor(member => member.last_name).NotEmpty().NotNull().WithMessage("Please insert your {PropertyName}"); 
            RuleFor(member => member.phone_number).NotEmpty().NotNull().WithMessage("Please insert your {PropertyName}"); 
            RuleFor(member => member.address).NotEmpty().NotNull().WithMessage("Please insert your {PropertyName}"); 
            RuleFor(member => member.dob).NotEmpty().NotNull().WithMessage("Please insert your {PropertyName}");
            RuleFor(member => member.email).NotEmpty().NotNull().WithMessage("Please insert your {PropertyName}");
                       
            RuleFor(member => member.email).EmailAddress().WithMessage("Please submit a valid email").When(member => string.IsNullOrEmpty(member.email));

        }

        private object When(Func<Member_Detail, bool> p)
        {
            throw new NotImplementedException();
        }

        private bool BeAValidDate(DateTime? value)
        {
            Boolean isValidDate = false;

            DateTime date = new DateTime(1900,01,01);
            if (value > date) {
                isValidDate = true;
            }

            return isValidDate;
        }
    }
}
