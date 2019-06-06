using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.BLL.Interfaces;
using Project.DAL;
using Project.DAL.Entities;
using Project.Web.Models;

namespace Project.BLL.Implementation
{
    public class AdminService : BaseService, IAdminService
    {
        public AdminService(ProjectDbContext context) : base(context) { }

        public async Task<string> CreateClient(ClientModel clientModel, UserModel userModel)
        {
            ClientEntity client = await _projectDbContext.Clients.FirstOrDefaultAsync(x => x.ID == clientModel.ID && !x.Deleted);

            if (client == null)
            {
                client = new ClientEntity
                {
                    Name = clientModel.Name,
                    Deleted = false,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CreatedByUserId = userModel.ID
                };

                try
                {
                    await _projectDbContext.Clients.AddAsync(client);
                    await _projectDbContext.SaveChangesAsync();
                    return "Client was created";
                }
                catch (Exception e)
                {
                    // Here we can log this exception
                    return "Oops! Something went wrong while creating client.";
                }
            }
            else
            {
                return "Current client already exists.";
            }
        }

        public async Task<string> EditClientName(int clientId, string nameToBe, UserModel userModel)
        {
            ClientEntity client = await _projectDbContext.Clients.FirstOrDefaultAsync(x => x.ID == clientId && !x.Deleted);

            if (client != null)
            {
                client.Name = nameToBe;
                client.UpdateDate = DateTime.Now;
                client.UpdatedByUserId = userModel.ID;

                try
                {
                    await _projectDbContext.SaveChangesAsync();
                    return "Client name has been changed";
                }
                catch (Exception e)
                {
                    // Here we can log this exception
                    return "Oops! Something went wrong while editing client.";
                }
            }
            else
            {
                return "There is no client with such ID";
            }
        }

        public async Task<string> DeleteClient(int clientId, UserModel userModel)
        {
            ClientEntity client = await _projectDbContext.Clients.FirstOrDefaultAsync(x => x.ID == clientId && !x.Deleted);

            if (client != null)
            {
                client.Deleted = true;
                client.UpdateDate = DateTime.Now;
                client.UpdatedByUserId = userModel.ID;

                try
                {
                    await _projectDbContext.SaveChangesAsync();
                    return "Client was deleted.";
                }
                catch (Exception e)
                {
                    // Here we can log this exception
                    return "Oops! Something went wrong while deleting client.";
                }
            }
            else
            {
                return "There is no client with such ID";
            }
        }
    }
}