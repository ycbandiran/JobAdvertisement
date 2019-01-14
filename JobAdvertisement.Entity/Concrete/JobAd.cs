using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JobAdvertisement.Entity.Concrete
{
    public class JobAd 
    {       
        public int JobAdID { get; set; }

        [Required(ErrorMessage = "Please enter a job title")]
        [StringLength(100, ErrorMessage = "Job title should be maximum 100 characters long !")]
        public string JobAdTitle { get; set; }

        [Required(ErrorMessage = "Please enter a job content")]
        [StringLength(200, ErrorMessage = "Job content should be maximum 200 characters long !")]
        public string JobAdContent { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [StringLength(100, ErrorMessage = "Name should be maximum 100 characters long !")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "Please enter your surname")]
        [StringLength(100, ErrorMessage = "Surname should be maximum 100 characters long !")]
        public string ApplicantSurname { get; set; }

        [Required(ErrorMessage = "Please enter a valid phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone number is not valid !")]
        public long ApplicantPhoneNumber { get; set; }

        [Required(ErrorMessage = "Please enter a valid e-mail adress")]
        [StringLength(200, ErrorMessage = "E-mail adress should be maximum 200 characters long")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage ="E-mail adress is not valid !")]
        public string ApplicantEmailAdress { get; set; }          
    }
}
