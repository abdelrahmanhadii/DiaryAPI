using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTOs
{
    public class CreateDiaryDTO: IDTO
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public string Image { get; set; }
        public string UserId { get; set; }
        public string EnteredBy { get; set; }
        public DateTime EnteredDate = DateTime.Now;
        public bool Completed = false;
    }
}
