using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTomato.Data;
using WebApplicationTomato.ViewModel;

namespace WebApplicationTomato.Services
{
    public class CategoryService : ICategoryService
    {
        public ApplicationDbContext _context;

        public CategoryService()
        {

        }
        public CategoryService(ApplicationDbContext context) => _context = context;
        public List<Category> GetAllCategories()
        {
            return _context.Categories.Where(c => c.IsActive).ToList();
        }
        public List<Category> GetAllCategoriesParentAndChildren()
        {
            //Four  levels of categories
            return _context.Categories
                .Include(category => category.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ToList();
        }
        public List<Category> GetAllCategoriesRoot()
        {
            //Four  levels of categories
            return _context.Categories
                .Include(category => category.ChildCategories)
                .ThenInclude(c=>c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .ThenInclude(c => c.ChildCategories)
                .Where(r=>r.RootCategory == null).ToList();
        }
        public Category GetCategorieById(Guid Id)
        {
            return _context.Categories.Find(Id);
        }
        public bool SaveCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
    
        }
        public bool ExistCategoryDescription(string description)
        {
            return _context.Categories.Where(d=>d.Description.ToLower() == description.ToLower()).Count() > 0;
        }

        public bool SaveCategoryChanges(CategoryUpdateDTO categoryDto)
        {
            try
            {
                var updatecategoryDto = _context.Categories.Find(categoryDto.Id);
                if (categoryDto.IsActive != updatecategoryDto.IsActive && !categoryDto.IsActive)
                {
                    updatecategoryDto.DisableDate = DateTime.Now;
                }
                if (categoryDto.IsActive != updatecategoryDto.IsActive && categoryDto.IsActive)
                {
                    updatecategoryDto.DisableDate = null;
                }
                updatecategoryDto.Description = categoryDto.Description;
                updatecategoryDto.IsActive = categoryDto.IsActive;
                updatecategoryDto.IsVisibleForPublic = categoryDto.IsVisibleForPublic;
                categoryDto.RoleId = categoryDto.RoleId;
                categoryDto.RootCategoryId = categoryDto.RootCategoryId;

                _context.Entry(updatecategoryDto).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }
        public bool DeleteCategory(Guid Id)
        {
            try
            {
                var item = _context.Categories.Find(Id);
                if (item == null)
                {
                    return false;
                }
                _context.Categories.Remove(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

    }
}
