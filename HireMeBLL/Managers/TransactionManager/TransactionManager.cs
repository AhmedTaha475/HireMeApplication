
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireMeBLL.Dtos.TransactionDtos;
using HireMeDAL;
using HireMeDAL.Repos;

namespace HireMeBLL
{
    public class TransactionManager : ITransactionManager
    {
        #region Constructor && All Injecton Requires in Transaction manager Class 
        public TransactionManager( ITransactionRepo transactionRepo)
        {
            TransactionRepo = transactionRepo;
        }

        public ITransactionRepo TransactionRepo { get; }
        #endregion

        #region All Get Cruds in Transaction Manager Class

        // ==== this function use transaction repo methods to get all transaction for specific user ===== //
        public List<TransactionReadDto> GetAllTransactionByUserId(string userid)
        {
            var transactionDbList = TransactionRepo.GetAllTranscations(userid);
            if (transactionDbList != null) 
            {
            return transactionDbList.Select(t => new TransactionReadDto() {Id=t.TransactionId, Amount=t.Amount,Description=t.Description,DateOfTransaction=t.DateOfTransaction}).ToList();
            
            }return null;
        }

        // ==== this function use transaction repo methods to get specific transaction by id  ===== //
        public TransactionReadDto GetTransactionById(int id)
        {
            Transaction? transactionfromDb = TransactionRepo.GetTransactionById(id);
            if (transactionfromDb is null) { return null; };
            return new TransactionReadDto() {Id=transactionfromDb.TransactionId, Amount =transactionfromDb.Amount,DateOfTransaction=transactionfromDb.DateOfTransaction,Description=transactionfromDb.Description};
        }

        #endregion

        #region All Create Cruds in Transaction Manager Class

        // ==== this function use transaction repo methods to create new transaction ===== //
        public bool CreateNewTransaction(CreateTransactionDto transactiondto,string userId)
        {
            var transactionread = new Transaction(transactiondto.DateOfTransaction, transactiondto.Amount, transactiondto.Description,userId);
            return TransactionRepo.AddNewTranscation(transactionread);
            
        }

        #endregion

        #region All Delete Cruds in Transaction Manager Class

        // ==== this function use transaction repo methods to delete a specific transaction ===== //
        public bool DeleteTransaction(int id)
        {
            return TransactionRepo.DeleteTransaction(id);
            
           
        }

        #endregion
       
    }
}
