using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTomato.ViewModel;

namespace WebApplicationTomato.Services
{
    public interface IUserService
    {
        public List<UserDTO> GetUsers();
        public bool AddRoleToUser(RoleUserDTO userRole);
        public bool DeleteUser(Guid id);
        public UserDTO GetUserRolesByUserId(Guid id);
        public bool DeleteRolesFromUser(string userId, string id);

    }
}
