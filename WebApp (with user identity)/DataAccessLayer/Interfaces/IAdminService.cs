using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    interface IAdminService
    {
        Task CreateClient(ClientModel client);
        Task EditCLient(int clientId, string clientName);
        Task DeleteClient(int clientId);
        Task CreateUser(UserModel user);
        Task EditUser(int userId);
        Task DeleteUser(int userId);
    }
}
