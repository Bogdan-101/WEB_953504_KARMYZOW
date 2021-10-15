using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WEB_953504_KARMYZOW.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; } // название блюда 
        [JsonPropertyName("description")]
        public string Description { get; set; } // описание блюда 
        [JsonPropertyName("rating")]
        public int Rating { get; set; } // кол. калорий на порцию 
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения    
    }
}
