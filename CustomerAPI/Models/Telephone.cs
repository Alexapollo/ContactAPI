using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI.Models
{
    public class Telephone
    {
        [JsonProperty(PropertyName = "TelephoneId")]
        public int TelephoneId { get; set; }
        [JsonProperty(PropertyName = "Number")]
        public int Number { get; set; }
        [JsonProperty(PropertyName = "ContactId")]
        public int ContactId { get; set; }
        [JsonProperty(PropertyName = "Contact")]
        public virtual Contact Contact { get; set; }
    }
}
