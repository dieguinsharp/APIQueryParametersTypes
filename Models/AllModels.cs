using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QueryTypes.Models {
    public class People {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "Max length is 15")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(25, ErrorMessage = "Max length is 25")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }

        public int? BestGameId { get; set; }
        public BestGame? BestGame { get; set; }
    }

    public class BestGame {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(15, ErrorMessage = "Max length is 15")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        public string Name { get; set; }
    }
}