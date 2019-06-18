using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class Contact
    {
        [JsonProperty(PropertyName = "ContactId")]
        public int ContactId { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "Address")]
        public string Address { get; set; }
        [JsonIgnore]
        public virtual ICollection<Telephone> Telephones { get; set; }
    }
}
