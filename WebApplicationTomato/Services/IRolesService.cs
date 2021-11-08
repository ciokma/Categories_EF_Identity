using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTomato.ViewModel;

namespace WebApplicationTomato.Services
{
    public interface IRolesService
    {
        public List<RoleDTO> GetAllRoles();
    }
}
