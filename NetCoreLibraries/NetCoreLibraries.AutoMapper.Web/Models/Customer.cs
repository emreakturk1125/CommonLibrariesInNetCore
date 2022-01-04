using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.AutoMapper.Web.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime? Birthday { get; set; }
        public IList<Address> Addresses { get; set; }

        //  map edilecek CustomerDto "public string CreditCardNumber { get; set; }" şeklinde önce class adı sonra property namei yazarsan yine automatik mapler
        public Gender Gender { get; set; }

        //  map edilecek CustomerDto "public string CreditCardValidDate { get; set; }" şeklinde önce class adı sonra property namei yazarsan yine automatik mapler
        //  eğer isimlendirme üstte alatılan gibi olmaz ise CustomerProfile classında manuel yapılmalıdır.
        public CreditCard CreditCard { get; set; } 
        public string GetFullName() // Metod eşlemesinde Başına Get ifadesi konulursa (GetFullName), Mapping yapılacak class da (CustomerDto) "FullName" isminde property varsa mapler
        {
            return $"{Name}-{Email}-{Age}";
        }

        public string GetTumAd() // Metod eşlemesinde Başına Get ifadesi konulursa (GetTumAd), Mapping yapılacak class da (CustomerDtoT) "TumAd" isminde property varsa mapler
        {
            return $"{Name}-{Email}-{Age}";
        }

        public string TumAd2() // Başında Get yoksa Mapping yapılacak class da (CustomerDtoT), "TumAd" isminde property varsa maplemez, manuel olarak yapmak gerekir (CustomerProfile) içinde
        {
            return $"{Name}-{Email}-{Age}";
        }
    }
}
