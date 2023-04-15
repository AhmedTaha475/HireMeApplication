using HireMeBLL;
using HireMeBLL.Managers;
using HireMeBLL.Managers.TransactionManager;
using HireMeDAL;
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
        public TransactionsController( ITransactionManager trasactionManager , UserManager<IdentityUser> userManager)
        {
            TrasactionManager = trasactionManager;
            UserManager = userManager;
        }

        public ITransactionManager TrasactionManager { get; }
        public UserManager<IdentityUser> UserManager { get; }

        [HttpGet]   
       
        public async Task < ActionResult<List<TransactionReadDto>>> GetAllTransactionByUserId()
        {
            var user = await UserManager.GetUserAsync(User); 
            var transactionreadlist = TrasactionManager.GetAllTransactionByUserId(user.Id).ToList();
            return Ok(transactionreadlist);          

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<TransactionReadDto> GetTransactionById(int id)
        {
            var transactionread = TrasactionManager.GetTransactionById(id);
            if (transactionread != null)
                return Ok(transactionread);
            else
                return NotFound();

        }

        [HttpPost]
        public ActionResult CreateNewTransaction(TransactionReadDto transaction)
        {
            if (transaction == null) { return NotFound(); }
            TrasactionManager.CreateNewTransaction(transaction);
            return NoContent();

        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteTransaction(int id) {

            try
            {
                TrasactionManager.DeleteTransaction(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
          
        }
    }
}
