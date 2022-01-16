using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoPlanning.Entity.Dto
{
    public class DeveloperAddDto
    {
        [DisplayName("Developer İsim")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Name { get; set; }

        [DisplayName("Developer Saat")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int Hour { get; set; }

        [DisplayName("Developer Zorluk")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int Level { get; set; }
    }
}
