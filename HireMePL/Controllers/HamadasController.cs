using HireMeBLL.Dtos;
using HireMeBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HireMeDAL;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HamadasController : ControllerBase
    {
        private readonly ISystemUserManager systemUserManager;
        private readonly UserManager<IdentityUser> usermanager;
        private readonly RoleManager<IdentityRole> roleManager;

        public HamadasController(ISystemUserManager SystemUserManager, UserManager<IdentityUser> usermanager, IConfiguration configuration, RoleManager<IdentityRole> RoleManager)
        {
            systemUserManager = SystemUserManager;
            this.usermanager = usermanager;
            roleManager = RoleManager;
        }
        [HttpPost]
        public async Task<ActionResult> CreateSystemUser(SystemUserDto SystemUserDto)
        {
            #region Test
            //SystemUser user = new SystemUser();
            //user.FirstName = SystemUserDto.FirstName;
            //user.LastName = SystemUserDto.LastName;
            //user.Email = SystemUserDto.Email;
            //user.UserName = SystemUserDto.UserName;
            //user.PaymentMethodId = SystemUserDto.PaymentMethodId;
            //user.PlanId = SystemUserDto.PlanId;

            ////2-Hash Pasword and create user
            //var hashpassword = await usermanager.CreateAsync(user, SystemUserDto.Password);

            //    if (!hashpassword.Succeeded)
            //    {

            //    return Ok(hashpassword.ToString());
            //    }
            //    //2.5-Roles
            //    var Role = roleManager.Roles.FirstOrDefault(r => r.Name == "Admin");
            //    if (Role == null)
            //    {
            //        await roleManager.CreateAsync(new IdentityRole() { Name = "Admin", Id = "esenfkfkebhjsehsb" });
            //    }
            //    var addedUser = await usermanager.FindByEmailAsync(user.Email);
            //    await usermanager.AddToRoleAsync(addedUser, "Admin");

            //    //3-make cliame for user
            //    var Claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.NameIdentifier, addedUser.UserName),
            //    new Claim (ClaimTypes.Role,"Admin")
            //};
            //    //4-attach this claim for tis user
            //    await usermanager.AddClaimsAsync(addedUser, Claims);
            //    Console.WriteLine("Done from dal");
            //    return Ok("Done");
            //}

            #endregion

            var result = await systemUserManager.CreateSystemUser(SystemUserDto);
            if (result)
            {
                return Ok("Data Inserted Successfully ^_^");
            }
            return NotFound(result);
        }

        //[HttpGet]
        //[Authorize]
        //public async Task<ActionResult<SystemUser>> GetSystemUser()
        //{
        //    return (SystemUser)await usermanager.GetUserAsync(User);
        //}
    }
}

