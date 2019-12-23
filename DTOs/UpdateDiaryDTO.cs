using System;
using System.Collections.Generic;
using System.Text;

namespace DTOs
{
    public class UpdateDiaryDTO: IDTO
    {
        public bool Completed { get; set; }
        public int Id { get; set; }
    }
}
