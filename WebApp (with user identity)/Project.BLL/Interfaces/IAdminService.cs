using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.DAL.Entities;
using Project.Web.Models;

namespace Project.BLL.Interfaces
{
    interface IAdminService
    {
        IQueryable<ClientEntity> GetAllClients();
        Task<ClientModel> GetClientById(int id);
        Task<string> CreateClient(ClientModel clientModel, int userId);
        Task<string> EditClientName(int clientId, string nameToBe, UserModel userModel);
        Task<string> DeleteClient(int clientId, UserModel userModel);
    }
}
