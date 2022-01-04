using FluentValidation;
using NetCoreLibraries.FluentValidation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.FluentValidation.Web.FluentValidation
{
    // Fluent validation da var olan metodları kullanırsan client taraflı kontrol olur
    // Fakat custom validation yazarsan eğer server taraflı olur
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı boş olamaz";
     
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("{PropertyName} alanı doğru formatta olmalıdır.");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(1,60).WithMessage("{PropertyName} alanı 18 ile 60 arası olmalıdır.");
            RuleFor(x => x.Birthday).NotEmpty().WithMessage(NotEmptyMessage).Must(x => 
            {
                return DateTime.Now.AddYears(-18) >= x;  
            
            }).WithMessage("Yaşınız 18 den büyük olmalıdır.");
            RuleForEach(x => x.Addresses).SetValidator(new AddressValidator());
            RuleFor(x => x.Gender).NotEmpty().WithMessage(NotEmptyMessage).IsInEnum().WithMessage("{PropertyName} alanı Erkek = 1, Bayan = 2 olmalıdır.");
        }
    }
}
