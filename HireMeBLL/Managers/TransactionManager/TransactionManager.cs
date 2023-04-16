using HireMeBLL.Managers.TransactionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireMeDAL;
using HireMeDAL.Repos;

namespace HireMeBLL
{
    public class TransactionManager : ITransactionManager
    {
        public TransactionManager( ITransactionRepo transactionRepo)
        {
            TransactionRepo = transactionRepo;
        }

        public ITransactionRepo TransactionRepo { get; }

        // ==== this function use transaction repo methods to create new transaction ===== //
        public void CreateNewTransaction(TransactionReadDto transactiondto)
        {
            var  transactionread = new Transaction (transactiondto.DateOfTransaction ,transactiondto.Amount ,transactiondto.Description);
            TransactionRepo.AddNewTranscation(transactionread);
        }

        // ==== this function use transaction repo methods to delete a specific transaction ===== //
        public void DeleteTransaction(int id)
        {
          TransactionRepo.DeleteTransaction(id);
        }

        // ==== this function use transaction repo methods to get all transaction for specific user ===== //
        public IEnumerable<TransactionReadDto> GetAllTransactionByUserId(string userid)
        {
            var transactionDbList = TransactionRepo.GetAllTranscations(userid);
            return transactionDbList.Select(t => new TransactionReadDto( dateTime: t.DateOfTransaction , amount: t.Amount , description:t.Description ));
        }

        // ==== this function use transaction repo methods to get specific transaction by id  ===== //
        public TransactionReadDto GetTransactionById(int id)
        {
            Transaction ? transactionfromDb = TransactionRepo.GetTransactionById(id);
            if(transactionfromDb is null ) { return null; };
            return new TransactionReadDto(dateTime:transactionfromDb.DateOfTransaction , amount:  transactionfromDb.Amount , description:transactionfromDb.Description );
        }
    }
}
