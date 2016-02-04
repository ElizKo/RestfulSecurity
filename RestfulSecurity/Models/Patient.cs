using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestfulSecurity.Models
{
    public class Patient
    {
        public int Id { get; set; }
 
        [StringLength(50)]
        [DataType(DataType.Text)]
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = "First name can't be empty")]
        public string Title { get; set; }
       
        [StringLength(100)]
        [DataType(DataType.Text)]
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = "First name can't be empty")]
        public string FirstName { get; set; }
        
        [StringLength(100)]
        [DataType(DataType.Text)]
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = "Last name can't be empty")]
        public string LastName { get; set; }

        [Range(8, 120, ErrorMessage = "Age can be between 8 and 120")]
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = "First name can't be empty")]
        public int Age { get; set; }
        
        public int NumberOfEmbryos { get; set; }

        [JsonIgnore]
        public IList<File> Files { get; set; }
    }
}