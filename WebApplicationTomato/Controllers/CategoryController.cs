using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTomato.Data;
using WebApplicationTomato.Services;
using WebApplicationTomato.Utilities;
using WebApplicationTomato.ViewModel;

namespace WebApplicationTomato.Controllers
{
    public class CategoryController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IRolesService _rolesService;
        private readonly ICategoryService _categoryService;

        public CategoryController(UserManager<IdentityUser> userManager, IRolesService rolesService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _rolesService = rolesService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            CategoryDTO categoryDTO = new CategoryDTO();
          
            ViewBag.RolesList = GetRoleItem();
            ViewBag.CategoryList = GetCategories();

            return View(categoryDTO);
        }
        /// <summary>
        /// Get All roles 
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> GetRoleItem()
        {
            List<SelectListItem> roleItems = new List<SelectListItem>();
            roleItems.Add(new SelectListItem { Value = Guid.Empty.ToString(), Text = "Select role if the Category is NOT visible for public" });
            //Searching for role
            var roles = _rolesService.GetAllRoles();
            roles.ForEach(item =>
            {
                roleItems.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Selected = false
                });
            });
            return roleItems;
        }
        private List<SelectListItem> GetCategories()
        {
            List<SelectListItem> categoryItems = new List<SelectListItem>();
            categoryItems.Add(new SelectListItem { Value = Guid.Empty.ToString(), Text = "Select a category if apply" });
            //Searching for role
            var categories = _categoryService.GetAllCategories();
            categories.ForEach(item =>
            {
                categoryItems.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = item.Id.ToString(),
                    Selected = false
                });
            });
            return categoryItems;
        }
        [HttpPost]
        
        public IActionResult Create(CategoryDTO categoryDTO)
        {
            try
            {
                Category cat = new Category();
                if(categoryDTO.RootCategoryId != Guid.Empty)
                {
                    cat = _categoryService.GetCategorieById(categoryDTO.RootCategoryId);
                }
                //Creating the model
                Category category = new Category
                {
                    Id = Guid.NewGuid(),
                    Description = categoryDTO.Description,
                    CreateDate = DateTime.Now,
                    DisableDate = null,
                    IsActive = true,
                    IsVisibleForPublic = categoryDTO.IsVisibleForPublic,
                    RoleId = categoryDTO.RoleId,
                    RootCategory = cat
                };
                //Check if the item was saved
                if (_categoryService.SaveCategory(category))
                {
                    ViewBag.SucessMessage =  RsMessage.MessageSuccessCategory;
                }
                else
                {
                   throw new Exception(RsMessage.MessageErrorCategory);
                }
 
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Index", categoryDTO);
            }
            finally {
                ViewBag.RolesList = GetRoleItem();
                ViewBag.CategoryList = GetCategories();

            }
            return View("Index", categoryDTO);

        }

        public IActionResult ManageCategory()
        {
            CategoryDTO categoryDTO = new CategoryDTO();
            List<CategoryDTO> categories = new List<CategoryDTO>();


            var allCategories = _categoryService.GetAllCategoriesParentAndChildren();


            allCategories.ForEach(c =>
            {
                categories.Add(new CategoryDTO
                {
                    Id = c.Id,
                    Description = c.Description,
                    CreateDate = c.CreateDate,
                    IsActive = c.IsActive,
                    DisableDate = c.DisableDate,
                    IsVisibleForPublic = c.IsVisibleForPublic,
                    RoleId = c.RoleId
                });
            });
            ViewBag.RolesList = GetRoleItem();
            ViewBag.CategoryList = GetCategories();
            return View(categories);
        }
        [HttpPost]
        public JsonResult GetCategory(Guid Id)
        {
            var category = _categoryService.GetCategorieById(Id);
            return Json(category);
        }
        [HttpPost]
        public JsonResult SaveChangesCategory(CategoryUpdateDTO category)
        {
            if (_categoryService.SaveCategoryChanges(category))
            {
                return Json(new { status = true});

            }
            return Json(new { status = false });

        }
        [HttpPost]
        public JsonResult DeleteCategory(Guid Id)
        {
            if (_categoryService.DeleteCategory(Id))
            {
                return Json(new { status = true });

            }
            return Json(new { status = false });

        }

        #region Validaciones

        private void ValidateCategoryData(CategoryDTO categoryDTO)
        {
            if (categoryDTO.Description.Equals(string.Empty))
            {
                throw new Exception(RsMessage.MessageCategoryDescriptionValidation);
            }
            else if (!categoryDTO.IsVisibleForPublic)
            {
                if (categoryDTO.RoleId.Equals(Guid.Empty))
                {
                    throw new Exception(RsMessage.MessageCategoryRoleValidation);
                }
            }
        }

        #endregion

    }
}
