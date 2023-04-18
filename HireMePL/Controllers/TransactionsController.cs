using HireMeBLL;
using HireMeBLL.Dtos.TransactionDtos;
using HireMeDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Id.Insert;

namespace HireMePL
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        #region Constructor&Ingect All Required
        public TransactionsController( ITransactionManager trasactionManager , UserManager<IdentityUser> userManager)
        {
            TrasactionManager = trasactionManager;
            UserManager = userManager;
        }

        public ITransactionManager TrasactionManager { get; }
        public UserManager<IdentityUser> UserManager { get; }

        #endregion

        #region Transaction Cruds ( End Points )

        #region Crud To Get All Transaction For Specific User ( Client or FreeLancer)
        [HttpGet]
        [Route("GetAllTranscationsByUserId")]
        [Authorize]
        public async Task < ActionResult<List<TransactionReadDto>>> GetAllTransactionByUserId()
        {
            var user = await UserManager.GetUserAsync(User); 
            var transactionreadlist = TrasactionManager.GetAllTransactionByUserId(user.Id);
            if(transactionreadlist == null)
            {
                return NotFound(new { Message = "No Data were found" });
            }
            return Ok(transactionreadlist);          

        }
        #endregion

        #region crud To Get Specific Transaction By its Id  
        [HttpGet]
        [Route("GetTransactionById/{id}")]
        public ActionResult<TransactionReadDto> GetTransactionById(int id)
        {
            var transactionread = TrasactionManager.GetTransactionById(id);
            if (transactionread != null)
                return Ok(transactionread);
            else
                return NotFound(new{ message=$"Sorry this Transaction With Id = {id} is not found !! Search By another Id .. " });

        }
        #endregion

        // I have Q here ? i need to show message that tell transaction successfully added ( not work with me )
        // with no content or ok and then push message .. 
        #region crud To Add new Transactio To System 
        [HttpPost]
        [Route("CreateNewTransaction/{id}")]
        
        public ActionResult CreateNewTransaction(CreateTransactionDto transaction,string id)
        {
            if (transaction == null) {
                return BadRequest(new { message=" you have to enter transaction requires !! "}); 
            }
            if(TrasactionManager.CreateNewTransaction(transaction,id))
            {
                return Ok(new { message = "Transaction created successfully" });
            }
            return BadRequest(new { message="Somethign went wrong ....."});

        }
        #endregion

        #region Crud to Delete A specific Transaction With its Id 
        [HttpDelete]
        [Route("DeleteTransaction/{id}")]
        public ActionResult DeleteTransaction(int id) 
        {

            try
            {
                if (TrasactionManager.DeleteTransaction(id))
                {
                return Ok( new {message = $" Transaction with Id = {id} Deleted Successfully !! "});

                }else
                    return NotFound(new {message=$"Transaction with Id ={id} Not found"});

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
          
        }
        #endregion

        #endregion
    }
}

