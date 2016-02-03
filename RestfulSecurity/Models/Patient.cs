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
        public string Title { get; set; }
       
        [StringLength(100)]
        public string FirstName { get; set; }
        
        [StringLength(100)]
        public string LastName { get; set; }
        
        public int Age { get; set; }
        
        public int NumberOfEmbryos { get; set; }

        [JsonIgnore]
        public IList<File> Files { get; set; }
    }
}