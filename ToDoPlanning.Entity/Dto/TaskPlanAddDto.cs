using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlanning.Entity.Dto
{
    public class TaskPlanAddDto
    {
        [DisplayName("Task İsim")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Name { get; set; }

        [DisplayName("Task açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(300, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Description { get; set; }

        [DisplayName("Toplam süre (saat)")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int TotalHour { get; set; }

        [DisplayName("Toplam süre (hafta)")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int TotalWeek { get; set; }

        [DisplayName("Başlangıç tarigi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public DateTime StartDate { get; set; }

        [DisplayName("Bitiş taraihi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public DateTime EndDate { get; set; }
    }
}
