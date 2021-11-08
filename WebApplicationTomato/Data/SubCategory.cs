using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTomato.Data
{
    public class SubCategory
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }

        public DateTime CreateDate { get; set; }
        public Nullable<DateTime> DisableDate { get; set; }
        public bool Status { get; set; }

        public virtual Category Category { get; set; }
    }
}
