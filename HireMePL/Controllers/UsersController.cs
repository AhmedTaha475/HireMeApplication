using HireMeBLL;
using HireMeBLL.Dtos.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public UsersController(IClientManager clientManager,ISystemUserManager systemUserManager,UserManager<IdentityUser> userManager)
        {
            this._clientManager = clientManager;
            this._systemUserManager = systemUserManager;
            this._userManager = userManager;
        }


        #region Login Method
        [HttpPost]
        [Route("Login")]

        //Single Login EndPoint for all users on the system Even the admin
        public async Task<ActionResult<TokenDto>> login(LoginDto loginCred)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var token = await _systemUserManager.Login(loginCred);

            if (token != null)
                return Ok(token);
            else
                return BadRequest(ModelState);



        }
        #endregion



        #region Client Operations

        [HttpPost]
        [Route("RegisterClient")]
        public async Task<ActionResult> RegisterClient(ReigsterClientDto clientData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _clientManager.CreateClient(clientData);

            if (result)
            {
                return Ok(new { Message = "Client Created Successfully" });
            }
            return BadRequest(new { Message = "Something went wrong.... Please try again " });


        }


        [HttpDelete]
        [Route("DeleteCurrentClient")]
        //[Authorize]  client will delete his account
        public async Task<ActionResult> DeleteCurrentClient()
        {
            var ClientToBeDeleted = await _userManager.GetUserAsync(User);
            try
            {
                if (await _clientManager.deleteClient(ClientToBeDeleted.Id))
                {
                    return Ok(new { Message = "Client Deleted Successfully" });
                }
                else
                {
                    return BadRequest(new { Message = "Something went wrong ..." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }
        [HttpDelete]
        [Route("DeleteClient/{id}")]
        //[Authorize]  client will delete his account
        public async Task<ActionResult> DeleteClientById(string id)
        {

            try
            {
                if (await _clientManager.deleteClient(id))
                {
                    return Ok(new { Message = "Client Deleted Successfully" });
                }
                else
                {
                    return BadRequest(new { Message = "Something went wrong ..." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }

        [HttpGet]
        [Route("GetAllClients")]

        public ActionResult<List<ClientDto>> GetAllClients()
        {


            var clientlist = _clientManager.GetAllClients();

            if (clientlist != null)
                return Ok(new { Message = "Here are all clients", body = clientlist });
            return NotFound(new { Message = "No Clients Were Found" });

        }

        [HttpGet]
        [Route("GetClientById/{id}")]

        public async Task<ActionResult<ClientDto>> GetClientById(string id)
        {

            var Client =await _clientManager.GetClientById(id);

            if (Client != null)
                return Ok(new { Message = "Here is Your Client", body = Client });
            return NotFound(new { Message = "No Client was Found" });
        }

        [HttpGet]
        [Route("GetCurrentClient")]

        public async Task<ActionResult<ClientDto>> GetCurrentClient()
        {

            var CurrentClient = await _userManager.GetUserAsync(User);

            var Client = _clientManager.GetClientById(CurrentClient.Id);

            if (Client != null)
                return Ok(new { Message = "Here is Your Client", body = Client });
            return NotFound(new { Message = "No Client was Found" });
        }

        [HttpPut]
        [Route("UpdateClient")]

        public async Task<ActionResult> UpdateClientData([FromForm] UpdateClientDto clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {

                if (await _clientManager.UpdateClient(clientDto))
                    return Ok(new { Message = "Client Updated successfully" });
                else return BadRequest(new { Message = "Something Went wrong...." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        #endregion


    }
}
