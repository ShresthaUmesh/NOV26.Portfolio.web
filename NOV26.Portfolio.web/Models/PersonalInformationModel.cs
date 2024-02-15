using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NOV26.Portfolio.web.Models
{
    public class PersonalInformationModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Phone { get; set; }
        [DisplayName("No. of Completed Projects")]
        public int CompletedProjects { get; set; }
        public string Country { get; set; }
        [Required(AllowEmptyStrings = true)]
        [DisplayName("Photo")]
        public string UserPhotoUrl { get; set; } = "";
    }
}
