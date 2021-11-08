using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTomato.ViewModel
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
        public Nullable<DateTime> DisableDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsVisibleForPublic { get; set; }

        public Guid RoleId { get; set; }
        public Guid RootCategoryId { get; set; }

    }
}
