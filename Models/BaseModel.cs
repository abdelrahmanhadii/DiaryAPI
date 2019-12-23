using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class BaseModel
    {
        public string EnteredBy { get; set; }
        public DateTime EnteredDate { get; set; }
        public string LastUpdatedBy { get; set; }
        DateTime LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string IsDeletedBy { get; set; }
        public string IsDeletedDate { get; set; }
    }
}
