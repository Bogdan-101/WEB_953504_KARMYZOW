using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WEB_953504_KARMYZOW.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; } // id блюда 
        [JsonPropertyName("Name")]
        public string Name { get; set; } // название блюда 

    }
}
