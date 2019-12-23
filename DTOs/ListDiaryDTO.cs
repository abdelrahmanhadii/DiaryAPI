using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class ListDiaryDTO: IDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Image { get; set; }
        public bool Completed { get; set; }
    }
}
