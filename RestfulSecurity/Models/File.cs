using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestfulSecurity.Models
{
    public class File
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string FileName { get; set; }

        [JsonIgnore] 
        public int PatientID { get; set; }

        [JsonIgnore]
        public Patient Patient { get; set; }
    }
}