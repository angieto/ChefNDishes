using System;
using System.ComponentModel.DataAnnotations; // important
using System.ComponentModel.DataAnnotations.Schema; // important
using System.Collections.Generic;

namespace ChefsNDishes.Models {
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}

        [Required(ErrorMessage = "What is the chef's first name?")]
        [MinLength(2, ErrorMessage = "First name should be 2 characters or longer")]
        [MaxLength(45, ErrorMessage = "First name shall not be longer than 10 characters")]
        public string FirstName {get; set;}

        [Required(ErrorMessage = "What is the chef's last name?")]
        [MinLength(2, ErrorMessage = "Last name should be 2 characters or longer")]
        [MaxLength(45, ErrorMessage = "Last name shall not be longer than 10 characters")]
        public string LastName {get; set;}

        [Required(ErrorMessage = "Please select chef's day of birth")]
        [DataType(DataType.Date)]
        [DOB]
        public DateTime DOB {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        // Set up foreign key - collection navigation property
        public List<Dish> Dishes {get; set;}

        // Chef age
        public int Age 
        {
            get { return DateTime.Now.Year - DOB.Year; }
        } 
    }
}