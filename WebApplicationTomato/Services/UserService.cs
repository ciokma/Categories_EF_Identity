
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTomato.Data;
using WebApplicationTomato.ViewModel;
namespace WebApplicationTomato.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserService()
        {

        }

        public UserService(ApplicationDbContext context, UserManager<IdentityUser> userManager) {
            _context = context;
            _userManager = userManager;
        } 

        public bool AddRoleToUser(RoleUserDTO userRole)
        {
            try
            {
                
                var user = _context.Users.Find(userRole.UserId);
                //var userStore = new UserStore<IdentityUser>(_context);
                //userStore.AddToRoleAsync(user.Id.ToString(), "ADMINISTRATOR");
                _userManager.AddToRoleAsync(user, userRole.Name);


                return true;
            }

            catch (Exception ex)
            {

                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            var item = _context.Users.Find(id);
            if (item == null)
            {
                return false;
            }
            _context.Users.Remove(item);
            _context.SaveChanges();
            return true;
        }

        public List<UserDTO> GetUsers()
        {
            var listUser = new List<UserDTO>();
            var users = _context.Users.ToList();
            users.ForEach(r =>
            {
                listUser.Add(new UserDTO
                {
                    Id = r.Id,
                    Name = r.UserName
                });
            });
            return listUser;
        }
        public UserDTO GetUserRolesByUserId(Guid id)
        {
            var user = _context.Users.Find(id.ToString());
            var roles = _context.UserRoles.Where(r => r.UserId == id.ToString()).ToList();
            List<RoleDTO> rolesDTO = new List<RoleDTO>();
            roles.ForEach(r =>
            {
                rolesDTO.Add(new RoleDTO
                {
                    Id = r.RoleId,
                    Name = GetRoleName(r.RoleId)
                }
                );
            });

            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                Name = user.UserName,
                Roles = rolesDTO
            };
            return userDTO;
        }
        private string GetRoleName(string id)
        {
            return _context.Roles.Find(id).Name;
        }

        public bool DeleteRolesFromUser(string userId, string id)
        {
            var user = _context.Users.Find(id);
            List<string> roles = new List<string>();
            roles.Add(id.ToString());
            _userManager.RemoveFromRolesAsync(user, roles);
            return true;

        }



    }
}
