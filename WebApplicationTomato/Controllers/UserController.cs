using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserService _userService;
        private readonly IRolesService _rolesService;

        public UserController(UserManager<IdentityUser> userManager, IUserService userService, IRolesService roleService)
        {
            _userManager = userManager;
            _userService = userService;
            _rolesService = roleService;
        }

        public IActionResult Index()
        {
       
            return View();
        }
       
        

        public IActionResult ManageUser()
        {
            List<UserDTO> userDTO = new List<UserDTO>();


            var users = _userService.GetUsers();


            users.ForEach(u =>
            {
                userDTO.Add(new UserDTO
                {
                    Id = u.Id,
                    Name = u.Name
                });
            });
            ViewBag.RoleList = GetRoleItem();
            return View(userDTO);
        }

        /// <summary>
        /// Get All roles 
        /// </summary>
        /// <returns></returns>
        private List<SelectListItem> GetRoleItem()
        {
            List<SelectListItem> roleItems = new List<SelectListItem>();
            roleItems.Add(new SelectListItem { Value = Guid.Empty.ToString(), Text = "Select role..." });
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
        [HttpPost]
        public JsonResult GetUser(Guid Id)
        {
            var user = _userService.GetUserRolesByUserId(Id);
            return Json(user);
        }
        [HttpPost]
        public JsonResult AddRole(RoleUserDTO userRole)
        {

            _userService.AddRoleToUser(userRole);
            return Json(userRole);
        }
        [HttpPost]
        public JsonResult DeleteRoleFromUser(RoleUserDTO roleUserDTO)
        {
            if (_userService.DeleteRolesFromUser(roleUserDTO.Id, roleUserDTO.UserId))
            {
                return Json(new { status = true });

            }
            return Json(new { status = false });

        }
    }
}
