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

        public IEnumerable<TransactionReadDto> GetAllTransactionByUserId(string userid);
        public TransactionReadDto GetTransactionById(int id);

        #endregion

        #region Create Crud for Transaction Manager (Interface)
        public void CreateNewTransaction(TransactionReadDto transactiondto);

        #endregion

        #region Update Crud for Transaction Manager (Interface)

        #endregion

        #region Delete Crud for Transaction Manager (Interface)
        public void DeleteTransaction(int id);

        #endregion

    }
}
