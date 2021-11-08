using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTomato.Data;
using WebApplicationTomato.ViewModel;

namespace WebApplicationTomato.Services
{
    public interface ICategoryService
    {
        /// <summary>
        /// Get All active categories 
        /// </summary>
        /// <returns></returns>
        public List<Category> GetAllCategories();
        public List<Category> GetAllCategoriesParentAndChildren();

        public List<Category> GetAllCategoriesRoot();
        public Category GetCategorieById(Guid Id);

        /// <summary>
        /// Save the Item
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool SaveCategory(Category category);
        /// <summary>
        /// Check if the item exists through the description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool ExistCategoryDescription(string description);
        public bool SaveCategoryChanges(CategoryUpdateDTO categoryDto);
        public bool DeleteCategory(Guid Id);



    }
}
