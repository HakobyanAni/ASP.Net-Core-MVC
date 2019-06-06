using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project.Web.Models;

namespace Project.BLL.Interfaces
{
    interface IAdminService
    {
        Task<string> CreateClient(ClientModel clientModel, UserModel userModel);
        Task<string> EditClientName(int clientId, string nameToBe, UserModel userModel);
        Task<string> DeleteClient(int clientId, UserModel userModel);
    }
}
