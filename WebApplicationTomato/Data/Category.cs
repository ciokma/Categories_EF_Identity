using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTomato.Services;

namespace WebApplicationTomato.Data
{
    public class Category
    {
        public Guid Id { get; set; }

        public Category RootCategory { get; set; } // This one works good, it also creates "RootCategory_Id" in database on "update-database"

        public List<Category> ChildCategories { get; set; }
        [Required]
        [StringLength(150)]
        public string Description { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        public Nullable<DateTime> DisableDate { get; set; }
        [Required]
        public bool IsActive { get; set; }

        public bool IsVisibleForPublic { get; set; }

        public Guid RoleId { get; set; }
        public int Order { get; set; }

        //public virtual List<SubCategory> SubCategories { get; set; }
    }
}
