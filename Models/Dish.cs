using System;
using System.ComponentModel.DataAnnotations; // important
using System.ComponentModel.DataAnnotations.Schema; // important

namespace ChefsNDishes.Models {
    public class Dish 
    {
        [Key]
        public int DishId {get; set;}

        [Required(ErrorMessage = "What is the the dish name?")]
        [MinLength(2, ErrorMessage = "Minimum 2 characters")]
        [MaxLength(45, ErrorMessage = "Maximum 45 characters")]
        public string Name {get; set;}

        // [Required(ErrorMessage = "What is the chef's name?")]
        // public int Chef {get; set;}

        [Required(ErrorMessage = "Rating is required")]
        [Range(1, 6)]
        public int Tastiness {get; set;}

        [Required(ErrorMessage = "Invalid calories input")]
        [Range(1, 100000000)]
        public int Calories {get; set;}

        [Required(ErrorMessage = "Description field is missing")]
        [MinLength(5, ErrorMessage = "Minimum 5 chatacters")]
        public string Description {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        // Set up Foreign Key - a reference navigation property
        [Required(ErrorMessage="Select a chef")]
        public int chefs_ChefId {get; set;}

        [ForeignKey("chefs_ChefId")]
        public Chef Creator {get; set;}
    }
}