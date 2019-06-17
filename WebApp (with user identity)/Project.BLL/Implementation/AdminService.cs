using System;
using System.Collections.Generic;
using System.Linq;
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

        public IQueryable<ClientEntity> GetAllClients()
        {
            var clients = _projectDbContext.Clients;
            return clients;
        }

        public async Task<ClientModel> GetClientById(int id)
        {
            try
            {
                var client = await _projectDbContext.Clients.Where(x => !x.Deleted && x.ID == id).Select(x => new ClientModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    CreatedByUserId = x.CreatedByUserId,
                    CreateDate = x.CreateDate,
                    Users = x.Users.Select(u => new UserModel
                    {
                        ClientId = u.ClientId,
                        Email = u.Email,
                        Name = u.Name,
                        UserName = u.UserName
                    }).ToList()
                }).FirstOrDefaultAsync();

                return client;
            }
            catch (Exception e)
            {
                // Here we can log Exception
                throw;
            }
        }

        public async Task<string> CreateClient(ClientModel clientModel, int userId)
        {
            ClientEntity client = await _projectDbContext.Clients.FirstOrDefaultAsync(x => x.Name == clientModel.Name && !x.Deleted);

            if (client == null)
            {
                client = new ClientEntity
                {
                    Name = clientModel.Name,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    CreatedByUserId = userId
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