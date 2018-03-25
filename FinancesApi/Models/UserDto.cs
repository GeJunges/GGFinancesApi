using System.ComponentModel.DataAnnotations;

namespace FinancesApi.Models {

    public class UserDto {

        [Required]
        [MinLength(3, ErrorMessage = "Name must have minimun 3 characters")]
        [MaxLength(60, ErrorMessage = "Name must have maximum 60 characters")]
        public string Name { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Surname must have minimun 3 characters")]
        [MaxLength(60, ErrorMessage = "Surname must have maximum 60 characters")]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}