using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UI.Models
{
    public class IndexModel
    {
        public MembershipOptionModel[] MembershipOptions;

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required]
        [Display(Name = "Type")]
        public SelectListItem SelectedCreditCardType { get; set; }

        public SelectListItem[] CreditCardTypes { get; set; }
    }
}

/* 001
 * using System;

namespace UI.Models
{
    public class IndexModel
    {
        public MembershipOptionModel[] MembershipOptions;
    }
}
*/