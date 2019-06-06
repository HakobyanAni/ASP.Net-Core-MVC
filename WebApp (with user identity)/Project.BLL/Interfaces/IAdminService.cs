using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Project.Web.Models;

namespace Project.BLL.Interfaces
{
    interface IAdminService
    {
        Task<string> CreateClient(ClientModel client);
        Task<string> EditCLient(int clientId, string clientName);
        Task<string> DeleteClient(int clientId);
    }
}
