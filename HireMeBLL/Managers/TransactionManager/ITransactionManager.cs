using HireMeBLL.Dtos.TransactionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMeBLL
{
    public interface ITransactionManager
    {
        #region Get Crud for Transaction Manager (Interface)

        public List<TransactionReadDto> GetAllTransactionByUserId(string userid);
        public TransactionReadDto GetTransactionById(int id);

        #endregion

        #region Create Crud for Transaction Manager (Interface)
        public bool CreateNewTransaction(CreateTransactionDto transactiondto,string userId);

        #endregion

        #region Delete Crud for Transaction Manager (Interface)
        public bool DeleteTransaction(int id);

        #endregion

    }
}
