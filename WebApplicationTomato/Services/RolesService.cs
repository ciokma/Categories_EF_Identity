
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
    public class RolesService : IRolesService
    {
        private readonly ApplicationDbContext _context;

        public RolesService()
        {

        }

        public RolesService(ApplicationDbContext context) => _context = context;

        public List<RoleDTO> GetAllRoles()
        {
            var roles = _context.Roles.ToList();
            List<RoleDTO> allRoles = new List<RoleDTO>();
            roles.ForEach(r =>
            {
                RoleDTO role = new RoleDTO
                {
                    Id = r.Id,
                    Name = r.Name
                };
                allRoles.Add(role);
            });
           return  allRoles;
        }
        public bool SaveInitialRoles()
        {
            try
            {
                string[] roles = new string[] { "Public", "User", "Admin" };
                foreach (string role in roles)
                {
                    var roleStore = new RoleStore<IdentityRole>(_context);
                    if (!_context.Roles.Any(r => r.Name == role))
                    {
                        roleStore.CreateAsync(new IdentityRole(role));
                    }
                }
                return true;
            }

            catch (Exception)
            {

                return false;
            }
        }

       
    }
}
