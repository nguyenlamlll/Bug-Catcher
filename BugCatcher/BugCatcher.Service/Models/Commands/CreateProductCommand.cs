using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BugCatcher.Service.Models.Commands
{
    public class CreateProductCommand
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100,
               ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.",
               MinimumLength = 4)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public Guid CompanyId { get; set; }
    }
}
