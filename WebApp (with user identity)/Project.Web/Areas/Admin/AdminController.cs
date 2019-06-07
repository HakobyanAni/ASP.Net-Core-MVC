using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.Implementation;
using Project.DAL.Entities;
using Project.Web.Models;

namespace Project.Web.Areas.Admin
{
    public class AdminController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private AdminService _adminService;

        public AdminController(UserManager<UserEntity> userManager, RoleManager<IdentityRole<int>> roleManager, AdminService adminService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _adminService = adminService;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // Create Client
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientModel clientModel, UserModel userModel)
        {
            string resultForCreate = await _adminService.CreateClient(clientModel, userModel);

            return View();
        }

        // Edit Client name
        [HttpPost]
        public async Task<IActionResult> EditClientName(int clientId, string nameToBe, UserModel userModel)
        {
            string resultForEdit = await _adminService.EditClientName(clientId, nameToBe, userModel);

            return View();
        }


        // Delete Client
        [HttpPost]
        public async Task<IActionResult> DeleteClient(int clientId, UserModel userModel)
        {
            string resultForDelete = await _adminService.DeleteClient(clientId, userModel);

            return View();
        }

        // Create User or ClientAdmin
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel userModel)
        {
            try
            {
                UserEntity userToCreate = await _userManager.FindByEmailAsync(userModel.Email);
                if (userToCreate == null)
                {
                    userToCreate = EntityModelConverter.ConvertToEntity(userModel);
                    IdentityResult result = await _userManager.CreateAsync(userToCreate, userModel.Password);
                    if (result.Succeeded)
                    {
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(userToCreate, userModel.Role.ToString());
                        if (!roleResult.Succeeded)
                        {
                            return BadRequest(result.Errors.FirstOrDefault().Description);
                        }
                        return Ok("User was successfully created.");
                    }
                    return BadRequest(result.Errors.FirstOrDefault().Description);
                }
                else
                {
                    return BadRequest("Current user already exists.");
                }
            }
            catch (Exception e)
            {
                // Here we can log the exception
                return BadRequest("Oops! Something went wrong while creating user.");
            }

            // return View(); // 
        }

        // Edit User or ClientAdmin
        public async Task<IActionResult> EditUser(UserModel userModel)
        {
            try
            {
                int userCurrentId = int.Parse(_userManager.GetUserId(User));
                UserEntity userToEdit = await _userManager.FindByIdAsync(userModel.ID.ToString());
                if (userToEdit == null)
                {
                    return BadRequest("User doesn't exist.");
                }
                userToEdit.Name = userModel.Name;
                userToEdit.UpdatedDate = DateTime.Now;
                userToEdit.UpdatedByUserId = userCurrentId;

                // Role changing
                if (!(await _userManager.IsInRoleAsync(userToEdit, userModel.Role.ToString())))
                {
                    string role = (await _userManager.GetRolesAsync(userToEdit)).FirstOrDefault();
                    await _userManager.RemoveFromRoleAsync(userToEdit, role);
                    await _userManager.AddToRoleAsync(userToEdit, userModel.Role.ToString());
                }

                IdentityResult result = await _userManager.UpdateAsync(userToEdit);
                return Ok("Current user was successfully updated.");
            }
            catch
            {
                // Here we can log the exception
                return BadRequest("Oops! Something went wrong while editing user.");
            }
            // return View();
        }

        // Delete User or ClientAdmin
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                UserEntity usertoDelete = await _userManager.FindByIdAsync(id.ToString());
                if (usertoDelete != null)
                {
                    int userCurrentId = int.Parse(_userManager.GetUserId(User));
                    usertoDelete.Deleted = true;
                    usertoDelete.UpdatedDate = DateTime.Now;
                    usertoDelete.UpdatedByUserId = userCurrentId;
                    IdentityResult result = await _userManager.UpdateAsync(usertoDelete);

                    return Ok("Current user was successfully deleted.");
                }
                else
                {
                    return BadRequest("User doesn't exist.");
                }
            }
            catch (Exception e)
            {
                // Here we can log the exception
                return BadRequest("Oops! Something went wrong while creating user.");
            }

            // return View();
        }
    }
}