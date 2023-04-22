using HireMeBLL;
using HireMeBLL.Dtos.Client;
using HireMeDAL;
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
        private readonly IFreelancerManager _freelancerManager;

        public UsersController(IClientManager clientManager,ISystemUserManager systemUserManager,
            UserManager<IdentityUser> userManager,IFreelancerManager freelancerManager)
        {
            this._clientManager = clientManager;
            this._systemUserManager = systemUserManager;
            this._userManager = userManager;
            this._freelancerManager = freelancerManager;
        }


        #region System Methods
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
                return NotFound(new {Message="Login failed please check your email and password"});

        }



        [HttpPost]
        [Route("ChangePassword")]
        [Authorize]
        public async Task<ActionResult> ChangePassowrd(ChangePasswordDto passwordData)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            var CurrentUser=await _userManager.GetUserAsync(User);

           var result= await _systemUserManager.changeUserPassword(CurrentUser, passwordData.oldPassword,passwordData.NewPassword);

            if(result)
                return Ok(new {Message="Password Changed Successfully"});
            return BadRequest(new {Message="Couldn't change the password"});
        }
        #endregion


        #region Freelancer Operations
        [HttpPost]
        [Route("RegisterFreelancer")]
        public async Task<ActionResult> RegisterFreelancer(RegisterFreelancerDto FreelancerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {


                var result = await _freelancerManager.CreateFreelancer(FreelancerData);

                if (result)
                {
                    return Ok(new { Message = "Freelancer Created Successfully" });
                }
                return BadRequest(new { Message = "Something went wrong.... Please try again " });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }

        }


        [HttpDelete]
        [Route("DeleteCurrentFreelancer")]
        [Authorize(policy: "Freelancer")]  
        public async Task<ActionResult> DeleteCurrentFreelancer()
        {
            var FreelancerToBeDeleted = await _userManager.GetUserAsync(User);
            try
            {
                if (await _freelancerManager.deleteFreelancer(FreelancerToBeDeleted.Id))
                {
                    return Ok(new { Message = "Freelancer Deleted Successfully" });
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
        [Route("DeleteFreelancer/{id}")]
        [Authorize(policy: "Freelancer&Admin")]
        public async Task<ActionResult> DeleteFreelancerById(string id)
        {

            try
            {
                if (await _freelancerManager.deleteFreelancer(id))
                {
                    return Ok(new { Message = "Freelancer Deleted Successfully" });
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
        [Route("GetAllFreelancer")]
        [Authorize(policy: "Admin")]
        public ActionResult<List<ClientDto>> GetAllFreelancers()
        {


            var freelancersList = _freelancerManager.GetAllFreelancers();

            if (freelancersList != null)
                return Ok(new { Message = "Here are all Freelancers", body = freelancersList });
            return NotFound(new { Message = "No Freelancers Were Found" });

        }



        [HttpGet]
        [Route("GetFreelancerById/{id}")]
        [Authorize]
        public async Task<ActionResult<ClientDto>> GetFreelancerById(string id)
        {

            var Freelancer = await _freelancerManager.GetFreelancerById(id);

            if (Freelancer != null)
                return Ok(new { Message = "Here is Your Freelancer", body = Freelancer });
            return NotFound(new { Message = "No Freelancer was Found" });
        }

        [HttpGet]
        [Route("GetCurrentFreelancer")]
        [Authorize(policy: "Freelancer")]
        public async Task<ActionResult<ClientDto>> GetCurrentFreelancer()
        {

            var CurrentFreelancer = await _userManager.GetUserAsync(User);

            var freelancer = await _freelancerManager.GetFreelancerById(CurrentFreelancer.Id);

            if (freelancer != null)
                return Ok(new { Message = "Here is Your Freelancer", body = freelancer });
            return NotFound(new { Message = "No Freelancer was Found" });
        }




        [HttpPut]
        [Route("UpdateFreelancer")]
        [Authorize(policy: "Freelancer")]
        public async Task<ActionResult> UpdateFreelancerData([FromForm] UpdateFreelancerDto freelancerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {

                if (await _freelancerManager.UpdateFreelancer(freelancerDto))
                    return Ok(new { Message = "Freelancer Updated successfully" });
                else return BadRequest(new { Message = "Something Went wrong...." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut]
        [Route("UpdateFreelancerMoney")]
        [Authorize(policy:"Freelancer")]

        public async Task<ActionResult> UpdateFreelancerMoney(UpdateFreelancerMoneyDto FreelancerMoney)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var currentFreelancer = (Freelancer)await _userManager.GetUserAsync(User);

                if (FreelancerMoney.Rank != null) currentFreelancer.Rank += (int)FreelancerMoney.Rank;
                if (FreelancerMoney.Bids != null) currentFreelancer.Bids += (int)FreelancerMoney.Bids;
                if (FreelancerMoney.TotalMoneyEarned != null) currentFreelancer.TotalMoneyEarned += (decimal)FreelancerMoney.TotalMoneyEarned;
                if (FreelancerMoney.PlanId != null) currentFreelancer.PlanId = FreelancerMoney.PlanId;
                if (FreelancerMoney.Balance != null) currentFreelancer.Balance += FreelancerMoney.Balance;


                if (await _freelancerManager.UpdateFreelancerMoney(currentFreelancer))
                    return Ok(new { message = "Data updated successfully" });
                return BadRequest(new { message = "Something went wrong" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            


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
            try
            {

            
            var result = await _clientManager.CreateClient(clientData);

            if (result)
            {
                return Ok(new { Message = "Client Created Successfully" });
            }
            return BadRequest(new { Message = "Something went wrong.... Please try again " });
            }catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message }); 
            }

        }


        [HttpDelete]
        [Route("DeleteCurrentClient")]
        [Authorize(policy: "Client")] 
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
        [Authorize(policy: "Client&Admin")]
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
        [Authorize(policy: "Admin")]
        public ActionResult<List<ClientDto>> GetAllClients()
        {


            var clientlist = _clientManager.GetAllClients();

            if (clientlist != null)
                return Ok(new { Message = "Here are all clients", body = clientlist });
            return NotFound(new { Message = "No Clients Were Found" });

        }

        [HttpGet]
        [Route("GetClientById/{id}")]
        [Authorize]
        public async Task<ActionResult<ClientDto>> GetClientById(string id)
        {

            var Client =await _clientManager.GetClientById(id);

            if (Client != null)
                return Ok(new { Message = "Here is Your Client", body = Client });
            return NotFound(new { Message = "No Client was Found" });
        }

        [HttpGet]
        [Route("GetCurrentClient")]
        [Authorize(policy: "Client")]
        public async Task<ActionResult<ClientDto>> GetCurrentClient()
        {

            var CurrentClient = await _userManager.GetUserAsync(User);

            var Client =await _clientManager.GetClientById(CurrentClient.Id);

            if (Client != null)
                return Ok(new { Message = "Here is Your Client", body = Client });
            return NotFound(new { Message = "No Client was Found" });
        }

        [HttpPut]
        [Route("UpdateClient")]
        [Authorize(policy: "Client")]
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






        [HttpPut]
        [Route("UpdateClientMoney")]
        [Authorize(policy: "Client")]

        public async Task<ActionResult> UpdateClientMoney(UpdateClientMoneyDto ClientMoney)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var CurrentClinet = (Client)await _userManager.GetUserAsync(User);

                if (ClientMoney.TotalMoneySpent != null) CurrentClinet.TotalMoneySpent += (decimal)ClientMoney.TotalMoneySpent;
                if (ClientMoney.PlanId != null) CurrentClinet.PlanId = ClientMoney.PlanId;
                if (ClientMoney.Balance != null) CurrentClinet.Balance += ClientMoney.Balance;


                if (await _clientManager.UpdateClientMoney(CurrentClinet))
                    return Ok(new { message = "Data updated successfully" });
                return BadRequest(new { message = "Something went wrong" });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }



        }


        #endregion


    }
}
