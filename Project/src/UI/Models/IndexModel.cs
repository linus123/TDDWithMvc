using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace UI.Models
{
    public class IndexModel
    {
        public MembershipOptionModel[] MembershipOptions;

        [Required]
        [Display(Name = "Membership Option")]
        public string SelectedMembershipOption { get; set; }

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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required]
        [Display(Name = "Type")]
        public string SelectedCreditCardType { get; set; }

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