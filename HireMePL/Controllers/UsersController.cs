using HireMeBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace HireMePL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IClientManager _clientManager;
        private readonly ISystemUserManager _systemUserManager;

        public UsersController(IClientManager clientManager,ISystemUserManager systemUserManager)
        {
            this._clientManager = clientManager;
            this._systemUserManager = systemUserManager;
        }

        [HttpPost]
        [Route("RegisterClient")]
        public async Task<ActionResult>  RegisterClient(ReigsterClientDto clientData)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _clientManager.CreateClient(clientData);

            if (result)
            {
                return Ok(new {Message="Client Created Successfully"});
            }
            return BadRequest(new {Message="Something went wrong.... Please try again "});


        }
        [HttpPost]
        [Route("Login")]

        //Single Login EndPoint for all users on the system Even the admin
        public async Task<ActionResult<TokenDto>> login (LoginDto loginCred)
        {
            if(!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            var token=await _systemUserManager.Login(loginCred);

            if (token != null)
                return Ok(token);
            else 
                return BadRequest(ModelState);



        }


    }
}
