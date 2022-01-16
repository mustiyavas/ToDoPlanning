using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlanning.Entity.Dto
{
    public class ToDoTaskAddDto
    {
        [JsonProperty("zorluk")]
        [DisplayName("Task Zorluk")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int Difficulty { get; set; }

        [JsonProperty("süre")]
        [DisplayName("Task Süre")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int Duration { get; set; }

        [JsonProperty("id")]
        [DisplayName("Task External ID")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public string ExternalID { get; set; }

    }
}
