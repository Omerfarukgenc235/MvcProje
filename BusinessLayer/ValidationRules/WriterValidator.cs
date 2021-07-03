using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar Soy Adını Geçemezsiniz.");
            RuleFor(x => x.WriterPassword).MinimumLength(3).WithMessage("Şifreyi Boş Geçemezsiniz.");
            RuleFor(x => x.WriterAbout).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla giriş yapmayınız.");
            RuleFor(x => x.WriterAbout).MinimumLength(2).WithMessage("Lütfen en az 2 karakterden fazla giriş yapınız.");
            RuleFor(x => x.WriterTitle).MinimumLength(2).WithMessage("Lütfen en az 2 karakterden fazla giriş yapınız.");

        }
    }
}
